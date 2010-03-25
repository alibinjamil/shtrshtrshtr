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

public partial class pages_ConfirmMail : GenericPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetInfoMessage("Instructions have been sent to your email address. Please follow them to activate your account.");
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[WebConstants.Session.RETURN_URL] != null)
        {
            Response.Redirect((string)Session[WebConstants.Session.RETURN_URL]);
        }
        else
        {
            Response.Redirect("~/pages/UserHome.aspx");
        }
    }
}
