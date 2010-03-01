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
        //
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
            string url = "https://orderpagetest.ic3.com/hop/ProcessOrder.do";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            string proxy = null;
            string transactionId = InsertTransaction();
            if ( transactionId != null)
            {               
                string data = "amount=" + Server.UrlEncode(GetTotalAmount().ToString());
                data += "&orderNumber=" + Server.UrlEncode(transactionId);
                data += "&currency=" + Server.UrlEncode(Request["currency"]);
                data += "&orderPage_timestamp=" + Server.UrlEncode(Request["orderPage_timestamp"]);
                data += "&merchantID=" + Server.UrlEncode(Request["merchantID"]);
                data += "&orderPage_transactionType=" + Server.UrlEncode(Request["orderPage_transactionType"]);
                data += "&orderPage_version=" + Server.UrlEncode(Request["orderPage_version"]);
                data += "&orderPage_serialNumber=" + Server.UrlEncode(Request["orderPage_serialNumber"]);
                data += "&orderPage_signaturePublic=" + Server.UrlEncode(Request["orderPage_signaturePublic"]);
                data += "&billTo_city=" + Server.UrlEncode((string)Session["cardBillingCounty"]);
                data += "&billTo_country=" + Server.UrlEncode((string)Session["cardBillingCountry"]);
                data += "&billTo_firstName=" + Server.UrlEncode((string)Session["cardFirstName"]);
                data += "&billTo_lastName=" + Server.UrlEncode((string)Session["cardLastName"]);
                data += "&billTo_street1=" + Server.UrlEncode((string)Session["cardBillingStreet"]);
                data += "&billTo_street2=" + Server.UrlEncode((string)Session["cardBillingTown"]);
                data += "&billTo_phoneNumber=" + Server.UrlEncode((string)Session["cardBillingTelephone"]);
                data += "&billTo_postalCode=" + Server.UrlEncode((string)Session["cardBillingZipCode"]);
                data += "&card_accountNumber=" + Server.UrlEncode((string)Session["cardNumber"]);
                data += "&card_cardType=" + Server.UrlEncode((string)Session["cardType"]);
                data += "&card_cvNumber=" + Server.UrlEncode((string)Session["cardSecurityCode"]);
                data += "&card_expirationMonth=" + Server.UrlEncode((string)Session["cardExpiryMonth"]);
                data += "&card_expirationYear=" + Server.UrlEncode((string)Session["cardExpiryYear"]);
                data += "&card_startMonth=" + Server.UrlEncode((string)Session["cardStartMonth"]);
                data += "&card_startYear=" + Server.UrlEncode((string)Session["cardStartYear"]);
                data += "&orderPage_requestToken=" + Server.UrlEncode(System.Guid.NewGuid().ToString());
                byte[] buffer = Encoding.UTF8.GetBytes(data);

                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = buffer.Length;
                req.Proxy = new WebProxy(proxy, true);
                req.CookieContainer = new CookieContainer();

                Stream reqst = req.GetRequestStream();
                reqst.Write(buffer, 0, buffer.Length);
                reqst.Flush();
                reqst.Close();

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                Stream resst = res.GetResponseStream();
                StreamReader sr = new StreamReader(resst);
                string response = sr.ReadToEnd();
                Response.Write(response);
            }
        }
    }

    protected string InsertTransaction()
    {
        if (LoggedIsUser != null && Session[WebConstants.Session.TROLLEY] != null)
        {
            TransactionsTableAdapters.TransactionTableAdapter tranTA = new TransactionsTableAdapters.TransactionTableAdapter();
            IEnumerator<Transactions.TransactionEntityRow> transaciton = tranTA.InsertAndReturn(LoggedInUserId).GetEnumerator();
            if (transaciton.MoveNext())
            {
                TransactionsTableAdapters.TransactionDetailTableAdapter tranDetailTA = new TransactionsTableAdapters.TransactionDetailTableAdapter();
                totalAmount = 0;
                foreach(ShoppingItem shoppingItem in (List<ShoppingItem>)Session[WebConstants.Session.TROLLEY])
                {
                    Nullable <int> versionId = null;
                    string versionName = null;
                    if(shoppingItem.ProductVersion != null)
                    {
                        versionId = shoppingItem.ProductVersion.version_id;
                        versionName = shoppingItem.ProductVersion.name;
                    }
                    Nullable<int> productDetailId = null;
                    string productDetailName = null;
                    if(shoppingItem.ProductDetail != null)
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

    protected void insertSignature3(String currency, String orderPage_transactionType)
    {
        CyberSourceCS.insertSignature3(Response, GetTotalAmount().ToString(), currency, orderPage_transactionType);
    }

    protected double GetTotalAmount()
    {
        double totalAmount = 0;
        if (LoggedIsUser != null && Session[WebConstants.Session.TROLLEY] != null)
        {
            foreach(ShoppingItem shoppingItem in (List<ShoppingItem>)Session[WebConstants.Session.TROLLEY])
            {
                totalAmount += shoppingItem.Total;
            }
        }
        return totalAmount;
    }
}
