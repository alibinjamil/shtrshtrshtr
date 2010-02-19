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
using System.Net.Mail;
using System.Net;

/// <summary>
/// Summary description for EmailUtility
/// </summary>
public static class EmailUtility
{
    private static string FROM_ADDRESS = ConfigurationSettings.AppSettings["FromEmailAddress"];
    private static string SMTP_SERVER = "smtpauth.moose.co.uk";
    private static string USER_NAME = "andrewcowie";
    private static string PASSWORD = "access";

    public static void SendEmail(string contents)
    {
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        message.To.Add("alibinjamil@gmail.com");
        message.Subject = "This is the Subject line";
        message.From = new System.Net.Mail.MailAddress("From@online.microsoft.com");
        message.Body = "This is the message body";
        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtpauth.moose.co.uk");
        System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("andrewcowie", "access");
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = SMTPUserInfo;
        smtp.Send(message);
    }

    public static void SendEmail(MailMessage message)
    {
        message.From = new MailAddress(FROM_ADDRESS);
        SmtpClient smtp = new SmtpClient(SMTP_SERVER);
        NetworkCredential userInfo = new NetworkCredential(USER_NAME, PASSWORD);
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = userInfo;
        smtp.Send(message);
    }

    public static void SendAccountCreationEmail(string emailAddress,string customerUID,string verificationCode)
    {
        string url = HttpContext.Current.Request.Url.ToString();
        string[] paths = url.Split('/');
        url = url.Replace(paths[paths.Length-1],"VerifyEmail.aspx");
        url += "?" + WebConstants.Request.USER_UID + "=" + customerUID;
        url += "&" + WebConstants.Request.VERIFICATION_CODE + "=" + Utility.GetMd5Sum(verificationCode);
        MailMessage message = new MailMessage();
        message.To.Add(new MailAddress(emailAddress));
        message.Subject = "Simplicity Account Activation";
        message.IsBodyHtml = true;
        message.Body = "Thank you for registering with Simplicity4Business. <br/> <br/>"
                        + " Please click the following URL to activate your account. <br/><br/>"
                        + " <a href='" + url  + "'>" + url + "</a>";
                        //+ " Or click on the following link: <br/>" + url;
        SendEmail(message);
    }

    public static void SendPasswordEmail(string emailAddress, string password)
    {
        MailMessage message = new MailMessage();
        message.To.Add(new MailAddress(emailAddress));
        message.Subject = "Simplicity Account Password";
        message.IsBodyHtml = true;
        message.Body = "Your password is " + password;
        //+ " Or click on the following link: <br/>" + url;
        SendEmail(message);
    }

    public static void SendCallMeEmailToAdmin(string contents)
    {
        MailMessage message = new MailMessage();
        message.To.Add(new MailAddress(ConfigurationSettings.AppSettings["AdminEmailAddress"]));
        message.Subject = "Simplicity Call Me Request";
        message.IsBodyHtml = true;
        message.Body = contents;
        SendEmail(message);
    }
    public static void SendCallMeEmailToUser(string email)
    {
        MailMessage message = new MailMessage();
        message.To.Add(new MailAddress(email));
        message.Subject = "Simplicity Call Me Request";
        message.IsBodyHtml = true;
        message.Body = "Thank you for submitting your request. We will call you back shortly";
        SendEmail(message);
    }

}
