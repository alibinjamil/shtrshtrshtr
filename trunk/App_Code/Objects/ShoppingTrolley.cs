using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
/// <summary>
/// Summary description for PurchasedObject
/// </summary>
    public static class ShoppingCart
    {
        

        public static void AddProductVersion(Product product, int versionId)
        {
            //see if already exists in cart
            Products.ProductVersionEntityRow version = product.GetVersion(versionId);
            ShoppingItem shoppingItem = new ShoppingItem();
            shoppingItem.Product = product.ProductDS;
            shoppingItem.ProductVersion = version;
            shoppingItem.DurationInMonths = WebConstants.DEFAULT_DURATION;
            shoppingItem.Price = version.price;
            shoppingItem.Quantity = version.min_users;
            AddShoppingItem(shoppingItem);
        }

        public static void AddShoppingItem(ShoppingItem shoppingItem)
        {
            List<ShoppingItem> shoppingItems = null;
            if (HttpContext.Current.Session[WebConstants.Session.TROLLEY] != null)
            {
                shoppingItems = (List<ShoppingItem>)HttpContext.Current.Session[WebConstants.Session.TROLLEY];
            }
            else
            {
                shoppingItems = new List<ShoppingItem>();
            }
            shoppingItems.Add(shoppingItem);
            HttpContext.Current.Session[WebConstants.Session.TROLLEY] = shoppingItems;
        }


        public static void AddProductDetail(Product product, int productDetailId,int versionId,double price)
        {
            //see if already exists in cart
            Products.ProductDetailEntityRow productDetail = product.GetProductDetail(productDetailId);
            Products.ProductVersionEntityRow version = product.GetVersion(versionId);
            ShoppingItem shoppingItem = new ShoppingItem();
            shoppingItem.Product = product.ProductDS;
            shoppingItem.ProductDetail = productDetail;
            shoppingItem.ProductVersion = version;
            shoppingItem.DurationInMonths = WebConstants.DEFAULT_DURATION;
            shoppingItem.Price = price;
            shoppingItem.Quantity = 1;
            AddShoppingItem(shoppingItem);
        }

    }
