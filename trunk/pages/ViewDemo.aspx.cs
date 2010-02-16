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
public partial class pages_ViewDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[WebConstants.Session.VIEW_DEMO] != null)
        {
            Response.Redirect("~/pages/WatchDemo.aspx");
        }

    }
}
