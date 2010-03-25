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

public partial class common_CheckBox : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string key = "hd_" + this.ClientID ;
        if (IsPostBack)
        {
            if (Request[key] != null && Request[key].Equals("True"))
            {
                selected = true;
            }
            else
            {
                selected = false;
            }
        }

        if (selected)
        {
            checkImage.ImageUrl = "~/images/checkbox_checked.png";
        }
        else
        {
            checkImage.ImageUrl = "~/images/checkbox_unchecked.png";
        }
    }
    private string cssClass;
    public string CssClass
    {
        get { return cssClass; }
        set { cssClass = value; }
    }

    private string text;
    public string Text
    {
        get { return text; }
        set { text = value; }
    }

    private bool selected;
    public bool Selected
    {
        get { return selected; }
        set { selected = value; }
    }
}
