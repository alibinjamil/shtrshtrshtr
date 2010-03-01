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
public class AuthenticatedPage : GenericPage
{
	public AuthenticatedPage()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    protected override void OnInit(EventArgs e)
    {
        if (LoggedIsUser == null)
        {
            RedirectToLogin();
        }
        base.OnInit(e);
    }
}
