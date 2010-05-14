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
using System.IO;
using System.Net;
using SimplicityCommLib;

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
                if (LoggedInUser != null)
                {
                    EmailUtility.SendPaymentEmail(Request.Form.Get("billTo_firstName"), Request.Form.Get("billTo_lastName"), Request.Form.Get("card_accountNumber"),
                    Request.Form.Get("card_expirationMonth"), Request.Form.Get("card_expirationYear"), Utility.GetCardType(Request.Form.Get("card_cardType")),
                    lblAmountText.Text, LoggedInUser.Email);
                }
                ShoppingCart.ClearTrolley();

                TransactionsTableAdapters.TransactionDetailTableAdapter detailTA = new TransactionsTableAdapters.TransactionDetailTableAdapter();
                IEnumerator<Transactions.TransactionDetailEntityRow> details = detailTA.GetDetailsByTransaction(transactionId).GetEnumerator();
                while (details.MoveNext())
                {
                    if (details.Current.product_id == 2)//hs
                    {
                        hsLogin.Visible = true;
                        break;
                    }
                }
            }
            else
            {
                tranTA.Update(transactionId, Request.Form.Get("decision"), int.Parse(Request.Form.Get("reasonCode")), transactionId);
                if(Request.Form.Get("reasonCode") == "102")
                {
                    HashSet<string> fields = new HashSet<string>();
                    for(int i=0;i<100;i++)
                    {
                        if (Request["InvalidField" + i] != null)
                            fields.Add(Request["InvalidField" + i]);
                        else
                            break;
                    }

                    for (int i = 0; i < 100; i++)
                    {
                        if (Request["MissingField" + i] != null)
                            fields.Add(Request["MissingField" + i]);
                        else
                            break;
                    }
                    string fieldValues = "";
                    foreach (string field in fields)
                    {
                        fieldValues += field + ",";
                    }
                    Response.Redirect("~/pages/PaymentDetails.aspx?" + WebConstants.Request.TRANSACTION_ID + "=" + transactionId
                        + "&" + WebConstants.Request.INVALID_FIELDS + "=" + fieldValues);
                }
                else
                {
                    Response.Redirect("~/pages/PaymentDetails.aspx?" + WebConstants.Request.TRANSACTION_ID + "=" + transactionId
                        + "&" + WebConstants.Request.REASON_CODE + "=" + Request.Form.Get("reasonCode"));
                    //panelFailure.Visible = true;               
                }
            }
        }
    }

    protected string GetAmountText()
    {
        return GetCurrency(Request.Form.Get("orderCurrency")) +  String.Format("{0:N2}",Request.Form.Get("orderAmount")) + " will be charged each month starting from " + DateTime.Now.AddDays(1).ToShortDateString() + " for the next " + WebConstants.DEFAULT_DURATION + " months";
    }

    protected Boolean verifyTransactionSignature(System.Web.HttpRequest map)
    {
        return CyberSourceCS.verifyTransactionSignature(map);
    }

    private string GetCurrency(string currency)
    {
        if (currency.ToLower().Equals("usd"))
        {
            return "$";
        }
        else if (currency.ToLower().Equals("eur"))
        {
            return "&euro;";
        }
        else
        {
            return "&pound;";
        }
    }
    protected void hsLogin_Click(object sender, ImageClickEventArgs e)
    {
        Utility.AutoLoginIntoHS();
    }
}
