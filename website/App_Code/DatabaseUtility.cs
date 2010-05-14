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
/// Summary description for DatabaseUtility
/// </summary>
public class DatabaseUtility : SimplicityCommLib.Utility.GenericDatabaseUtility
{
    private static  DatabaseUtility instance = new DatabaseUtility();
    private DatabaseUtility()
    {
    }

    public static DatabaseUtility Instance 
    {
        get { return instance; }
    }
    public EmailTemplates.EmailTemplateEntityRow GetEmailTemplate(string name)
    {  
        EmailTemplatesTableAdapters.EmailTemplateTableAdapter ta = new EmailTemplatesTableAdapters.EmailTemplateTableAdapter();
        IEnumerator<EmailTemplates.EmailTemplateEntityRow> emailTemplates = ta.GetEmailTemplate(name).GetEnumerator();
        if (emailTemplates.MoveNext())
        {
            return emailTemplates.Current;
        }
        return null;
    }
}
