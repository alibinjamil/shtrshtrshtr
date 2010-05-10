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
using System.Design;


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
            double total = 0;
            if (Session[WebConstants.Session.TROLLEY] != null)
            {

                List<ShoppingItem> items = (List<ShoppingItem>)Session[WebConstants.Session.TROLLEY];
                foreach (ShoppingItem item in items)
                {
                    total += item.Total;
                }
            }
            this.paymentMsg.Text = "You will be paying " + ShoppingCart.GetCurrentCurrency().html_currency_code + " " + String.Format("{0:N2}",total) + " amount per month for a year from " + DateTime.Now.AddDays(1).ToShortDateString() + " to " + DateTime.Now.AddDays(1).AddMonths(12).ToShortDateString();
        }
    }
    private void BindRepeater()
    {
        rptItems.DataSource = (List<ShoppingItem>)Session[WebConstants.Session.TROLLEY];
        rptItems.DataBind();
    }

    protected void btnCheckout_Click(object sender, ImageClickEventArgs e)
    {
        bool anyError = false;

        foreach (RepeaterItem rpItem in rptItems.Items)
        {
            ASP.common_checkbox_ascx ctrl = (ASP.common_checkbox_ascx)rpItem.FindControl("cbTerms");
            if (ctrl.Selected == false)
            {
                SetErrorMessage("Terms and Conditions must be accepted for all the selected products");
                anyError = true;
            }
        }
        if (!anyError)
        {
            Response.Redirect("~/pages/PaymentDetails.aspx");
        }
    }


}
