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
using System.Collections.Generic;	//mjaved.sim.CommonLib
//using SimplicityCommLib.DataSets.Common;

public partial class pages_CreateAccount : GenericPage
{

    protected override void PostAuthenticated(SimplicityCommLib.DataSets.Common.Users.UsersRow user)
    {

    }
    protected override void PostUnauthenticated()
    {

    }

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
        SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter userTA = new SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter();
        if (userTA.GetUserByEmail(txtEmail.Text).GetEnumerator().MoveNext())
        {
            SetErrorMessage("Email address already resgistered with Simplicity");
            return false;        
        }

        SimplicityCommLib.DataSets.Common.CompanyTableAdapters.CompanyTableAdapter coTA = new SimplicityCommLib.DataSets.Common.CompanyTableAdapters.CompanyTableAdapter();
        if (coTA.GetCompanyByName(txtCompanyName.Text).GetEnumerator().MoveNext())
        {
            SetErrorMessage("Company already registered with Simplicity");
            return false;
        }
        //We do not need this
        /*
        UserTableAdapters.un_co_user_detailsTableAdapter userTA = new UserTableAdapters.un_co_user_detailsTableAdapter();
        if (userTA.GetUserByLogonName(txtEmail.Text,null).GetEnumerator().MoveNext())
        {
            SetErrorMessage("Email address already resgistered with Health&Safety");
            return false;
        }
         */
        return true;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
 
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {        
        if (ValidateFields())
        {
            try
            {
                //CustomerTableAdapters.CustomerTableAdapter customerTA = new CustomerTableAdapters.CustomerTableAdapter();
                //IEnumerator ieCustomer = customerTA.InsertAndReturn(false, false, false, 0, 0, GetFullName(), null, null, txtSurname.Text, txtFirstName.Text, txtJobTitle.Text, txtEmail.Text,
                //    Utility.GetMd5Sum(txtPassword.Text), byte.Parse(listForgotPasswordQuestion.SelectedValue), listForgotPasswordQuestion.SelectedItem.Text, Utility.GetMd5Sum(txtForgotPasswordAnswer.Text), null, false, false, 0,
                //    false, null, null, DateTime.Now, null, DateTime.Now, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ENTITY_TYPE), ShoppingTrolley.Web.utils.Enums.ENTITY_TYPE.USER)).GetEnumerator();

                //mjaved.sim.CommonLib Insert User
                /*CommLibController userOBJ = new CommLibController();
                IEnumerator<UserInsertResult> ieUser = userOBJ.InsertAndReturnUser(cbEmails.Selected, false, false, 0, 0, GetFullName(), null, null, txtSurname.Text, txtFirstName.Text, txtJobTitle.Text, txtEmail.Text,
                    Utility.GetMd5Sum(txtPassword.Text), byte.Parse(listForgotPasswordQuestion.SelectedValue), listForgotPasswordQuestion.SelectedItem.Text, Utility.GetMd5Sum(txtForgotPasswordAnswer.Text), false, false, 0,
                    false, null, 0, DateTime.Now, 0, DateTime.Now, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ENTITY_TYPE), ShoppingTrolley.Web.utils.Enums.ENTITY_TYPE.USER));*/

                SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter userTA = new SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter();
                IEnumerator<SimplicityCommLib.DataSets.Common.Users.UsersRow> ieUsers = userTA.InsertAndReturn(System.Guid.NewGuid().ToString(), System.Guid.NewGuid().ToString(), cbEmails.Selected, false, false, 0, null, GetFullName(), "",
                    GetInitials(), txtFirstName.Text, txtSurname.Text, txtJobTitle.Text, txtEmail.Text, txtPassword.Text, byte.Parse(listForgotPasswordQuestion.SelectedValue),
                    "", txtForgotPasswordAnswer.Text, false, false, 0, false, "", null, DateTime.Now, null, DateTime.Now, SimplicityCommLib.Constants.Roles.User).GetEnumerator();

                if (ieUsers.MoveNext())
                {

                    SimplicityCommLib.DataSets.Common.CompanyTableAdapters.CompanyTableAdapter companyTA = new SimplicityCommLib.DataSets.Common.CompanyTableAdapters.CompanyTableAdapter();
                    IEnumerator<SimplicityCommLib.DataSets.Common.Company.CompanyRow> ieCompany = companyTA.InsertAndReturn(false, txtCompanyName.Text, txtCompanyName.Text, txtJobTitle.Text, GetInitials(), txtFirstName.Text, txtSurname.Text,
                        "", false, ieUsers.Current.UserId, DateTime.Now, ieUsers.Current.UserId, DateTime.Now).GetEnumerator();

                    if (ieCompany.MoveNext())
                    {
                        SimplicityCommLib.DataSets.Common.DepartmentsTableAdapters.DepartmentsTableAdapter deptTA = new SimplicityCommLib.DataSets.Common.DepartmentsTableAdapters.DepartmentsTableAdapter();
                        IEnumerator<SimplicityCommLib.DataSets.Common.Departments.DepartmentsRow> ieDepts = deptTA.InsertAndReturn(ieCompany.Current.CompanyId, false, txtCompanyName.Text, txtCompanyName.Text, txtJobTitle.Text, GetInitials(), txtFirstName.Text, txtSurname.Text, "",
                            ieUsers.Current.UserId, DateTime.Now, ieUsers.Current.UserId, DateTime.Now).GetEnumerator();

                        if (ieDepts.MoveNext())
                        {
                            SimplicityCommLib.DataSets.Common.AddressTableAdapters.AddressTableAdapter addressTA = new SimplicityCommLib.DataSets.Common.AddressTableAdapters.AddressTableAdapter();
                            addressTA.Insert(false, SimplicityCommLib.Constants.AddressCategories.UserAddress, ieCompany.Current.CompanyId, false, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL), txtCompanyName.Text,
                                txtAddressNo.Text, txtAddressLine1.Text, txtAddressLine2.Text, txtAddressLine3.Text, txtAddressLine4.Text, txtAddressLine5.Text, txtPostCode.Text,
                                GetFullAddress(), txtTele1.Text, txtTele2.Text, txtFax.Text, txtMobile.Text, ieUsers.Current.UserId, DateTime.Now, ieUsers.Current.UserId, DateTime.Now,
                                txtTown.Text, txtCounty.Text, txtCounty.Text);

                            addressTA.Insert(false, SimplicityCommLib.Constants.AddressCategories.UserAddress, ieUsers.Current.UserId, false, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL), txtCompanyName.Text,
                                txtAddressNo.Text, txtAddressLine1.Text, txtAddressLine2.Text, txtAddressLine3.Text, txtAddressLine4.Text, txtAddressLine5.Text, txtPostCode.Text,
                                GetFullAddress(), txtTele1.Text, txtTele2.Text, txtFax.Text, txtMobile.Text, ieUsers.Current.UserId, DateTime.Now, ieUsers.Current.UserId, DateTime.Now,
                                txtTown.Text, txtCounty.Text, txtCounty.Text);

                            addressTA.Insert(false, SimplicityCommLib.Constants.AddressCategories.DepartmentAddress, ieDepts.Current.DepartmentId, false, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL), txtCompanyName.Text,
                                txtAddressNo.Text, txtAddressLine1.Text, txtAddressLine2.Text, txtAddressLine3.Text, txtAddressLine4.Text, txtAddressLine5.Text, txtPostCode.Text,
                                GetFullAddress(), txtTele1.Text, txtTele2.Text, txtFax.Text, txtMobile.Text, ieUsers.Current.UserId, DateTime.Now, ieUsers.Current.UserId, DateTime.Now,
                                txtTown.Text, txtCounty.Text, txtCounty.Text);

                            EmailUtility.SendAccountCreationEmail(txtEmail.Text, ieUsers.Current.UserUid, ieUsers.Current.VerificationCode);
                            Response.Redirect("~/pages/ConfirmMail.aspx");
                        }
                    }
                }
            }
            catch
            {
                SetErrorMessage("Unable to process your transaction, please contact the administrator");
            }
        }
    }
    private string GetFullName()
    {
        return txtSurname.Text + ", " + txtFirstName.Text;
    }
    private string GetInitials()
    {
        return txtFirstName.Text.Substring(0, 1) + txtSurname.Text.Substring(0, 1);
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
