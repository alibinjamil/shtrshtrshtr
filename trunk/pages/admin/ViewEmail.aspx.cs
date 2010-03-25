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

public partial class pages_admin_ViewEmail : System.Web.UI.Page
{
    public string html;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["name"] != null)
        {
            //if(Request["name"] == EmailUtility.Names.ACTIVATION)
            {
                //html = EmailUtility.GetAccountCreationHTML("TEST", "TEST");
            }            
        }
    }
}
