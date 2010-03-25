using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for SessionFactory
/// </summary>
public class SessionFactory
{
	public SessionFactory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void AddPaymentDetails(string transactionId,PaymentDetails paymentDetails)
    {
        Dictionary<string, PaymentDetails> paymentHash = null;
        if(HttpContext.Current.Session[WebConstants.Session.PAYMENT_DETAILS] == null)
        {
            HttpContext.Current.Session[WebConstants.Session.PAYMENT_DETAILS] = new Dictionary<string, PaymentDetails>();
        }
        paymentHash = (Dictionary<string, PaymentDetails>)HttpContext.Current.Session[WebConstants.Session.PAYMENT_DETAILS];
        if (paymentHash.ContainsKey(transactionId))
        {
            paymentHash[transactionId] = paymentDetails;
        }
        else
        {
            paymentHash.Add(transactionId, paymentDetails);
        }
        HttpContext.Current.Session[WebConstants.Session.PAYMENT_DETAILS] = paymentHash;
    }
    public static PaymentDetails GetPaymentDetails(string transactionId)
    {
        if (HttpContext.Current.Session[WebConstants.Session.PAYMENT_DETAILS] != null)
        {
            return ((Dictionary<string, PaymentDetails>)HttpContext.Current.Session[WebConstants.Session.PAYMENT_DETAILS])[transactionId];
        }
        return null;
    }

    public static void RemovePaymentDetails(string transactionId)
    {
        if (HttpContext.Current.Session[WebConstants.Session.PAYMENT_DETAILS] != null)
        {
            ((Dictionary<string, PaymentDetails>)HttpContext.Current.Session[WebConstants.Session.PAYMENT_DETAILS]).Remove(transactionId);
        }
    }
}
