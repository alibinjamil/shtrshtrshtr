﻿using System;
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

public partial class pages_WishList : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            BindRepeater();
    }
    private void BindRepeater()
    {
        if (LoggedIsUser != null)
        {
            rpt.DataSource = GetWishList();
            rpt.DataBind();
        }
    }
    protected void rptItems_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("Remove"))
        {
            int productWishListId = int.Parse(e.CommandArgument.ToString());
            WishListTableAdapters.WishListDSTableAdapter ta = new WishListTableAdapters.WishListDSTableAdapter();
            ta.Delete(productWishListId);
            BindRepeater();
            ta.Dispose();
        }
        else if (e.CommandName.Equals("Save"))
        {
            if (LoggedIsUser != null)
            {
                
                WishList.WishListDSRow wishList = null;
                int wishListId = int.Parse(e.CommandArgument.ToString());
                WishListTableAdapters.WishListDSTableAdapter ta = new WishListTableAdapters.WishListDSTableAdapter();
                IEnumerator<WishList.WishListDSRow> wishListRowIterator = ta.GetWishListById(wishListId).GetEnumerator();
                if (wishListRowIterator.MoveNext())
                    wishList = wishListRowIterator.Current;
                if (wishList != null)
                {
                    List<ShoppingItem> trolleyItems = ((List<ShoppingItem>)Session[WebConstants.Session.TROLLEY]);
                    bool added = false;
                    if (trolleyItems == null)
                    {
                        trolleyItems = new List<ShoppingItem>();
                        added = true;
                    }

                    foreach (ShoppingItem item in trolleyItems)
                    {
                        if (wishList.product_id == item.Product.product_id)
                        {
                            if (!wishList.Isproduct_detail_idNull() && item.ProductDetail != null && item.ProductDetail.product_detail_id == wishList.product_detail_id)
                            {
                                item.Quantity++;
                                added = true;
                                break;
                            }
                        }
                    }

                    if (!added)
                    {
                        ShoppingTrolley.Web.Objects.Product product = ShoppingTrolley.Web.Objects.Product.LoadCompleteProduct(wishList.product_id);
                        if (!wishList.Isproduct_detail_idNull())
                        {
                            ShoppingCart.AddProductDetail(product, wishList.product_detail_id, wishList.version_id);
                        }
                        else
                            ShoppingCart.AddProductVersion(product, wishList.version_id);
                    }
                }
                SetInfoMessage("Item added to your trolley");
            }
        }
    }
    
    List<ShoppingItem> GetWishList()
    {
        List<ShoppingItem> shoppingItems = new List<ShoppingItem>();
        if (LoggedIsUser != null)
        {
            WishListTableAdapters.WishListDSTableAdapter ta = new WishListTableAdapters.WishListDSTableAdapter();

            IEnumerator<WishList.WishListDSRow> wishLists = ta.GetWishListForUser(LoggedIsUser).GetEnumerator();
            while (wishLists.MoveNext())
            {
                shoppingItems.Add(ShoppingItem.Load(wishLists.Current));
            }
        }
        return shoppingItems;
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
        List<ShoppingItem> shoppingItems = GetWishList();
        if (shoppingItems.Count > 0)
        {
            foreach (ShoppingItem item in shoppingItems)
            {
                item.ConversionRate = exchangeRate;
                item.Currency = htmlCurrencyCode;
            }
        }
        rpt.DataSource = shoppingItems;
        rpt.DataBind();
    }
}
