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

public partial class pages_Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected string GetBuyOrTry()
    {
        if (Request[WebConstants.Request.TRY] != null)
        {
            return "Try";
        }
        return "Buy";
    }
    protected string GetMouseOver(object shortName)
    {
        return "this.src='../images/Buy_" + shortName + "_rollover.gif'";
    }
    protected string GetMouseOut(object shortName)
    {
        return "this.src='../images/Buy_" + shortName + ".gif'";
    }
    protected string GetColNumber(object index)
    {
        int indexInt = int.Parse(index.ToString());
        return (indexInt % 3).ToString();
    }
    protected string GetSeperatorHTML(object index)
    {
        int indexInt = int.Parse(index.ToString());
        if(indexInt%3 == 2)
        {
            return "</div><div class='row'>";
        }
        return "";        
    }
}
