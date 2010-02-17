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
        //if (Session["cardType"] != null)
        //    lstCardType.Text = (string)Session["cardType"];
        //if (Session["cardExpiryMonth"] != null)
        //    txtExpiryMonth.Text = (string)Session["cardExpiryMonth"];
        //if (Session["cardExpiryYear"] != null)
        //    txtExpiryYear.Text = (string)Session["cardExpiryYear"];
        //if (Session["cardStartMonth"] != null)
        //    txtStartMonth.Text = (string)Session["cardStartMonth"];
        //if (Session["cardStartYear"] != null)
        //    txtStartYear.Text = (string)Session["cardStartYear"];
        //if (Session["cardFirstName"] != null)
        //    txtFirstName.Text = (string)Session["cardFirstName"];
        //if (Session["cardLastName"] != null)
        //    txtLastName.Text = (string)Session["cardLastName"];
        //if (Session["cardBillingStreet"] != null)
        //    txtBillingStreet.Text = (string)Session["cardBillingStreet"];
        //if (Session["cardBillingTown"] != null)
        //    txtBillingTown.Text = (string)Session["cardBillingTown"];
        //if (Session["cardBillingCounty"] != null)
        //    txtBillingCounty.Text = (string)Session["cardBillingCounty"];
        //if (Session["cardBillingCountry"] != null)
        //    txtBillingCountry.Text = (string)Session["cardBillingCountry"];
        //if (Session["cardBillingZipCode"] != null)
        //    txtBillingZipCode.Text = (string)Session["cardBillingZipCode"];
        //if (Session["cardBillingTelephone"] != null)
        //    txtTelephone.Text = (string)Session["cardBillingTelephone"];
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

