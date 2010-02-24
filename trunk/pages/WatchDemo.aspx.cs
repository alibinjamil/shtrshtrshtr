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
public partial class pages_WatchDemo : GenericPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[WebConstants.Session.VIEW_DEMO] == null)
        {
            //Response.Redirect("~/pages/ViewDemo.aspx");
        }
        ProductsTableAdapters.ProductTableAdapter prodTA = new ProductsTableAdapters.ProductTableAdapter();
        IEnumerator<Products.ProductEntityRow> products = prodTA.GetAllProducts().GetEnumerator();
        rptProds.DataSource = products;
        rptProds.DataBind();
        if (Request[WebConstants.Request.PRODUCT_ID] != null)
        {
            int productId = int.Parse(Request[WebConstants.Request.PRODUCT_ID]);
            ProductsTableAdapters.ProductVideoTableAdapter videoTA = new ProductsTableAdapters.ProductVideoTableAdapter();
            rptVideos.DataSource = videoTA.GetVideosByProduct(productId);
            rptVideos.DataBind();
            lblContent.Visible = false;
            while (products.MoveNext())
            {
                if (products.Current.product_id == productId)
                {
                    lblProdName.Text = products.Current.name;
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
    protected string GetURL(object url)
    {
        return "javascript:open_train(\"" + url + "\");";
    }
}
