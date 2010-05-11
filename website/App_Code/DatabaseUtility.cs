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
/// Summary description for DatabaseUtility
/// </summary>
public static class DatabaseUtility
{
    public static UserSelectByIdResult GetLoggedInCustomer()
    {
        if (HttpContext.Current.Session[WebConstants.Session.USER_ID] != null)
        {            
            int userId = (int)HttpContext.Current.Session[WebConstants.Session.USER_ID];
            CommLibController userOBJ = new CommLibController();
            IEnumerator<UserSelectByIdResult> users = userOBJ.GetUserById(userId);
            if (users.MoveNext())
            {
                return users.Current;
            }
        }
        return null;
    }

    public static EmailTemplates.EmailTemplateEntityRow GetEmailTemplate(string name)
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
