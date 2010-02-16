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
using ShoppingTrolley.Web;
public partial class pages_TrolleyAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<ShoppingItem> data = new List<ShoppingItem>();
        ShoppingItem item = new ShoppingItem();
        item.ProductName = "Simplicyt H&S";
        item.ProductDescription = "Simplicity web";
        item.ImageUrl = "../images/H&S_man.png";
        item.ProductLogoUrl = "../images/H&S_small_logo.png";
        item.DurationInMonths = 30;
        item.Quantity = 1;
        item.Price = 1.99;
        item.Total = 1.99;
        item.ProductId = 1;
        ShoppingItem item1 = new ShoppingItem();
        item1.ProductName = "New Simplicyt H&S";
        item1.ProductDescription = "New Simplicity web";
        item1.ImageUrl = "../images/HandyGas_man.png";
        item1.ProductLogoUrl = "../images/HandyGas_logo.png";
        item.DurationInMonths = 24;
        item1.Quantity = 10;
        item1.Price = 112.99;
        item1.Total = 1122.99;
        item1.ProductId = 2;

        data.Add(item);
        data.Add(item1);
        Session[WebConstants.Session.TROLLEY] = data;
    }
}
