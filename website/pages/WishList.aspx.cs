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
        if (LoggedInUser != null)
        {
            rpt.DataSource = GetWishList();
            rpt.DataBind();
        }
    }
    protected void imbBtnCheckout_Click(object sender, ImageClickEventArgs e)
    {
        WishListTableAdapters.WishListDSTableAdapter wlTA = new WishListTableAdapters.WishListDSTableAdapter();
        IEnumerator<WishList.WishListDSRow> wishLists = wlTA.GetWishListForUser(LoggedInUser.UserId).GetEnumerator();
        while (wishLists.MoveNext())
        {
            ShoppingTrolley.Web.Objects.Product product = ShoppingTrolley.Web.Objects.Product.LoadCompleteProduct(wishLists.Current.product_id);
            if (!wishLists.Current.Isproduct_detail_idNull())
            {
                ShoppingCart.AddProductDetail(product, wishLists.Current.product_detail_id, wishLists.Current.version_id,wishLists.Current.quantity);
            }
            else
                ShoppingCart.AddProductVersion(product, wishLists.Current.version_id, wishLists.Current.quantity);
        }
        if (GetWishList().Count == 0)
        {
            SetErrorMessage("Please select alteast one item before checking out");
        }
        else
        {
            if (LoggedInUser == null)
            {
                RedirectToLogin();
            }
            else
            {

                Response.Redirect("~/pages/AccountAddress.aspx");
            }
        }
    }
    
    protected void imbBtnContinue_Click(object sender, ImageClickEventArgs e)
    {
        /*if (IsPostBack)
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
           // Session[WebConstants.Session.TROLLEY] = shoppingItems ;*/

        Response.Redirect("~/pages/Products.aspx");
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
            if (LoggedInUser != null)
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
                        ShoppingTrolley.Web.Objects.Product product = ShoppingTrolley.Web.Objects.Product.LoadCompleteProduct(wishList.product_id);
                        if (!wishList.Isproduct_detail_idNull())
                        {
                            ShoppingCart.AddProductDetail(product, wishList.product_detail_id, wishList.version_id,wishList.quantity);
                        }
                        else
                            ShoppingCart.AddProductVersion(product, wishList.version_id,wishList.quantity);
                    }

                    foreach (ShoppingItem item in trolleyItems)
                    {
                        if (wishList.product_id == item.Product.ProductId)
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
                            ShoppingCart.AddProductDetail(product, wishList.product_detail_id, wishList.version_id,wishList.quantity);
                        }
                        else
                            ShoppingCart.AddProductVersion(product, wishList.version_id, wishList.quantity);
                    }
                    ta.Delete(wishListId);
                    BindRepeater();

                }
                SetInfoMessage("Item added to your trolley");
            }
        }
    }
    
    List<ShoppingItem> GetWishList()
    {
        List<ShoppingItem> shoppingItems = new List<ShoppingItem>();
        if (LoggedInUser != null)
        {
            WishListTableAdapters.WishListDSTableAdapter ta = new WishListTableAdapters.WishListDSTableAdapter();

            IEnumerator<WishList.WishListDSRow> wishLists = ta.GetWishListForUser(LoggedInUser.UserId).GetEnumerator();
            while (wishLists.MoveNext())
            {
                shoppingItems.Add(ShoppingItem.Load(wishLists.Current));
            }
        }
        return shoppingItems;
    }

    protected void Sterling_Click(object sender, ImageClickEventArgs e)
    {
        ShoppingCart.SetCurrency(WebConstants.Currencies.GBP);
        BindRepeater();
    }
    protected void Euro_Click(object sender, ImageClickEventArgs e)
    {
        ShoppingCart.SetCurrency(WebConstants.Currencies.EUR);
        BindRepeater();
    }
    protected void Dollar_Click(object sender, ImageClickEventArgs e)
    {
        ShoppingCart.SetCurrency(WebConstants.Currencies.GBP);
        BindRepeater();
    }


}
