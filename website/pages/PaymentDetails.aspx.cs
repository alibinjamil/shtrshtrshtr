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
            lblCCMsg.Text = ShoppingCart.GetCurrentCurrency().html_currency_code + String.Format("{0:N2}", ShoppingCart.GetTotalAmount())
                + " will be deducted from your Card monthly starting from " + DateTime.Now.AddDays(1).ToShortDateString() + " to " + DateTime.Now.AddDays(1).AddMonths(12).ToShortDateString();
//"
            int year = DateTime.Now.Year;
            for (int i = year; i < 2050; i++)
                txtExpiryYear.Items.Add(i.ToString());
            for (int i = 2000; i <= year; i++)
                txtStartYear.Items.Add(i.ToString());
            if (Request[WebConstants.Request.TRANSACTION_ID] != null)
            {
                PaymentDetails paymentDetails = SessionFactory.GetPaymentDetails(Request[WebConstants.Request.TRANSACTION_ID]);
                if (paymentDetails != null)
                {
                    txtBillingCountry.SelectedValue = paymentDetails.Country;
                    txtBillingCounty.Text = paymentDetails.County;
                    txtBillingStreet.Text = paymentDetails.Street;
                    txtBillingTown.Text = paymentDetails.Town;
                    txtBillingZipCode.Text = paymentDetails.PostCode;
                    txtCardNumber.Text = paymentDetails.CardNumber;
                    txtExpiryMonth.SelectedValue = paymentDetails.ExpiryMonth;
                    txtExpiryYear.SelectedValue = paymentDetails.ExpiryYear;
                    txtFirstName.Text = paymentDetails.FirstName;
                    txtLastName.Text = paymentDetails.LastName;
                    txtSecurityCode.Text = paymentDetails.SecurityCode;
                    txtStartMonth.SelectedValue = paymentDetails.StartMonth;
                    txtStartYear.SelectedValue = paymentDetails.StartYear;
                    txtTelephone.Text = paymentDetails.Telephone;
                    lstCardType.SelectedValue = paymentDetails.CardType;
                }

                if (Request[WebConstants.Request.INVALID_FIELDS] != null)
                {
                    SetErrorMessage("Some of the required fields are missing. Please provide all mandatory fields and proceed with checkout");
                    string[] invalidFields = Request[WebConstants.Request.INVALID_FIELDS].Split(',');
                    string ERROR_FIELD = "errorField";
                    foreach (string invalidField in invalidFields)
                    {
                        if(invalidField == "billTo_firstName")
                        {
                            txtFirstName.CssClass = ERROR_FIELD;
                        }
                        else if(invalidField == "billTo_lastName")
                        {
                            txtLastName.CssClass = ERROR_FIELD;
                        }
                        else if(invalidField == "card_cardType")
                        {
                            lstCardType.CssClass = ERROR_FIELD;
                        }
                        else if(invalidField == "card_accountNumber")
                        {
                            txtCardNumber.CssClass = ERROR_FIELD;
                        }
                        else if(invalidField == "card_expirationMonth" || invalidField == "card_expirationYear")
                        {
                            txtExpiryMonth.CssClass = ERROR_FIELD;
                            txtExpiryYear.CssClass = ERROR_FIELD;
                        }
                        else if(invalidField == "billTo_street1")
                        {
                            txtBillingStreet.CssClass = ERROR_FIELD;
                        }
                        else if(invalidField == "billTo_city")
                        {
                            txtBillingCounty.CssClass = ERROR_FIELD;
                        }
                        else if (invalidField == "billTo_country")
                        {
                            txtBillingCountry.CssClass = ERROR_FIELD;
                        }
                    }
                }
                if (Request[WebConstants.Request.REASON_CODE] != null)
                {
                    SetErrorMessage(CyberSourceCS.GetErrorDesc(Request[WebConstants.Request.REASON_CODE]));
                }
            }
            
        }
    }

    protected void btnContinue_Click(object sender, ImageClickEventArgs e)
    {
        string url = ConfigurationSettings.AppSettings[WebConstants.Config.CYBER_SOURCE_URL];
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        string proxy = null;
        //clear it from session to keep the session as min as possible
        if (Request[WebConstants.Request.TRANSACTION_ID] != null)
        {
            SessionFactory.RemovePaymentDetails(Request[WebConstants.Request.TRANSACTION_ID]);
        }
        string transactionId = InsertTransaction();
        if (transactionId != null)
        {
            PaymentDetails paymentDetails = new PaymentDetails();
            paymentDetails.CardNumber = txtCardNumber.Text;
            paymentDetails.CardType = lstCardType.SelectedValue;
            paymentDetails.Country = txtBillingCountry.Text;
            paymentDetails.County = txtBillingCounty.Text;
            paymentDetails.ExpiryMonth = txtExpiryMonth.SelectedValue;
            paymentDetails.ExpiryYear = txtExpiryYear.SelectedValue;
            paymentDetails.FirstName = txtFirstName.Text;
            paymentDetails.LastName = txtLastName.Text;
            paymentDetails.PostCode = txtBillingZipCode.Text;
            paymentDetails.SecurityCode = txtSecurityCode.Text;
            paymentDetails.StartMonth = txtStartMonth.SelectedValue;
            paymentDetails.StartYear = txtStartYear.SelectedValue;
            paymentDetails.Street = txtBillingStreet.Text;
            paymentDetails.Telephone = txtTelephone.Text;
            paymentDetails.Town = txtBillingTown.Text;
            SessionFactory.AddPaymentDetails(transactionId, paymentDetails);

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
            //ClientScript.RegisterStartupScript(typeof(Page), "Processing", "showDialog();", true);
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
                    tranDetailTA.Insert(transaciton.Current.transaction_id, shoppingItem.Product.ProductId, shoppingItem.Product.Name, versionId, versionName,
                        productDetailId, productDetailName, shoppingItem.Quantity, shoppingItem.DurationInMonths, shoppingItem.Price);
                    totalAmount += shoppingItem.Total;
                }
                return transaciton.Current.transaction_unid;
            }
        }
        return null;
    }

}

