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
using System.Collections.Generic;

public partial class pages_DemoMovie : System.Web.UI.Page
{
    string videoURL = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request[WebConstants.Request.VIDEO_ID] != null)
        {
            ProductsTableAdapters.ProductVideoTableAdapter ta = new ProductsTableAdapters.ProductVideoTableAdapter();
            IEnumerator<Products.ProductVideoEntityRow> videos = ta.GetVideoById(int.Parse(Request[WebConstants.Request.VIDEO_ID])).GetEnumerator();
            if (videos.MoveNext())
            {
                videoURL = videos.Current.url;
            }
        }
    }
    protected string VideoURL
    {
        get
        {
            return videoURL;
        }
    }
}
