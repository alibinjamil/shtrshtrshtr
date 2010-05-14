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

using SimplicityCommLib;
using System.Collections.Generic;   //mjaved.sim.CommonLib

/// <summary>
/// Summary description for GenericPage
/// </summary>
public abstract class GenericPage : System.Web.UI.Page
{
    protected abstract void PostAuthenticated(SimplicityCommLib.DataSets.Common.Users.UsersRow user);
    protected abstract void PostUnauthenticated();
    protected override void OnLoad(EventArgs e)
    {
        SetMessage(this.Page.Master.FindControl("lblInfoMessage"), "", false);
        SetMessage(this.Page.Master.FindControl("lblErrorMessage"), "", false);
        
        SimplicityCommLib.DataSets.Common.Users.UsersRow user = Authenticate();
        if (user != null)
        {
            ShowLogout(true);
            PostAuthenticated(user);
        }
        else
        {
            ShowLogout(false);
            PostUnauthenticated();
        }
        base.OnLoad(e);
    }
    protected void ShowLogout(bool show)
    {
        Control logout = this.Page.Master.FindControl("hlLogout");
        if(logout != null)
        {
            logout.Visible = show;
        }
    }
    protected void SetInfoMessage(string message)
    {
        SetMessage(this.Page.Master.FindControl("lblInfoMessage"), message,true);
    }
    protected void SetErrorMessage(string message)
    {
        SetMessage(this.Page.Master.FindControl("lblErrorMessage"), message,true);
    }
    private void SetMessage(Control label,string message,bool visible)
    {
        if (label != null)
        {
            Label lbl = (Label)label;
            lbl.Visible = visible;
            lbl.Text = message;
        }
    }
    protected SimplicityCommLib.DataSets.Common.Users.UsersRow Authenticate()
    {
        HttpCookie cookie = Request.Cookies[WebConstants.Cookies.UserLoginSession];

        if (cookie != null && !cookie.Value.Equals(""))
        {
            SimplicityCommLib.DataSets.Common.SessionsTableAdapters.SessionsTableAdapter sessionTA = new SimplicityCommLib.DataSets.Common.SessionsTableAdapters.SessionsTableAdapter();
            IEnumerator<SimplicityCommLib.DataSets.Common.Sessions.SessionsRow> ieSessions = sessionTA.GetSessionByUID(cookie.Value).GetEnumerator();
            if (ieSessions.MoveNext() && ieSessions.Current.EndTime < DateTime.Now)
            {
                ieSessions.Current.EndTime = DateTime.Now.AddMinutes(Constants.Configuration.SessionTimeoutInMinutes);
                sessionTA.Update(ieSessions.Current);
                SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter userTA = new SimplicityCommLib.DataSets.Common.UsersTableAdapters.UsersTableAdapter();
                IEnumerator<SimplicityCommLib.DataSets.Common.Users.UsersRow> ieUsers = userTA.GetUserById(ieSessions.Current.UserId).GetEnumerator();
                if (ieUsers.MoveNext())
                {
                    return ieUsers.Current;
                }
            }
        }
        return null;
    }

    protected void RedirectToLogin()
    {
        RedirectToLogin(HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath);
    }

    protected void RedirectToLogin(string returnUrl)
    {
        Response.Redirect("~/pages/Login.aspx?" + WebConstants.Request.NEED_LOGIN + "=true&" + WebConstants.Request.RETURN_URL + "=" + returnUrl);
    }
}
