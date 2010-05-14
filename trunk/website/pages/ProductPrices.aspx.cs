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
using ShoppingTrolley.Web.Objects;

public class Version
{
    private int versionId;
    public int VersionId
    {
        get { return versionId; }
        set { versionId = value; }
    }

    private int productDetailId;
    public int ProductDetailId
    {
        get { return productDetailId; }
        set { productDetailId = value; }
    }

    private double price;
    public double Price
    {
        get { return price; }
        set { price = value; }
    }
}

public partial class pages_ProductPrices : GenericPage
{
    private Product product = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request[WebConstants.Request.PRODUCT_ID] != null)
        {
            if (IsPostBack == false)
            {
                BindData();
                if (product != null)
                {
                    if (Request[WebConstants.Request.PRODUCT_DETAIL_ID] != null)
                    {
                        int productDetailId = int.Parse(Request[WebConstants.Request.PRODUCT_DETAIL_ID]);
                        int versionId = int.Parse(Request[WebConstants.Request.VERSION_ID]);
                        ShoppingCart.AddProductDetail(product, productDetailId, versionId);
                        if (ConfigurationSettings.AppSettings[WebConstants.Config.PAYMENT_OFFLINE].Equals("true"))
                        {
                            Response.Redirect("~/pages/PaymentOffline.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/pages/Trolley.aspx");
                        }
                    }
                    else if (Request[WebConstants.Request.VERSION_ID] != null)
                    {
                        int versionId = int.Parse(Request[WebConstants.Request.VERSION_ID]);
                        ShoppingCart.AddProductVersion(product, versionId);
                        if (ConfigurationSettings.AppSettings[WebConstants.Config.PAYMENT_OFFLINE].Equals("true"))
                        {
                            Response.Redirect("~/pages/PaymentOffline.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/pages/Trolley.aspx");
                        }
                    }
                }
            }
        }
        else
        {
            Response.Redirect("~/pages/Products.aspx");
        }
    }
    
    private void BindData()
    {
        int productId = int.Parse(Request[WebConstants.Request.PRODUCT_ID]);
        product = Product.LoadCompleteProduct(productId);
        if (product != null)
        {
            if (Request[WebConstants.Request.MORE] != null)
            {
                if (product.OptionalDetails.Count > 0)
                {
                    rptOptional.DataSource = product.OptionalDetails.GetRange(0, product.OptionalDetails.Count > WebConstants.DEFAULT_ADDONS ? WebConstants.DEFAULT_ADDONS : product.OptionalDetails.Count);
                    rptOptional.DataBind();
                }                    
                hlBack.NavigateUrl = "~/pages/ProductPrices.aspx?" + WebConstants.Request.PRODUCT_ID + "=" + Request[WebConstants.Request.PRODUCT_ID] ;
                hlBack.Visible = true;
            }
            else
            {
                rptMandatory.DataSource = product.MandatoryDetails;
                rptMandatory.DataBind();
                //as we have to show the first five elements only.
                if (product.OptionalDetails.Count > WebConstants.DEFAULT_ADDONS)
                {
                    rptOptional.DataSource = product.OptionalDetails.GetRange(0, 5);
                    hlMore.Visible = true;
                }
                else if (product.OptionalDetails.Count > 0)
                {
                    rptOptional.DataSource = product.OptionalDetails.GetRange(0, product.OptionalDetails.Count);
                }
                rptOptional.DataBind();
                hlMore.NavigateUrl = "~/pages/ProductPrices.aspx?" + WebConstants.Request.PRODUCT_ID + "=" + Request[WebConstants.Request.PRODUCT_ID]
                    + "&" + WebConstants.Request.MORE + "=true";
                
            }
        }
    }
    protected override void PostAuthenticated(SimplicityCommLib.DataSets.Common.Users.UsersRow user)
    {

    }
    protected override void PostUnauthenticated()
    {

    }

    protected string GetProductImage()
    {
        if (product != null)
        {
            return "~/images/Buy_" + product.ProductDS.ShortName + ".gif";
        }
        return "";
    }
    protected void rptMandatory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (product != null)
        {
            Repeater rptHeader = (Repeater)e.Item.FindControl("rptVersions");
            if (rptHeader != null)
            {
                rptHeader.DataSource = product.Versions;
                rptHeader.DataBind();
            }
        }
    }

    protected string GetVersionBuyNowURL(object versionId)
    {
        if (product != null)
        {
            return "ProductPrices.aspx?" + WebConstants.Request.PRODUCT_ID + "=" + product.ProductDS.ProductId + "&" + WebConstants.Request.VERSION_ID + "=" + versionId; 
        }
        return "#";
    }

    protected string GetProductDetailBuyNowURL(object versionId, object productDetailId, object price)
    {
        if (product != null)
        {
            return "ProductPrices.aspx?" + WebConstants.Request.PRODUCT_ID + "=" + product.ProductDS.ProductId
                + "&" + WebConstants.Request.VERSION_ID + "=" + versionId
                + "&" + WebConstants.Request.PRODUCT_DETAIL_ID + "=" + productDetailId;

        }
        return "#";
    }

    protected string GetVersionPrice(object price)
    {
        double finalPrice = ((double)price) * ShoppingCart.GetCurrentCurrency().exchange_rate;
        return String.Format("{0:N2}", finalPrice);
    }
    protected void rptOptional_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (product != null)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Repeater rptHeader = (Repeater)e.Item.FindControl("rptVersions");
                Products.ProductDetailEntityRow productDetails = (Products.ProductDetailEntityRow)e.Item.DataItem;
                if (rptHeader != null)
                {
                    List<Version> versions = new List<Version>();
                    foreach (Products.ProductVersionEntityRow versionDS in product.Versions)
                    {
                        Version version = new Version();
                        version.VersionId = versionDS.version_id;
                        version.ProductDetailId = productDetails.product_detail_id;
                        if (versionDS.IsdiscountNull())
                        {
                            version.Price = productDetails.price;
                        }
                        else
                        {
                            version.Price = productDetails.price - productDetails.price * versionDS.discount / 100;
                        }
                        version.Price *= ShoppingCart.GetCurrentCurrency().exchange_rate;
                        versions.Add(version);
                    }
                    rptHeader.DataSource = versions;
                    rptHeader.DataBind();
                }
            }
        }
    }

    protected void Sterling_Click(object sender, ImageClickEventArgs e)
    {
        ShoppingCart.SetCurrency(WebConstants.Currencies.GBP);
        BindData();
    }
    protected void Euro_Click(object sender, ImageClickEventArgs e)
    {
        ShoppingCart.SetCurrency(WebConstants.Currencies.EUR);
        BindData();
    }
    protected void Dollar_Click(object sender, ImageClickEventArgs e)
    {
        ShoppingCart.SetCurrency(WebConstants.Currencies.USD);
        BindData();
    }

}
