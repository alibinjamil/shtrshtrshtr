using System;
using System.Configuration;
using System.Net;
using System.Security.Cryptography;

public class CyberSourceCS 
{
    private static String getMerchantID()
    {
        return ConfigurationSettings.AppSettings[WebConstants.Config.MERCHANT_ID];
        
        //return "ultranovacoding_moto";
    }

    private static String getPublicKey()
    {
        return ConfigurationSettings.AppSettings[WebConstants.Config.PUBLIC_KEY];
        //return "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQD3xRFysfMjx5yqtxND85vB9C/MH6V94+ZN1FqI1cgrornPIlYsUIyj86AlZ/yC21rKM/HIu30vuvCpQb2xxScGE4uqHqVaLM9J5/me9JN09DYGe+Wp9Bgn5LI/3soGGbxVRbetOxGtvsKAG0GU3x7/xTeaIJ6sDKpvyz9wfd/KjwIDAQAB";
    }

    private static String getPrivateKey()
    {
        return ConfigurationSettings.AppSettings[WebConstants.Config.PRIVATE_KEY]; 
        //return "MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwgg`JdAgEAAoGBAPfFEXKx8yPHnKq3E0Pzm8H0L8wfpX3j5k3UWojVyCuiuc8iVixQjKPzoCVn/ILbWsoz8ci7fS+68KlBvbHFJwYTi6oepVosz0nn+Z70k3T0NgZ75an0GCfksj/eygYZvFVFt607Ea2+woAbQZTfHv/FN5ognqwMqm/LP3B938qPAgMBAAECgYBycV0YzCcRLL8pfzxv05LrKF33e9qV5nFXG7HhqFU4CoamrSZ+e4oqpHohLQHOc4FhClMws6EkLcXBeDMlbHoUBMPxxRRNdN/YxZtmgmOal4x/cJ8OraHqUFwfehHGXg1tej88vz7ct6Wg4+KDyOUlfc63bPKvk7Zae6Q9Hq6IwQJBAPy7cOvHmW1VJzQa/NPjLMscs3Bz4SJdSeDjB16y0pKocfQQso7WjPWk04EscENvu3iyATUP0XLoctJXa1yv8WECQQD6+TOD82PDLb0SXbTPk7+SPB3IKlIeywMSI+jtaU5WbTj7ZwCjqLAihziCVy11hwrVm2oN/DtEvaGWLrAwVhHvAkAtOxqlh+5ki9XdVGslPMYaf8N5f7OuI8YCEn+SKizXhIAIbyiVub42hE46EwrwdsG1gx4GMhOJHiLWlECpsO9hAkEA1V4p6uNwjE4FcWjTQKrG8qdDVpqMSHul97Up4TVnEVk4WZv/UiQm4qP9aep9zm5pyqKfbpZjORTTHKBC0EVMZwJBAMX0Y5JeoBEQFskejz1NXUU/sstaY8RRf3JagtIwHkwXZqnwGIJ7eEsdSt74M5BaTxQY7MnD+BdZ5sd8fLVancs=";
    }

    private static String getSerialNumber()
    {
        return ConfigurationSettings.AppSettings[WebConstants.Config.SERIAL_NUMBER];
        //return "2662573288090176056187";
    }
    
    //method deprecated
    public static void insertSignature(System.Web.HttpResponse response, String amount, String currency)
    {
        insertSignature3(response, amount, currency, "authorization");
    }

