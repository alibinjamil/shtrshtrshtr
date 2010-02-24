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
public partial class pages_ConfirmCheckout : GenericPage
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
        //string[] acceptTerms = Request["acceptTerms"].Split(',');
        /*foreach (string acceptTerm in acceptTerms)
        {
            if (acceptTerm.Equals("false"))
            {
                SetErrorMessage("Terms and Conditions must be accepted for all the selected products");
                anyError = true;
            }
        }*/

        if (!anyError)
        {
            string url = "https://orderpagetest.ic3.com/hop/ProcessOrder.do";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            string proxy = null;
            double totalAmount = 0;
            if (Session[WebConstants.Session.TROLLEY] != null)
            {
                List<ShoppingItem> trolley = (List<ShoppingItem>)Session[WebConstants.Session.TROLLEY];
                foreach (ShoppingItem item in trolley)
                {
                    totalAmount += item.Total;
                }
            }
            string data = "amount=" + Server.UrlEncode(totalAmount.ToString());
            data = data + "&currency=" + Server.UrlEncode(Request["currency"]);
            data = data + "&orderPage_timestamp=" + Server.UrlEncode(Request["orderPage_timestamp"]);
            data = data + "&merchantID=" + Server.UrlEncode(Request["merchantID"]);
            data = data + "&orderPage_transactionType=" + Server.UrlEncode(Request["orderPage_transactionType"]);
            data = data + "&orderPage_version=" + Server.UrlEncode(Request["orderPage_version"]);
            data = data + "&orderPage_serialNumber=" + Server.UrlEncode(Request["orderPage_serialNumber"]);
            data = data + "&orderPage_signaturePublic=" + Server.UrlEncode(Request["orderPage_signaturePublic"]);
            data = data + "&billTo_city=" + Server.UrlEncode((string)Session["cardBillingCounty"]);
            data = data + "&billTo_country=" + Server.UrlEncode((string)Session["cardBillingCountry"]);
            data = data + "&billTo_firstName=" + Server.UrlEncode((string)Session["cardFirstName"]);
            data = data + "&billTo_lastName=" + Server.UrlEncode((string)Session["cardLastName"]);
            data = data + "&billTo_street1=" + Server.UrlEncode((string)Session["cardBillingStreet"]);
            data = data + "&billTo_street2=" + Server.UrlEncode((string)Session["cardBillingTown"]);
            data = data + "&billTo_phoneNumber=" + Server.UrlEncode((string)Session["cardBillingTelephone"]);
            data = data + "&billTo_postalCode=" + Server.UrlEncode((string)Session["cardBillingZipCode"]);
            data = data + "&card_accountNumber=" + Server.UrlEncode((string)Session["cardNumber"]);
            data = data + "&card_cardType=" + Server.UrlEncode((string)Session["cardType"]);
            data = data + "&card_cvNumber=" + Server.UrlEncode((string)Session["cardSecurityCode"]);
            data = data + "&card_expirationMonth=" + Server.UrlEncode((string)Session["cardExpiryMonth"]);
            data = data + "&card_expirationYear=" + Server.UrlEncode((string)Session["cardExpiryYear"]);
            data = data + "&card_startMonth=" + Server.UrlEncode((string)Session["cardStartMonth"]);
            data = data + "&card_startYear=" + Server.UrlEncode((string)Session["cardStartYear"]);
            data = data + "&orderPage_requestToken=" + Server.UrlEncode(System.Guid.NewGuid().ToString());
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

    protected void insertSignature3(String amount, String currency, String orderPage_transactionType)
    {
        double totalAmount = 0;
        if (Session[WebConstants.Session.TROLLEY] != null)
        {
            List<ShoppingItem> trolley = (List<ShoppingItem>)Session[WebConstants.Session.TROLLEY];
            foreach (ShoppingItem item in trolley)
            {
                totalAmount += item.Total;
            }
        }

        CyberSourceCS.insertSignature3(Response, totalAmount.ToString(), currency, orderPage_transactionType);       
    }
}
