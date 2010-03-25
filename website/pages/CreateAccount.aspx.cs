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
        CustomerTableAdapters.CustomerTableAdapter ta = new CustomerTableAdapters.CustomerTableAdapter();
        if (ta.GetCustomerByEmail(txtEmail.Text).GetEnumerator().MoveNext())
        {
            SetErrorMessage("Email address already resgistered with Simplicity");
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
                CustomerTableAdapters.CustomerTableAdapter customerTA = new CustomerTableAdapters.CustomerTableAdapter();
                IEnumerator ieCustomer = customerTA.InsertAndReturn(false, false,cbEmails.Selected, 0, 0, GetFullName(), null, null, txtSurname.Text, txtFirstName.Text, txtJobTitle.Text, txtEmail.Text, 
                    Utility.GetMd5Sum(txtPassword.Text),byte.Parse(listForgotPasswordQuestion.SelectedValue), listForgotPasswordQuestion.SelectedItem.Text,Utility.GetMd5Sum(txtForgotPasswordAnswer.Text), null, false, false, 0,
                    false, null, null, DateTime.Now, null, DateTime.Now, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ENTITY_TYPE), ShoppingTrolley.Web.utils.Enums.ENTITY_TYPE.USER)).GetEnumerator();

                if (ieCustomer.MoveNext())
                {
                    Customer.CustomerEntityRow customer = (Customer.CustomerEntityRow)ieCustomer.Current;
                    CustomerTableAdapters.AddressTableAdapter addressTA = new CustomerTableAdapters.AddressTableAdapter();
                    addressTA.Insert(false, customer.entity_id, false, false, Enum.GetName(typeof(ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE), ShoppingTrolley.Web.utils.Enums.ADDRESS_TYPE.PERSONAL), null,
                        txtAddressNo.Text, txtAddressLine1.Text, txtAddressLine2.Text, txtAddressLine3.Text, txtAddressLine4.Text, txtAddressLine5.Text, txtPostCode.Text,
                        GetFullAddress(), txtTele1.Text, txtTele2.Text, txtFax.Text, txtMobile.Text, null, DateTime.Now, null, DateTime.Now, txtTown.Text, txtCounty.Text, txtCountry.Text);
                    
                    EmailUtility.SendAccountCreationEmail(txtEmail.Text, customer.entity_uid,customer.verification_code);
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
