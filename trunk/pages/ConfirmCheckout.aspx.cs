﻿using System;
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