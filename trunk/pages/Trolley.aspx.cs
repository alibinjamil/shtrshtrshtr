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
                WishListTableAdapters.WishListDSTableAdapter ta = new WishListTableAdapters.WishListDSTableAdapter();

                IEnumerator<WishList.WishListDSRow> wishListRows = ta.GetWishListForUserByProductId(LoggedInUserId, currentItem.Product.product_id).GetEnumerator();
                if (wishListRows.MoveNext())
                {
                    wishListRows.Current.quantity++;
                    ta.Update(wishListRows.Current);
                }
                else
                {
                    Nullable<int> versionId = null;
                    if (currentItem.ProductVersion != null) versionId = currentItem.ProductVersion.version_id;

                    Nullable<int> productDetailId = null;
                    if (currentItem.ProductDetail != null) productDetailId = currentItem.ProductDetail.product_detail_id;

                    ta.Insert(LoggedInUserId, currentItem.Product.product_id, versionId, productDetailId, currentItem.Quantity, currentItem.DurationInMonths);
                }
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
            //chckec for authentication on the respective page so it is redirected there
            Response.Redirect("~/pages/AccountAddress.aspx");
        }
    }

    protected void txtQty_OnTextChanged(object sender, EventArgs e)
    {
        TextBox txtQty = ((TextBox)(sender));
        int qty = int.Parse(txtQty.Text);
        RepeaterItem repeaterItem = ((RepeaterItem)(txtQty.NamingContainer));
        if (GetShoppingTrolley()[repeaterItem.ItemIndex].ProductVersion != null
            && qty < GetShoppingTrolley()[repeaterItem.ItemIndex].ProductVersion.min_users)
        {
            SetErrorMessage("Number of licenses must be atleast " + GetShoppingTrolley()[repeaterItem.ItemIndex].ProductVersion.min_users + ". Changes have not been comitted to the Trolley");
        }
        else
        {
            Label lblTotalPrice = (Label)repeaterItem.FindControl("totalPrice");            
            GetShoppingTrolley()[repeaterItem.ItemIndex].Quantity = Convert.ToInt32(txtQty.Text);
            lblTotalPrice.Text = String.Format("{0:N2}", GetShoppingTrolley()[repeaterItem.ItemIndex].Total);
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
        ShoppingCart.SetCurrency(WebConstants.Currencies.USD);
        BindRepeater();
    }
    protected string GetCurrencySymbol()
    {
        return ShoppingCart.GetCurrentCurrency().html_currency_code;
    }

}
