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

public partial class pages_PaymentDetails : AuthenticatedPage
{
    double totalAmount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            int year = DateTime.Now.Year;
            for (int i = year; i < 2050; i++)
                txtExpiryYear.Items.Add(i.ToString());
            for (int i = 2000; i <= year; i++)
                txtStartYear.Items.Add(i.ToString());

            double total = 0;
            if (Session[WebConstants.Session.TROLLEY] != null)
            {

                List<ShoppingItem> items = (List<ShoppingItem>)Session[WebConstants.Session.TROLLEY];
                foreach (ShoppingItem item in items)
                {
                    total += item.Total;
                }
            }
            total = total /12;

            lblCCMsg.Text = "Amount " + ShoppingCart.GetCurrentCurrency().html_currency_code + " " + String.Format("{0:0.00}",total) + " will be deducted from credit card no " + txtCardNumber.Text + " monthly " + " starting from " + DateTime.Now.ToShortDateString() + "to " + DateTime.Now.AddMonths(12).ToShortDateString();
        }
    }

    protected void btnContinue_Click(object sender, ImageClickEventArgs e)
    {
        string url = ConfigurationSettings.AppSettings["CyberSourceURL"];
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        string proxy = null;
        string transactionId = InsertTransaction();
        if (transactionId != null)
        {
            string data = "amount=" + Server.UrlEncode(Request["amount"]);
            data += "&orderNumber=" + Server.UrlEncode(transactionId);
            data += "&currency=" + Server.UrlEncode(Request["currency"]);
            data += "&orderPage_timestamp=" + Server.UrlEncode(Request["orderPage_timestamp"]);
            data += "&merchantID=" + Server.UrlEncode(Request["merchantID"]);
            data += "&orderPage_transactionType=" + Server.UrlEncode(Request["orderPage_transactionType"]);
            data += "&orderPage_version=" + Server.UrlEncode(Request["orderPage_version"]);
            data += "&orderPage_serialNumber=" + Server.UrlEncode(Request["orderPage_serialNumber"]);
            data += "&orderPage_signaturePublic=" + Server.UrlEncode(Request["orderPage_signaturePublic"]);
            data += "&billTo_city=" + Server.UrlEncode(txtBillingCounty.Text);
            data += "&billTo_country=" + Server.UrlEncode(txtBillingCountry.Text);
            data += "&billTo_firstName=" + Server.UrlEncode(txtFirstName.Text);
            data += "&billTo_lastName=" + Server.UrlEncode(txtLastName.Text);
            data += "&billTo_street1=" + Server.UrlEncode(txtBillingStreet.Text);
            data += "&billTo_street2=" + Server.UrlEncode(txtBillingTown.Text);
            data += "&billTo_phoneNumber=" + Server.UrlEncode(txtTelephone.Text);
            data += "&billTo_postalCode=" + Server.UrlEncode(txtBillingZipCode.Text);
            data += "&card_accountNumber=" + Server.UrlEncode(txtCardNumber.Text);
            data += "&card_cardType=" + Server.UrlEncode(lstCardType.Text);
            data += "&card_cvNumber=" + Server.UrlEncode(txtSecurityCode.Text);
            data += "&card_expirationMonth=" + Server.UrlEncode(txtExpiryMonth.Text);
            data += "&card_expirationYear=" + Server.UrlEncode(txtExpiryYear.Text);
            data += "&card_startMonth=" + Server.UrlEncode(txtStartMonth.Text);
            data += "&card_startYear=" + Server.UrlEncode(txtStartYear.Text);
            data += "&orderPage_requestToken=" + Server.UrlEncode(System.Guid.NewGuid().ToString());

            
            data += "&recurringSubscriptionInfo_amount=" + Server.UrlEncode(Request["recurringSubscriptionInfo_amount"]);
            data += "&recurringSubscriptionInfo_numberOfPayments=" + Server.UrlEncode(Request["recurringSubscriptionInfo_numberOfPayments"]);
            data += "&recurringSubscriptionInfo_frequency=" + Server.UrlEncode(Request["recurringSubscriptionInfo_frequency"]);
            data += "&recurringSubscriptionInfo_automaticRenew=" + Server.UrlEncode(Request["recurringSubscriptionInfo_automaticRenew"]);
            data += "&recurringSubscriptionInfo_startDate=" + Server.UrlEncode(Request["recurringSubscriptionInfo_startDate"]);
            data += "&recurringSubscriptionInfo_signaturePublic=" + Server.UrlEncode(Request["recurringSubscriptionInfo_signaturePublic"]);
            

            byte[] buffer = Encoding.UTF8.GetBytes(data);
            try
            {
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = buffer.Length;
                req.Proxy = new WebProxy(proxy, true);
                req.CookieContainer = new CookieContainer();

                Stream reqst = req.GetRequestStream();
                reqst.Write(buffer, 0, buffer.Length);
                ShoppingCart.ClearTrolley();
                reqst.Flush();
                reqst.Close();
            }
            catch (Exception ex)
            {
               
                ex.StackTrace.ToString();
            }
                       

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            Stream resst = res.GetResponseStream();
            StreamReader sr = new StreamReader(resst);
            string response = sr.ReadToEnd();
            Response.Write(response);
        }

        /*Session["cardType"] = lstCardType.Text;
        Session["cardNumber"] = txtCardNumber.Text;
        Session["cardExpiryMonth"] = txtExpiryMonth.Text;
        Sess`ion["cardExpiryYear"] = txtExpiryYear.Text;
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

        Response.Redirect("ConfirmCheckout.aspx");*/
    }
    protected void insertSignature3()
    {
        CyberSourceCS.insertSignature3(Response, GetTotalAmount().ToString(), ShoppingCart.GetCurrentCurrency().country_code, "subscription");
    }

    protected void insertSubscriptionSignature()
    {
        string today = String.Format("{0:yyyyMMdd}", DateTime.Now);
        CyberSourceCS.insertSubscriptionSignature(Response, GetTotalAmount().ToString(), today, "monthly", WebConstants.DEFAULT_DURATION.ToString(), "false");
    }


    protected double GetTotalAmount()
    {
        return ShoppingCart.GetTotalAmount();
    }

    protected string InsertTransaction()
    {
        if (LoggedIsUser != null && Session[WebConstants.Session.TROLLEY] != null)
        {
            TransactionsTableAdapters.TransactionTableAdapter tranTA = new TransactionsTableAdapters.TransactionTableAdapter();
            IEnumerator<Transactions.TransactionEntityRow> transaciton = tranTA.InsertAndReturn(LoggedInUserId,ShoppingCart.GetCurrentCurrency().country_code,ShoppingCart.GetCurrentCurrency().exchange_rate).GetEnumerator();
            if (transaciton.MoveNext())
            {
                TransactionsTableAdapters.TransactionDetailTableAdapter tranDetailTA = new TransactionsTableAdapters.TransactionDetailTableAdapter();
                totalAmount = 0;
                foreach (ShoppingItem shoppingItem in (List<ShoppingItem>)Session[WebConstants.Session.TROLLEY])
                {
                    Nullable<int> versionId = null;
                    string versionName = null;
                    if (shoppingItem.ProductVersion != null)
                    {
                        versionId = shoppingItem.ProductVersion.version_id;
                        versionName = shoppingItem.ProductVersion.name;
                    }
                    Nullable<int> productDetailId = null;
                    string productDetailName = null;
                    if (shoppingItem.ProductDetail != null)
                    {
                        productDetailId = shoppingItem.ProductDetail.product_detail_id;
                        productDetailName = shoppingItem.ProductDetail.product_detail;
                    }
                    tranDetailTA.Insert(transaciton.Current.transaction_id, shoppingItem.Product.product_id, shoppingItem.Product.name, versionId, versionName,
                        productDetailId, productDetailName, shoppingItem.Quantity, shoppingItem.DurationInMonths, shoppingItem.Price);
                    totalAmount += shoppingItem.Total;
                }
                return transaciton.Current.transaction_unid;
            }
        }
        return null;
    }

}

