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

public partial class pages_PaymentDetails : GenericPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (LoggedIsUser == null)
        {
            Session[WebConstants.Session.RETURN_URL] = "~/pages/PaymentDetails.aspx";
            Response.Redirect("Login.aspx");
        }
    }

    protected void btnContinue_Click(object sender, ImageClickEventArgs e)
    {
        Session["cardType"] = lstCardType.Text;
        Session["cardNumber"] = txtCardNumber.Text;
        Session["cardExpiryMonth"] = txtExpiryMonth.Text;
        Session["cardExpiryYear"] = txtExpiryYear.Text;
        Session["cardSecurityCode"] = txtSecurityCode.Text;
        Session["cardStartMonth"] = txtStartMonth.Text;
        Session["cardStartYear"] = txtStartYear.Text;
        Session["cardFirstName"] = txtFirstName.Text;
        Session["cardLastName"] = txtLastName.Text;
        Session["cardBillingStreet"] = txtBillingStreet.Text;
        Session["cardBillingTown"] = txtBillingTown.Text;
        Session["cardBillingCounty"] = txtBillingCounty.Text;
        Session["cardBillingCountry"] = txtBillingCountry.Text;
        Session["cardBillingZipCode"] = txtBillingZipCode.Text;
        Session["cardBillingTelephone"] = txtTelephone.Text;

        Response.Redirect("ConfirmCheckout.aspx");
    }
}

