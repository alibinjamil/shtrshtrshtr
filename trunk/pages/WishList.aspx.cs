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

public partial class pages_WishList : GenericPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (LoggedIsUser == null)
        {
            Session[WebConstants.Session.RETURN_URL] = "~/pages/WishList.aspx";
            Response.Redirect("~/pages/Login.aspx?" + WebConstants.Request.NEED_LOGIN + "=true");
        }
        else
        {
            BindRepeater();
        }
    }
    private void BindRepeater()
    {
        if (LoggedIsUser != null)
        {
            List<ShoppingItem> shoppingItems = new List<ShoppingItem>();
            WishListTableAdapters.WishListTableAdapter ta = new WishListTableAdapters.WishListTableAdapter();
            IEnumerator<WishList.WishListSelectRow> wishLists = ta.GetWishListForUser(LoggedIsUser).GetEnumerator();
            while (wishLists.MoveNext())
            {
                shoppingItems.Add(ShoppingItem.Load(wishLists.Current));
            }
            rpt.DataSource = shoppingItems;
            rpt.DataBind();
        }
    }
    protected void rptItems_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("Remove"))
        {
            /*List<ShoppingItem> trolley = (List<ShoppingItem>)Session[WebConstants.Session.TROLLEY];
            trolley.RemoveAt(int.Parse(e.CommandArgument.ToString()));
            Session[WebConstants.Session.TROLLEY] = trolley;
            BindRepeater();*/
        }
        else if (e.CommandName.Equals("Save"))
        {
            /*if (LoggedIsUser != null)
            {
                int index = int.Parse(e.CommandArgument.ToString());
                ShoppingItem currentItem = ((List<ShoppingItem>)Session[WebConstants.Session.TROLLEY])[index];
                //Save record for current user
                WishListTableAdapters.WishListTableAdapter ta = new WishListTableAdapters.WishListTableAdapter();
                Nullable<int> versionId = null;
                if (currentItem.ProductVersion != null) versionId = currentItem.ProductVersion.version_id;

                Nullable<int> productDetailId = null;
                if (currentItem.ProductDetail != null) productDetailId = currentItem.ProductDetail.product_detail_id;

                ta.Insert(LoggedInUserId, currentItem.Product.product_id, versionId, productDetailId, currentItem.Quantity, currentItem.DurationInMonths);

                SetInfoMessage("Item added to your trolley");
            }
            else
            {
                Session[WebConstants.Session.RETURN_URL] = "~/pages/Trolley.aspx";
                Response.Redirect("~/pages/Login.aspx?" + WebConstants.Request.NEED_LOGIN + "=true");
            }*/
        }
    }
}
