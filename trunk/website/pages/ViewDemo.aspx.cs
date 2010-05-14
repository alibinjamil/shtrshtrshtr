using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using ShoppingTrolley.Web;
public partial class pages_ViewDemo : GenericPage
{
    protected override void PostAuthenticated(SimplicityCommLib.DataSets.Common.Users.UsersRow user)
    {
        if (Session[WebConstants.Session.VIEW_DEMO] != null)
        {
            Response.Redirect("~/pages/WatchDemo.aspx");
        }
    }
    protected override void PostUnauthenticated()
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}
