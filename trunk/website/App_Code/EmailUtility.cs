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

using System.Collections.Generic;
using DataAccessLayer.DataSets.EmailQueueTableAdapters;
/// <summary>
/// Summary description for EmailUtility
/// </summary>
public static class EmailUtility
{
    private static string FROM_ADDRESS = ConfigurationSettings.AppSettings[WebConstants.Config.FROM_EMAIL_ADDRESS];
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
        try
        {
            EmailQueueTableAdapter ta = new EmailQueueTableAdapter();
            string toEmails = "";
            string toNames = "";
            foreach(MailAddress address in message.To)
            {
                toNames += address.DisplayName + ",";
                toEmails += address.Address + ",";
            }
            ta.Insert(DateTime.Now, 1, "Simplicity4Business", FROM_ADDRESS, toNames.Substring(0, toNames.Length - 1), toEmails.Substring(0, toEmails.Length),
                message.Subject, message.Body, null);

        }
        catch (Exception ex)
        {
            
        }
    }

    /*public static string GetAccountCreationHTML(string customerUID, string verificationCode,string html)
    {
        string url = HttpContext.Current.Request.Url.ToString();
        string[] paths = url.Split('/');
        url = url.Replace(paths[paths.Length - 1], "VerifyEmail.aspx");
        url += "?" + WebConstants.Request.USER_UID + "=" + customerUID;
        url += "&" + WebConstants.Request.VERIFICATION_CODE + "=" + Utility.GetMd5Sum(verificationCode);
        EmailTemplateFactory.Instance.Paramters.Add("##URL##", url);
        EmailTemplates.EmailTemplateEntityRow emailTemplate = EmailTemplateFactory.Instance.GetEmailContents(WebConstants.TemplateNames.ACTIVATION);
        if (emailTemplate != null)
        {
            html = emailTemplate.html.Replace(
            html = ReplaceAttributes(html);
        }
        else
        {
            html = "Thank you for registering with Simplicity4Business. <br/> <br/>"
                        + " Please click the following URL to activate your account. <br/><br/>"
                        + " <a href='" + url + "'>" + url + "</a>";
        }
        return html;
    }

    public static string GetAccountCreationHTML(string password, string html)
    {
        string url = HttpContext.Current.Request.Url.ToString();
        string[] paths = url.Split('/');
        url = url.Replace(paths[paths.Length - 1], "VerifyEmail.aspx");
        url += "?" + WebConstants.Request.USER_UID + "=" + customerUID;
        url += "&" + WebConstants.Request.VERIFICATION_CODE + "=" + Utility.GetMd5Sum(verificationCode);
        html = html.Replace("##URL##", url);
        html = ReplaceAttributes(html);
        return html;
    }*/


    public static void SendAccountCreationEmail(string emailAddress,string customerUID,string verificationCode)
    {
        MailMessage message = new MailMessage();
        message.To.Add(new MailAddress(emailAddress));
        string url = HttpContext.Current.Request.Url.ToString();
        string[] paths = url.Split('/');
        url = url.Replace(paths[paths.Length - 1], "VerifyEmail.aspx");
        url += "?" + WebConstants.Request.USER_UID + "=" + customerUID;
        url += "&" + WebConstants.Request.VERIFICATION_CODE + "=" + Utility.GetMd5Sum(verificationCode);
        EmailTemplateFactory templateFactory = new EmailTemplateFactory();
        templateFactory.Paramters.Add("##URL##", url);
        EmailTemplates.EmailTemplateEntityRow emailTemplate = templateFactory.GetEmailContents(WebConstants.TemplateNames.ACTIVATION);
        if (emailTemplate != null)
        {
            message.Body = emailTemplate.html;
            message.Subject = emailTemplate.subject;
        }
        else
        {
            message.Body = "Thank you for registering with Simplicity4Business. <br/> <br/>"
                        + " Please click the following URL to activate your account. <br/><br/>"
                        + " <a href=' " + url + "'>" + url + "</a>";
            message.Subject = "Activation Code for Simplicity for Business";
        }
        message.IsBodyHtml = true;
        SendEmail(message);
    }

    public static void SendPasswordEmail(string emailAddress, string password)
    {
        MailMessage message = new MailMessage();
        message.To.Add(new MailAddress(emailAddress));
        EmailTemplateFactory templateFactory = new EmailTemplateFactory();
        templateFactory.Paramters.Add("##PASSWORD##", password);
        EmailTemplates.EmailTemplateEntityRow emailTemplate = templateFactory.GetEmailContents(WebConstants.TemplateNames.PASSWORD);
        if (emailTemplate != null)
        {
            message.Body = emailTemplate.html;
            message.Subject = emailTemplate.subject;
        }
        else
        {
            message.Subject = "Simplicity Account Password";
            message.Body = "Your password is " + password;
        }
        message.IsBodyHtml = true;
        //+ " Or click on the following link: <br/>" + url;
        SendEmail(message);
    }

    public static void SendCallMeEmailToAdmin(string contents)
    {
        SendCallMeEmailToAdmin(contents, "Simplicity Call Me Request");
    }

    public static void SendViewDemoEmailToAdmin(string contents)
    {
        SendCallMeEmailToAdmin(contents, "Simplicity View Demo Request");
    }

    private static void SendCallMeEmailToAdmin(string contents, string subject)
    {
        MailMessage message = new MailMessage();
        string[] adminEmailAddresses = ConfigurationSettings.AppSettings[WebConstants.Config.ADMIN_EMAIL_ADDRESSES].Split(',');
        foreach (string adminEmailAddress in adminEmailAddresses)
        {
            message.To.Add(new MailAddress(adminEmailAddress));
        }
        message.Subject = subject;
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

    public static void SendPaymentEmail(string firstName, string lastName, string cardNumber, string expiryMonth, string expiryYear, string cardType, string amountText,string userEmail)
    {
        MailMessage message = new MailMessage();
        message.To.Add(new MailAddress(userEmail));
        message.Subject = "Simplicity Payment Receipt";
        message.IsBodyHtml = true;
        message.Body =  "<b>Card holder's name:</b>" + firstName + "&nbsp;" + lastName + "<br/>";
        message.Body += "<b>Card Number:</b>" + cardNumber + "<br/>";
        message.Body += "<b>Card Expiry:</b>" + expiryMonth + "/" + expiryYear + "<br/>";
        message.Body += "<b>Cart Type:</b>" + cardType + "<br/>";
        message.Body += "<b>Amount Charged:</b>" + amountText + "<br/>";
        SendEmail(message);
    }
    public static void SendViewDemoEmailToUser(string email)
    {
        MailMessage message = new MailMessage();
        message.To.Add(new MailAddress(email));
        message.IsBodyHtml = true;

        SettingsTableAdapters.SettingTableAdapter ta = new SettingsTableAdapters.SettingTableAdapter();
        IEnumerator<Settings.SettingEntityRow> settings = ta.GetSettingsByGroup("ViewDemo").GetEnumerator();
        while (settings.MoveNext())
        {
            if (settings.Current.setting_key == "EmailSubject")
            {
                message.Subject = settings.Current.setting_value;
            }
            else if (settings.Current.setting_key == "EmailContents")
            {
                message.Body = settings.Current.setting_value;
            }
        }
        SendEmail(message);
    }
}
