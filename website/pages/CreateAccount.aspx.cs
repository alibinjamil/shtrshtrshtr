using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ShoppingTrolley.Web;
using SimplicityCommLib;
using System.Collections.Generic;	//mjaved.sim.CommonLib

public partial class pages_CreateAccount : GenericPage
{


    private bool ValidateFields()
    {
        if (txtEmail.Text.ToLower().Equals(txtConfirmEmail.Text.ToLower()) == false)
        {
            SetErrorMessage("Email Addresses do not match");
            return false;
        }
        if (txtPassword.Text.Equals(txtConfirmPassword.Text) == false)
        {
            SetErrorMessage("Passwords do not match");
            return false;
        }
        
        //mjaved.sim.CommonLib Verifying Email Add
        CommLibController userOBJ = new CommLibController();
        if (userOBJ.GetUserByEmail(txtEmail.Text).MoveNext())
        {
            SetErrorMessage("Email address already resgistered with Simplicity");
            return false;        
        }

        
        UserTableAdapters.un_co_user_detailsTableAdapter userTA = new UserTableAdapters.un_co_user_detailsTableAdapter();
        if (userTA.GetUserByLogonName(txtEmail.Text,null).GetEnumerator().MoveNext())
        {
            SetErrorMessage("Email address already resgistered with Health&Safety");
            return false;
        }
        return true;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
 
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {        
        if (ValidateFields())
        {
            //try
            {
                //CustomerTableAdapters.CustomerTableAdapter customerTA = new CustomerTableAdapters.CustomerTableAdapter();
                //IEnumerator ieCustomer = customerTA.InsertAndReturn(false, false, false, 0, 0, GetFullName(), null, null, txtSurname.Text, txtFirstName.Text, txtJobTitle.Text, txtEmail.Text,
                //    Utility.GetMd5Sum(txtPassword.Text), byte.Parse(listForgotPasswordQuestion.SelectedValue), listForgotPasswordQuestion.SelectedItem.Text, Utility.GetMd5Sum(txtForgotPasswordAnswer.Text), null, false, false, 0,
                //    false, null, null, DateTime.Now, null, DateTime.Now, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ENTITY_TYPE), ShoppingTrolley.Web.utils.Enums.ENTITY_TYPE.USER)).GetEnumerator();

                //mjaved.sim.CommonLib Insert User
                CommLibController userOBJ = new CommLibController();
                IEnumerator<UserInsertResult> ieUser = userOBJ.InsertAndReturnUser(cbEmails.Selected, false, false, 0, 0, GetFullName(), null, null, txtSurname.Text, txtFirstName.Text, txtJobTitle.Text, txtEmail.Text,
                    Utility.GetMd5Sum(txtPassword.Text), byte.Parse(listForgotPasswordQuestion.SelectedValue), listForgotPasswordQuestion.SelectedItem.Text, Utility.GetMd5Sum(txtForgotPasswordAnswer.Text), false, false, 0,
                    false, null, 0, DateTime.Now, 0, DateTime.Now, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ENTITY_TYPE), ShoppingTrolley.Web.utils.Enums.ENTITY_TYPE.USER));


                if (ieUser.MoveNext())
                {
                    CommLibController addressOBJ = new CommLibController();
                    addressOBJ.InsertAddress(false,(int)ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL,ieUser.Current.UserId.Value, false, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL), null,
                        txtAddressNo.Text, txtAddressLine1.Text, txtAddressLine2.Text, txtAddressLine3.Text, txtAddressLine4.Text, txtAddressLine5.Text, txtPostCode.Text,
                        GetFullAddress(), txtTele1.Text, txtTele2.Text, txtFax.Text, txtMobile.Text, 0, DateTime.Now, 0, DateTime.Now, txtTown.Text, txtCounty.Text, txtCountry.Text);

                    //insert record in HS
                    /******/
                    HSCompanyTableAdapters.HSCompanyTableAdapter companyTA = new HSCompanyTableAdapters.HSCompanyTableAdapter();
                    IEnumerator ieCo = companyTA.InsertAndReturn(false, txtCompanyName.Text, txtCompanyName.Text, txtJobTitle.Text, "", txtFirstName.Text, txtSurname.Text, txtAddressNo.Text, txtAddressLine1.Text,
                        txtAddressLine2.Text, txtAddressLine3.Text, txtAddressLine4.Text, txtAddressLine5.Text, txtPostCode.Text, GetFullAddress(), txtTele1.Text, txtTele2.Text, txtFax.Text, txtEmail.Text, "Added from Shopping Cart",
                        null, null, null, null, DateTime.Now, null, DateTime.Now, true, "Fire Warden", "First Aider", false, "Supervisor", false, 1, null, null, null, null, true).GetEnumerator();
                    if (ieCo.MoveNext())
                    {
                        HSCompany.HSCompanyEntityRow company = (HSCompany.HSCompanyEntityRow)ieCo.Current;
                        
                        DepartmentTableAdapters.DepartmentSelectCommandTableAdapter deptTA = new DepartmentTableAdapters.DepartmentSelectCommandTableAdapter();
                        deptTA.Insert(company.co_id, false, txtCompanyName.Text, txtCompanyName.Text, txtJobTitle.Text, "", txtFirstName.Text, txtSurname.Text, txtAddressNo.Text, txtAddressLine1.Text,
                        txtAddressLine2.Text, txtAddressLine3.Text, txtAddressLine4.Text, txtAddressLine5.Text, txtPostCode.Text, GetFullAddress(), txtTele1.Text, txtTele2.Text, txtFax.Text, txtEmail.Text,
                        "Added from Shopping Cart", null, DateTime.Now, null, DateTime.Now);

                        UserTableAdapters.un_co_user_detailsTableAdapter userTA = new UserTableAdapters.un_co_user_detailsTableAdapter();
                        userTA.Insert(false, company.co_id, 1, txtFirstName.Text, txtEmail.Text, Utility.GetMd5Sum(txtPassword.Text), listForgotPasswordQuestion.SelectedItem.Text, 
                            txtTele1.Text, "", txtTele2.Text,txtEmail.Text, txtCompanyName.Text, txtCountry.Text, null, DateTime.Now, null, DateTime.Now, "User");
                    }
 
                    /******/
                    
                    EmailUtility.SendAccountCreationEmail(txtEmail.Text, ieUser.Current.UserUid,ieUser.Current.VerificationCode);
                    Response.Redirect("~/pages/ConfirmMail.aspx");
                }               

            }
            /*catch
            {
                SetErrorMessage("Unable to process your transaction, please contact the administrator");
            }*/
        }
    }
    private string GetFullName()
    {
        return txtSurname.Text + ", " + txtFirstName.Text;
    }
    private string GetFullAddress()
    {
        string fullAddress = "";
        if (txtAddressNo.Text.Trim().Length > 0) fullAddress += txtAddressNo.Text + " ";
        if (txtAddressLine1.Text.Trim().Length > 0) fullAddress += txtAddressLine1.Text + " ";
        if (txtAddressLine2.Text.Trim().Length > 0) fullAddress += txtAddressLine2.Text + " ";
        if (txtAddressLine3.Text.Trim().Length > 0) fullAddress += txtAddressLine3.Text + " ";
        if (txtAddressLine4.Text.Trim().Length > 0) fullAddress += txtAddressLine4.Text + " ";
        if (txtAddressLine5.Text.Trim().Length > 0) fullAddress += txtAddressLine5.Text + " ";
        fullAddress += txtPostCode.Text;
        return fullAddress;
    }
}
