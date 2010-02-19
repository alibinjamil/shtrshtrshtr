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
using System.Text;
using ShoppingTrolley.Web;
public partial class common_CallMePageUserControl : System.Web.UI.UserControl
{
    private string pageName;
    public string PageName
    {
        get { return pageName; }
        set { pageName = value; }
    }
    private bool viewDemo;
    public bool ViewDemo
    {
        get { return viewDemo; }
        set { viewDemo = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrorMessage.Visible = false;
    }
    protected void imgBtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        if (ValidateFields())
        {
            string emailContents = null;
            CallMeTableAdapters.CallMeTableAdapter ta = new CallMeTableAdapters.CallMeTableAdapter();
            CallMeTableAdapters.CallMeProductTableAdapter prodTA = new CallMeTableAdapters.CallMeProductTableAdapter();
            IEnumerator ie = ta.InsertAndReturn(txtFirstName.Text, txtSurName.Text, txtTelephone.Text, txtMobile.Text, txtEmail.Text, txtCompanyName.Text, txtCompanyWebsite.Text,
                txtPostalAddress.Text, txtPostCode.Text, txtComments.Text, viewDemo,(Request[WebConstants.Request.RECEIVE_EMAILS] != "")? true : false ).GetEnumerator();
            if (ie.MoveNext())
            {
                CallMe.CallMeEntityRow callMe = (CallMe.CallMeEntityRow)ie.Current;
                emailContents = GetEmailContent(callMe);
                foreach (string product in Request["products"].Split(','))
                {
                    if (product.Length > 0)
                    {
                        prodTA.Insert(callMe.call_me_id, product);
                        emailContents += "<B> Product: </B>" + product + "<BR/>";
                    }
                }
            }
            if (ViewDemo)
            {
                Session[WebConstants.Session.VIEW_DEMO] = true;
                Response.Redirect("~/pages/WatchDemo.aspx");
            }
            else
            {
                lblInfoMessage.Visible = true;
                lblInfoMessage.Text = "Your request has been submited.";
                EmailUtility.SendCallMeEmailToAdmin(emailContents);
                EmailUtility.SendCallMeEmailToUser(txtEmail.Text);
            }
        }
    }
    private string GetEmailContent(CallMe.CallMeEntityRow callMe)
    {
        StringBuilder email = new StringBuilder();
        email.Append("<B> First Name: </B>").Append(callMe.name_forename).Append("<BR/>");
        email.Append("<B> SurName: </B>").Append(callMe.name_surname).Append("<BR/>");
        email.Append("<B> Telephone: </B>").Append(callMe.telephone).Append("<BR/>");
        email.Append("<B> Mobile: </B>").Append(callMe.cell_number).Append("<BR/>");
        email.Append("<B> EMail: </B>").Append(callMe.email).Append("<BR/>");
        email.Append("<B> Company Name: </B>").Append(callMe.company_name).Append("<BR/>");
        email.Append("<B> Company Website: </B>").Append(callMe.company_website).Append("<BR/>");
        email.Append("<B> Postal Address: </B>").Append(callMe.postal_adress).Append("<BR/>");
        email.Append("<B> Postcode: </B>").Append(callMe.postal_code).Append("<BR/>");
        email.Append("<B> Comments: </B>").Append(callMe.comments).Append("<BR/>");
        return email.ToString();
    }
    private bool ValidateFields()
    {
        if (txtEmail.Text.ToLower().Equals(txtConfirmEmail.Text.ToLower()) == false)
        {
            SetErrorMessage("Email Addresses do not match");
            return false;
        }
        if (Request["products"].Replace(",", "").Length == 0)
        {
            SetErrorMessage("Atleast one product must be selected.");
            return false;
        }
        return true;
    }
    private void SetErrorMessage(string msg)
    {
        lblErrorMessage.Text = msg;
        lblErrorMessage.Visible = true;
    }
}
