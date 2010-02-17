using System;
using System.Configuration;
using System.Net;
using System.Security.Cryptography;

public class CyberSourceCS 
{
    private static String getMerchantID()
    {
        return "ultranovacoding_moto";
    }

    private static String getPublicKey()
    {
        return "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQD3xRFysfMjx5yqtxND85vB9C/MH6V94+ZN1FqI1cgrornPIlYsUIyj86AlZ/yC21rKM/HIu30vuvCpQb2xxScGE4uqHqVaLM9J5/me9JN09DYGe+Wp9Bgn5LI/3soGGbxVRbetOxGtvsKAG0GU3x7/xTeaIJ6sDKpvyz9wfd/KjwIDAQAB";
    }

    private static String getPrivateKey()
    {
         return "MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwggJdAgEAAoGBAPfFEXKx8yPHnKq3E0Pzm8H0L8wfpX3j5k3UWojVyCuiuc8iVixQjKPzoCVn/ILbWsoz8ci7fS+68KlBvbHFJwYTi6oepVosz0nn+Z70k3T0NgZ75an0GCfksj/eygYZvFVFt607Ea2+woAbQZTfHv/FN5ognqwMqm/LP3B938qPAgMBAAECgYBycV0YzCcRLL8pfzxv05LrKF33e9qV5nFXG7HhqFU4CoamrSZ+e4oqpHohLQHOc4FhClMws6EkLcXBeDMlbHoUBMPxxRRNdN/YxZtmgmOal4x/cJ8OraHqUFwfehHGXg1tej88vz7ct6Wg4+KDyOUlfc63bPKvk7Zae6Q9Hq6IwQJBAPy7cOvHmW1VJzQa/NPjLMscs3Bz4SJdSeDjB16y0pKocfQQso7WjPWk04EscENvu3iyATUP0XLoctJXa1yv8WECQQD6+TOD82PDLb0SXbTPk7+SPB3IKlIeywMSI+jtaU5WbTj7ZwCjqLAihziCVy11hwrVm2oN/DtEvaGWLrAwVhHvAkAtOxqlh+5ki9XdVGslPMYaf8N5f7OuI8YCEn+SKizXhIAIbyiVub42hE46EwrwdsG1gx4GMhOJHiLWlECpsO9hAkEA1V4p6uNwjE4FcWjTQKrG8qdDVpqMSHul97Up4TVnEVk4WZv/UiQm4qP9aep9zm5pyqKfbpZjORTTHKBC0EVMZwJBAMX0Y5JeoBEQFskejz1NXUU/sstaY8RRf3JagtIwHkwXZqnwGIJ7eEsdSt74M5BaTxQY7MnD+BdZ5sd8fLVancs=";
    }

    private static String getSerialNumber()
    {
        return "2662573288090176056187";
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
}