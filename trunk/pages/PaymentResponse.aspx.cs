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

public partial class pages_PaymentResponse : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!verifyTransactionSignature(Request))
        {
            panelSignature.Visible = true;
        }
        else
        {
            TransactionsTableAdapters.TransactionTableAdapter tranTA = new TransactionsTableAdapters.TransactionTableAdapter();
            string transactionId = Request["orderNumber"];
            if (Request.Form.Get("decision") == "ACCEPT" || Request.Form.Get("decision") == "REVIEW")
            {
                lblAmountText.Text = GetAmountText();
                panelSuccess.Visible = true;
                tranTA.Update(transactionId, Request.Form.Get("decision"), null, transactionId);
                CustomerTableAdapters.CustomerTableAdapter customerTA = new CustomerTableAdapters.CustomerTableAdapter();
                IEnumerator<Customer.CustomerEntityRow> customers =  customerTA.GetCustomerById(LoggedInUserId).GetEnumerator();
                if (customers.MoveNext())
                {
                    EmailUtility.SendPaymentEmail(Request.Form.Get("billTo_firstName"), Request.Form.Get("billTo_lastName"), Request.Form.Get("card_accountNumber"),
                    Request.Form.Get("card_expirationMonth"), Request.Form.Get("card_expirationYear"), Utility.GetCardType(Request.Form.Get("card_cardType")),
                    lblAmountText.Text, customers.Current.email);
                }
                ShoppingCart.ClearTrolley();
            }
            else
            {
                panelFailure.Visible = true;
                tranTA.Update(transactionId, Request.Form.Get("decision"), int.Parse(Request.Form.Get("reasonCode")), transactionId);
            }
        }
    }

    protected string GetAmountText()
    {
        return ShoppingCart.GetTotalAmount() + Request.Form.Get("orderCurrency") + " will be charged each month starting from " + DateTime.Now.AddDays(1).ToShortDateString() + " for the next " + WebConstants.DEFAULT_DURATION + " months";
    }

    protected Boolean verifyTransactionSignature(System.Web.HttpRequest map)
    {
        return CyberSourceCS.verifyTransactionSignature(map);
    }
}
