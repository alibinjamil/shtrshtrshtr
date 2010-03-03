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
public partial class pages_Trolley : GenericPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            BindRepeater();
        }
       
    }
    private void BindRepeater()
    {
        rptItems.DataSource = GetShoppingTrolley();
        rptItems.DataBind();
    }

    protected List<ShoppingItem> GetShoppingTrolley()
    {
        if (Session[WebConstants.Session.TROLLEY] == null)
        {
            Session[WebConstants.Session.TROLLEY] = new List<ShoppingItem>();
        }
        return (List<ShoppingItem>)Session[WebConstants.Session.TROLLEY];
    }

    protected void rptItems_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("Remove"))
        {
            List<ShoppingItem> trolley = GetShoppingTrolley();
            trolley.RemoveAt(int.Parse(e.CommandArgument.ToString()));
            Session[WebConstants.Session.TROLLEY] = trolley;
            BindRepeater();
        }
        else if (e.CommandName.Equals("Save"))
        {
            if (LoggedIsUser != null)
            {
                int index = int.Parse(e.CommandArgument.ToString());
                ShoppingItem currentItem = GetShoppingTrolley()[index];
                //Save record for current user
                WishListTableAdapters.WishListTableAdapter ta = new WishListTableAdapters.WishListTableAdapter();
                Nullable<int> versionId = null;
                if(currentItem.ProductVersion != null) versionId = currentItem.ProductVersion.version_id;

                Nullable<int> productDetailId = null;
                if(currentItem.ProductDetail != null) productDetailId = currentItem.ProductDetail.product_detail_id;
                
                ta.Insert(LoggedInUserId,currentItem.Product.product_id,versionId,productDetailId,currentItem.Quantity,currentItem.DurationInMonths);

                SetInfoMessage("Item added to your wishlist");
            }
            else
            {
                RedirectToLogin();
            }
        }
    }

    protected void imbBtnCheckout_Click(object sender, ImageClickEventArgs e)
    {
        if (GetShoppingTrolley().Count == 0)
        {
            SetErrorMessage("Please select alteast one item before checking out");
        }
        else
        {
            if (LoggedIsUser == null)
            {
                RedirectToLogin();
            }
            else
            {
                
                Response.Redirect("~/pages/PaymentDetails.aspx");
            }
        }
    }

    protected void txtQty_OnTextChanged(object sender, EventArgs e)
    {
        TextBox txtQty = ((TextBox)(sender));
        RepeaterItem repeaterItem = ((RepeaterItem)(txtQty.NamingContainer));
        Label lblUnitPrice = (Label)repeaterItem.FindControl("unitPrice");
        Label lblTotalPrice = (Label)repeaterItem.FindControl("totalPrice");
        lblTotalPrice.Text = Convert.ToString(Convert.ToInt32(txtQty.Text) * Convert.ToInt32(lblUnitPrice.Text));
        GetShoppingTrolley()[repeaterItem.ItemIndex].Quantity = Convert.ToInt32(txtQty.Text);
    }

    protected void imbBtnContinue_Click(object sender, ImageClickEventArgs e)
    {
        if (GetShoppingTrolley().Count == 0)
        {
            SetErrorMessage("Please select alteast one item before checking out");
        }
        else
        {
            if (LoggedIsUser == null)
            {
                RedirectToLogin();
            }
            else
            {
                if (IsPostBack)
                {
                    int count = 0;
                    List<ShoppingItem> shoppingItems = GetShoppingTrolley();
                    foreach (RepeaterItem item in rptItems.Items)
                    {
                        TextBox txtQty = item.FindControl("txtQty") as TextBox;
                        Label totalPrice = item.FindControl("totalPrice") as Label;
                        if (shoppingItems[count].Quantity != Convert.ToInt32(txtQty.Text))
                        {
                            shoppingItems[count].Quantity = int.Parse(txtQty.Text.ToString());
                           
                        }
                        count++;
                    }
                }
               // Session[WebConstants.Session.TROLLEY] = shoppingItems ;
                
                Response.Redirect("~/pages/Products.aspx");
            }
        }
    }
    protected void Sterling_Click(object sender, ImageClickEventArgs e)
    {
        Products.ExchangeRateRow exchangeRate = ShoppingTrolley.Web.Objects.Product.GetExchangeRate("STR");
        this.ReBind(exchangeRate.exchange_rate, exchangeRate.html_currency_code);
    }
    protected void Euro_Click(object sender, ImageClickEventArgs e)
    {
        Products.ExchangeRateRow exchangeRate = ShoppingTrolley.Web.Objects.Product.GetExchangeRate("EUR");
        this.ReBind(exchangeRate.exchange_rate, exchangeRate.html_currency_code);
    }
    protected void Dollar_Click(object sender, ImageClickEventArgs e)
    {
        Products.ExchangeRateRow exchangeRate = ShoppingTrolley.Web.Objects.Product.GetExchangeRate("USD");
        this.ReBind(exchangeRate.exchange_rate, exchangeRate.html_currency_code);
    }

    private void ReBind(double exchangeRate, string htmlCurrencyCode)
    {
        List<ShoppingItem> shoppingItems = GetShoppingTrolley();
        if (shoppingItems.Count > 0)
        {
            foreach (ShoppingItem item in shoppingItems)
            {
                item.ConversionRate = exchangeRate;
                item.Currency = htmlCurrencyCode;
            }
        }
        rptItems.DataSource = shoppingItems;
        rptItems.DataBind();
    }
}