    public static void insertSignature3(System.Web.HttpResponse response, String amount, String currency, String orderPage_transactionType)
    {
        try
        {
            TimeSpan timeSpanTime = DateTime.UtcNow - new DateTime(1970, 1, 1);
            String[] arrayTime = timeSpanTime.TotalMilliseconds.ToString().Split('.');
            String time = arrayTime[0];
            String merchantID = getMerchantID();
            if (merchantID.Equals(""))
                response.Write("<b>Error:</b> <br>The current security script (HOP.cs) doesn't contain your merchant information. Please login to the <a href='https://ebc.cybersource.com/ebc/hop/HOPSecurityLoad.do'>CyberSource Business Center</a> and generate one before proceeding further. Be sure to replace the existing HOP.cs with the newly generated HOP.cs.<br><br>");
            String data = merchantID + amount + currency + time + orderPage_transactionType;
            String pub = getPublicKey();
            String serialNumber = getSerialNumber();
            byte[] byteData = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] byteKey = System.Text.Encoding.UTF8.GetBytes(pub);
            HMACSHA1 hmac = new HMACSHA1(byteKey);
            String publicDigest = Convert.ToBase64String(hmac.ComputeHash(byteData));
            publicDigest = publicDigest.Replace("\n", "");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();            
            sb.Append("<input type=\"hidden\" name=\"amount\" value=\"");
            sb.Append(amount);
            sb.Append("\">\n<input type=\"hidden\" name=\"currency\" value=\"");
            sb.Append(currency);
            sb.Append("\">\n<input type=\"hidden\" name=\"orderPage_timestamp\" value=\"");
            sb.Append(time);
            sb.Append("\">\n<input type=\"hidden\" name=\"merchantID\" value=\"");
            sb.Append(merchantID);
            sb.Append("\">\n<input type=\"hidden\" name=\"orderPage_transactionType\" value=\"");
            sb.Append(orderPage_transactionType);
            sb.Append("\">\n<input type=\"hidden\" name=\"orderPage_signaturePublic\" value=\"");
            sb.Append(publicDigest);
            sb.Append("\">\n<input type=\"hidden\" name=\"orderPage_version\" value=\"4\">\n");
            sb.Append("<input type=\"hidden\" name=\"orderPage_serialNumber\" value=\"");
            sb.Append(serialNumber);
            sb.Append("\">\n");
            response.Write(sb.ToString());
        }
        catch (Exception e)
        {
            //Response.Write(e.StackTrace.ToString());
        }
    }
    public static void insertSubscriptionSignature(System.Web.HttpResponse response, String subscriptionAmount, String subscriptionStartDate, String subscriptionFrequency, String subscriptionNumberOfPayments, String subscriptionAutomaticRenew)
    {
        try {
            String data = subscriptionAmount + subscriptionStartDate + subscriptionFrequency + subscriptionNumberOfPayments + subscriptionAutomaticRenew;
            String pub = getPublicKey();
            byte[] byteData = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] byteKey = System.Text.Encoding.UTF8.GetBytes(pub);
            HMACSHA1 hmac = new HMACSHA1(byteKey);
            String publicDigest = Convert.ToBase64String(hmac.ComputeHash(byteData));
            publicDigest = publicDigest.Replace("\n", "");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();            
            sb.Append("<input type=\"hidden\" name=\"recurringSubscriptionInfo_amount\" value=\"");
            sb.Append(subscriptionAmount);
            sb.Append("\">\n<input type=\"hidden\" name=\"recurringSubscriptionInfo_numberOfPayments\" value=\"");
            sb.Append(subscriptionNumberOfPayments);
            sb.Append("\">\n<input type=\"hidden\" name=\"recurringSubscriptionInfo_frequency\" value=\"");
            sb.Append(subscriptionFrequency);
            sb.Append("\">\n<input type=\"hidden\" name=\"recurringSubscriptionInfo_automaticRenew\" value=\"");
            sb.Append(subscriptionAutomaticRenew);
            sb.Append("\">\n<input type=\"hidden\" name=\"recurringSubscriptionInfo_startDate\" value=\"");
            sb.Append(subscriptionStartDate);
            sb.Append("\">\n<input type=\"hidden\" name=\"recurringSubscriptionInfo_signaturePublic\" value=\"");
            sb.Append(publicDigest);
            sb.Append("\">\n");
            response.Write(sb.ToString());
        } 
        catch (Exception e) {
            //Response.Write(e.StackTrace.ToString());
        }
    }
    public static void insertSubscriptionIDSignature(System.Web.HttpResponse response, String subscriptionID)
    {
        try
        {
            String pub = getPublicKey();
            String data = subscriptionID;
            byte[] byteData = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] byteKey = System.Text.Encoding.UTF8.GetBytes(pub);
            HMACSHA1 hmac = new HMACSHA1(byteKey);
            String publicDigest = Convert.ToBase64String(hmac.ComputeHash(byteData));
            publicDigest = publicDigest.Replace("\n", "");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<input type=\"hidden\" name=\"paySubscriptionCreateReply_subscriptionID\" value=\"");
            sb.Append(subscriptionID);
            sb.Append("\">\n<input type=\"hidden\" name=\"paySubscriptionCreateReply_subscriptionIDPublicSignature\" value=\"");
            sb.Append(publicDigest);
            sb.Append("\">\n");
            response.Write(sb.ToString());
        }
        catch (Exception e)
        {
            //Response.Write(e.StackTrace.ToString());
        }
    }

    public static Boolean verifyTransactionSignature(System.Web.HttpRequest map)
    {
        String transactionSignature;
        String[] signedFieldsArr;
        try
        {
            transactionSignature = map.Form.Get("transactionSignature");
            signedFieldsArr = map.Form.Get("signedFields").Split(',');
        }
        catch (Exception e)
        {
            return false;
        }
        System.Text.StringBuilder data = new System.Text.StringBuilder();
        for (int i = 0; i < signedFieldsArr.Length; i++)
        {            
            data.Append(map.Form.Get(signedFieldsArr[i]));
        }
        byte[] byteData = System.Text.Encoding.UTF8.GetBytes(data.ToString());
        byte[] byteKey = System.Text.Encoding.UTF8.GetBytes(getPublicKey());
        HMACSHA1 hmac = new HMACSHA1(byteKey);
        String publicDigest = Convert.ToBase64String(hmac.ComputeHash(byteData));
        if (transactionSignature.Equals(publicDigest))
            return true;
        else
            return false;
    }

    public static string GetErrorDesc(string reasonCode)
    {
        string desc = "";
       if(reasonCode == "202")//Expired card. Possible action: Request a different card or other form of payment.
       { desc = "The credit card provided is expired. Please try again with a different card";}
       else if(reasonCode == "203")//The card was declined. No other information provided by the issuing bank. Possible action: Request a different card or other form of payment
       { desc = "Payment declined by issuer. Please try again with a different card";}
       else if(reasonCode == "2 04")//Insufficient funds in the account. Possible action: Request a different card or other form of payment.
       { desc = "Insufficient funds in the account. Please try again with a different card";}
       else if(reasonCode == "205")//The card was stolen or lost. Possible action: Review the customer’s information and determine if you want to request a different card from the customer
       { desc = "Invalid credit card. Please try again with a different card ";}
       else if(reasonCode == "207")//The issuing bank was unavailable. Possible action: Wait a few minutes and resend the request.
       { desc = "Unable to connect to issuer. Your card is not charged. Please try again after some time or try with a different card";}
       else if(reasonCode == "208")//The card is inactive or not authorized for card-not-present transactions. Possible action: Request a different card or other form of payment.
       { desc = "The card is either not activated or cannot be used online. Please try again with a different card";}
       else if(reasonCode == "210")//The credit limit for the card has been reached. Possible action: Request a different card or other form of payment.
       { desc = "The card limit has been reached. Please try again with a different card";}
       else if(reasonCode == "211")//The card verification number is invalid. Possible action: Request a different card or other form of payment.
       { desc = "The card verification number is invalid. Please provide correct verification number to proceed with checkout";}
       else if(reasonCode == "220")//The processor declined the request based on a general issue with the customer’s account. Possible action: Request a different form of payment.
       { desc = "Some error occurred processing the card. Please try again or try with a different card";}
       else if(reasonCode == "221")//The customer matched an entry on the processor’s negative file. Possible action: Review the order and contact the payment processor.
       { desc = "Some error occurred processing the card. Please try again or try with a different card";}
       else if(reasonCode == "222")//The customer’s bank account is frozen. Possible action: Review the order or request a different form of payment.
       { desc = "Your account seems to be frozen by bank. Please try again with a different card";}
       else if(reasonCode == "231")//The account number is invalid. Possible action: Request a different card or other form of payment.
       { desc = "Invalid card number. Please provide correct card number to proceed with checkout";}
       else if(reasonCode == "232")//The card type is not accepted by the payment processor. Possible action: Request a different card or other form of payment. Also, check with CyberSource Customer Support to make sure that your account is configured correctly.
       { desc = "Invalid card type. Please provide select correct card type to proceed with checkout or contact support";}
       else if(reasonCode == "233")//The processor declined the request based on an issue with the request itself. Possible action: Request a different form of payment.
       { desc = "Some error occurred while processing the payment. Your card is not charged. Please try again after some time or contact support";}
       else if(reasonCode == "234")//There is a problem with your CyberSource merchant configuration. Possible action: Do not resend the request. Contact Customer Support to correct the configuration problem.
       { desc = "Some error occurred while processing the payment. Your card is not charged. Please try again after some time or contact support";}
       else if(reasonCode == "236")//A processor failure occurred. Possible action: Possible action: Wait a few minutes and resend the request.
       { desc = "Some error occurred while processing the payment. Your card is not charged. Please try again after some time";}
       else if(reasonCode == "240")//The card type is invalid or does not correlate with the credit card number.
       { desc = "Invalid card type selected for the given card number. Please select correct card type to proceed with checkout";}
       else if(reasonCode == "476")//The customer cannot be authenticated. Possible action: Review the customer's order.
       { desc = "Unable to authenticate the card. Please try again with a different card or contact support";}
       else if(reasonCode == "475")//The customer is enrolled in payer authentication. Possible action: Authenticate the cardholder before continuing with the transaction.
       { desc = "Some error occurred while processing the payment. Your card is not charged. Please contact support";}
       else if(reasonCode == "150")//Error: General system failure. Possible action: Wait a few minutes and resend the request.
       { desc = "Some error occurred while processing the payment. Your card is not charged. Please wait for few minutes and try again with checkout";}
       else if(reasonCode == "151")//Error: The request was received, but a server time-out occurred. This error does not include time-outs between the client and the server. Possible action: To avoid duplicating the order, do not resend the request until you have reviewed the order status in the Business Center.
       { desc = "Some error occurred while processing the payment. Your card might have been charged. To avoid duplicating the payment, please contact support";}
       else if(reasonCode == "152")//Error: The request was received, but a service did not finish running in time. Possible action: To avoid duplicating the order, do not resend the request until you have reviewed the order status in the Business Center.
       { desc = "Some error occurred while processing the payment. Your card might have been charged. To avoid duplicating the payment, please contact support";}
       else if(reasonCode == "250")//The request was received, but a time-out occurred with the payment processor. Possible action: To avoid duplicating the transaction, do not resend the request until you have reviewed the transaction status in the Business Center.
       { desc = "Some error occurred while processing the payment. Your card might have been charged. To avoid duplicating the payment, please contact support";}
       return desc;
    }
}