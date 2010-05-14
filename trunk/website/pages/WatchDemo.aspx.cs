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
    protected override void PostAuthenticated(SimplicityCommLib.DataSets.Common.Users.UsersRow user)
    {
    }
    protected override void PostUnauthenticated()
    {
        if (Session[WebConstants.Session.VIEW_DEMO] == null)
        {
            Response.Redirect("~/pages/ViewDemo.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SimplicityCommLib.DataSets.Common.ProductsTableAdapters.ProductsTableAdapter prodTA = new SimplicityCommLib.DataSets.Common.ProductsTableAdapters.ProductsTableAdapter();
        //IEnumerator<SimplicityCommLib.DataSets.Common.Products.ProductsRow> ieProducts = .GetEnumerator();
        rptProds.DataSource = prodTA.GetAllProducts();
        rptProds.DataBind();
        if (Request[WebConstants.Request.PRODUCT_ID] != null)
        {
            int productId = int.Parse(Request[WebConstants.Request.PRODUCT_ID]);
            ProductsTableAdapters.ProductVideoTableAdapter videoTA = new ProductsTableAdapters.ProductVideoTableAdapter();
            rptVideos.DataSource = videoTA.GetVideosByProduct(productId);
            rptVideos.DataBind();
            lblContent.Visible = false;
            SimplicityCommLib.DataSets.Common.Products.ProductsRow product = DatabaseUtility.Instance.GetProduct(productId);
            if(product != null)
            {
                lblProdName.Text = product.Name;
                lblProdName.Visible = true;
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
