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
using System.Text;
using System.Security.Cryptography;
using SimplicityCommLib;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for Utility
/// </summary>
public static class Utility
{


    // Create an md5 sum string of this string
    static public string GetMd5Sum(string str)
    {
        // First we need to convert the string into bytes, which
        // means using a text encoder.
        Encoder enc = System.Text.Encoding.Unicode.GetEncoder();

        // Create a buffer large enough to hold the string
        byte[] unicodeText = new byte[str.Length * 2];
        enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

        // Now that we have a byte array we can ask the CSP to hash it
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] result = md5.ComputeHash(unicodeText);

        // Build the final string by converting each byte
        // into hex and appending it to a StringBuilder
        StringBuilder sb = new StringBuilder();
        for (int i=0;i<result.Length;i++)
        {
            sb.Append(result[i].ToString("X2"));
        }

        // And return it
        return sb.ToString();
    }

    private static int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    /// <summary>
    /// Generates a random string with the given length
    /// </summary>
    /// <param name="size">Size of the string</param>
    /// <param name="lowerCase">If true, generate lowercase string</param>
    /// <returns>Random string</returns>
    public static string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }

    public static string GetCardType(string cardType)
    {
        if(cardType == "001") return "Visa";
        if(cardType == "002") return "MasterCard";
                                     else if (cardType == "003")
                                     return "American Express";
                                     else if (cardType == "004")
                                     return "Discover";
                                     else if (cardType == "005")
                                     return "Diners Club ";
                                     else if (cardType == "007")
                                     return " JCB ";
                                     else if (cardType == "024")
                                     return " Maestro/Solo ";
        return null;
    }

    public static void AutoLoginIntoHS()
    {
        string url = ConfigurationSettings.AppSettings[WebConstants.Config.HS_URL];
        if (HttpContext.Current.Session[WebConstants.Session.USER_ID] != null)
        {
            UserSelectByIdResult User  = DatabaseUtility.GetLoggedInCustomer();
            if (User != null)
            {
                url += "/111AF690-0002-40D7-A26C-01D35380CE51/CreateSession.aspx?userEmail=" + User.Email + "&clientIP=" + HttpContext.Current.Request.UserHostAddress
                    + "&key=CC17DEC2-5727-4FA8-937A-C4D3107BBE8B";
                /*HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Response.Redirect(ConfigurationSettings.AppSettings[WebConstants.Config.HS_URL] + "/UserHome.aspx");*/
            }
            else
            {
                url += "/Register/AddCompany.aspx";
            }
        }
        else
        {
            url += "/Register/AddCompany.aspx";
        }
        HttpContext.Current.Response.Redirect(url);
    }
}