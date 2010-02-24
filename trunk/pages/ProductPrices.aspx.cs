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
            int productId = int.Parse(Request[WebConstants.Request.PRODUCT_ID]);
            product = Product.LoadCompleteProduct(productId);
            if (product != null)
            {
                rptMandatory.DataSource = product.MandatoryDetails;
                rptMandatory.DataBind();
                rptOptional.DataSource = product.OptionalDetails;
                rptOptional.DataBind();
                if (Request[WebConstants.Request.PRODUCT_DETAIL_ID] != null)
                {
                    int productDetailId = int.Parse(Request[WebConstants.Request.PRODUCT_DETAIL_ID]);
                    int versionId = int.Parse(Request[WebConstants.Request.VERSION_ID]);
                    int price = int.Parse(Request[WebConstants.Request.PRICE]);
                    ShoppingCart.AddProductDetail(product, productDetailId,versionId,price);
                    SetInfoMessage("Add On has been added to your trolley");
                }
                else if (Request[WebConstants.Request.VERSION_ID] != null)
                {
                    int versionId = int.Parse(Request[WebConstants.Request.VERSION_ID]);
                    ShoppingCart.AddProductVersion(product, versionId);
                    SetInfoMessage("Selected product has been added to your trolley ");
                }

            }
        }
        else
        {
            Response.Redirect("~/pages/Products.aspx");
        }
    }
    protected string GetProductImage()
    {
        if (product != null)
        {
            return "~/images/Buy_" + product.ProductDS.short_name + ".gif";
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
            return "ProductPrices.aspx?" + WebConstants.Request.PRODUCT_ID + "=" + product.ProductDS.product_id + "&" + WebConstants.Request.VERSION_ID + "=" + versionId; 
        }
        return "#";
    }

    protected string GetProductDetailBuyNowURL(object versionId, object productDetailId, object price)
    {
        if (product != null)
        {
            return "ProductPrices.aspx?" + WebConstants.Request.PRODUCT_ID + "=" + product.ProductDS.product_id 
                + "&" + WebConstants.Request.VERSION_ID + "=" + versionId
                + "&" + WebConstants.Request.PRODUCT_DETAIL_ID + "=" + productDetailId
                + "&" + WebConstants.Request.PRICE + "=" + price;
        }
        return "#";
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
                        versions.Add(version);
                    }
                    rptHeader.DataSource = versions;
                    rptHeader.DataBind();
                }
            }
        }
    }
}
