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

using ShoppingTrolley.Web;
using SimplicityCommLib;
public partial class pages_WatchDemo : GenericPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[WebConstants.Session.VIEW_DEMO] == null && LoggedIsUser == null)
        {
            Response.Redirect("~/pages/ViewDemo.aspx");
        }
        CommLibController productOBJ = new CommLibController();
        List<Product> products = productOBJ.GetAllProducts();
        rptProds.DataSource = products;
        rptProds.DataBind();
        if (Request[WebConstants.Request.PRODUCT_ID] != null)
        {
            int productId = int.Parse(Request[WebConstants.Request.PRODUCT_ID]);
            ProductsTableAdapters.ProductVideoTableAdapter videoTA = new ProductsTableAdapters.ProductVideoTableAdapter();
            rptVideos.DataSource = videoTA.GetVideosByProduct(productId);
            rptVideos.DataBind();
            lblContent.Visible = false;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].ProductId == productId)
                {
                    lblProdName.Text = products[i].Name;
                    lblProdName.Visible = true;
                }
            
            }
        }
        else
        {
            lblContent.Visible = true;
            lblProdName.Visible = false;
        }
    }

    protected string GetMouseOver(object shortName)
    {
        return "this.src='../images/watch_" + shortName + "_rollover.gif'";
    }
    protected string GetMouseOut(object shortName)
    {
        return "this.src='../images/watch_" + shortName + ".gif'";
    }
    protected string GetURL(object videoId)
    {
        return "javascript:open_train(\"" + videoId + "\");";
    }
}
