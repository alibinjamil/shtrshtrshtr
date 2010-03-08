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
    protected void imbBtnCheckout_Click(object sender, ImageClickEventArgs e)
    {
        WishListTableAdapters.WishListDSTableAdapter wlTA = new WishListTableAdapters.WishListDSTableAdapter();
        IEnumerator<WishList.WishListDSRow> wishLists = wlTA.GetWishListForUser(LoggedInUserId).GetEnumerator();
        while (wishLists.MoveNext())
        {
            
            if (wishLists.Current.product_detail_id != null)
            {
                ShoppingCart.AddProductDetail(wis
            }
        }
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
                        ShoppingTrolley.Web.Objects.Product product = ShoppingTrolley.Web.Objects.Product.LoadCompleteProduct(wishList.product_id);
                        if (!wishList.Isproduct_detail_idNull())
                        {
                            ShoppingCart.AddProductDetail(product, wishList.product_detail_id, wishList.version_id);
                        }
                        else
                            ShoppingCart.AddProductVersion(product, wishList.version_id);
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
