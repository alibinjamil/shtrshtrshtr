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

using ShoppingTrolley.Web;

/// <summary>
/// Summary description for GenericPage
/// </summary>
public class GenericPage : System.Web.UI.Page
{
	public GenericPage()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    protected override void OnLoad(EventArgs e)
    {
        SetMessage(this.Page.Master.FindControl("lblInfoMessage"), "", false);
        SetMessage(this.Page.Master.FindControl("lblErrorMessage"), "", false);
        base.OnLoad(e);
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
    protected Nullable<int> LoggedIsUser
    {
        get
        {
            if (Session[WebConstants.Session.USER_ID] != null)
            {
                return (int)Session[WebConstants.Session.USER_ID];
            }
            return null;
        }
    }

    protected int LoggedInUserId
    {
        get
        {
            if (Session[WebConstants.Session.USER_ID] != null)
            {
                return (int)Session[WebConstants.Session.USER_ID];
            }
            return 0;
        }
    }

    protected void RedirectToLogin()
    {
        Session[WebConstants.Session.RETURN_URL] = Request.AppRelativeCurrentExecutionFilePath;
        Response.Redirect("~/pages/Login.aspx?" + WebConstants.Request.NEED_LOGIN + "=true");
    }
}
