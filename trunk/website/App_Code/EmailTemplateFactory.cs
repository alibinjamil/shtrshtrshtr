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
using SimplicityCommLib;
/// <summary>
/// Summary description for EmailTemplates
/// </summary>
public class EmailTemplateFactory
{
    private Dictionary<string, string> parameters;
	public EmailTemplateFactory()
	{
        Initialize();
	}

    private void Initialize()
    {
        parameters = new Dictionary<string, string>();
        parameters.Add("##IMAGE_URL##", GetImagesUrl());
        SimplicityCommLib.DataSets.Common.Users.UsersRow user = DatabaseUtility.Instance.GetLoggedInCustomer();
        if (user != null)
        {
            parameters.Add("##CUSTOMER_NAME##", user.NameSurname + ", " + user.NameForename);
        }
    }
    public Dictionary<string, string> Paramters
    {
        get { return parameters; }
    }
    public EmailTemplates.EmailTemplateEntityRow GetEmailContents(string templateName)
    {
        EmailTemplates.EmailTemplateEntityRow emailTemplate = DatabaseUtility.Instance.GetEmailTemplate(templateName);
        if (emailTemplate != null)
        {
            foreach (string key in this.parameters.Keys)
            {
                emailTemplate.html = emailTemplate.html.Replace(key, this.parameters[key]);
            }
        }
        return emailTemplate;
    }
    private string GetImagesUrl()
    {
        string url = HttpContext.Current.Request.Url.ToString();
        string[] paths = url.Split('/');
        url = "";
        for (int i = 0; i < paths.Length; i++)
        {
            if (paths[i] == "pages")
            {
                break;
            }
            url += paths[i] + "/";
        }
        url += "images";
        return url;
    }

}
