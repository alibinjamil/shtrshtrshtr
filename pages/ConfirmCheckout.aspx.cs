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
using System.Collections.Generic;


using ShoppingTrolley.Web;
using System.Net;
using System.Text;
using System.IO;
public partial class pages_ConfirmCheckout : AuthenticatedPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            BindRepeater();
        }
    }
    private void BindRepeater()
    {
        rptItems.DataSource = (List<ShoppingItem>)Session[WebConstants.Session.TROLLEY];
        rptItems.DataBind();
    }
    double totalAmount = 0;
    protected void btnCheckout_Click(object sender, ImageClickEventArgs e)
    {
        bool anyError = false;

        if (Request["acceptTerms"] != null)
        {
            string[] acceptTerms = Request["acceptTerms"].Split(',');
            foreach (string acceptTerm in acceptTerms)
            {
                if (acceptTerm.Equals("false"))
                {
                    SetErrorMessage("Terms and Conditions must be accepted for all the selected products");
                    anyError = true;
                }
            }
        }

        if (!anyError)
        {
            Response.Redirect("~/pages/PaymentDetails.aspx");
        }
    }


}
