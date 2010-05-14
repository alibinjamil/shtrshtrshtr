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

/// <summary>
/// Summary description for AuthenticatedPage
/// </summary>
public abstract class AuthenticatedPage : GenericPage
{
    protected SimplicityCommLib.DataSets.Common.Users.UsersRow LoggedInUser = null;
	public AuthenticatedPage()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    protected override void PostAuthenticated(SimplicityCommLib.DataSets.Common.Users.UsersRow user)
    {
        LoggedInUser = user;
    }
    protected override void PostUnauthenticated()
    {
        RedirectToLogin();
    }
}
