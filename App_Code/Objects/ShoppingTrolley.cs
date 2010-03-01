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
using ShoppingTrolley.Web.Objects;
/// <summary>
/// Summary description for PurchasedObject
/// </summary>
    public static class ShoppingCart
    {
        

        public static void AddProductVersion(Product product, int versionId)
        {
            //see if already exists in cart
            Products.ProductVersionEntityRow version = product.GetLoadedVersion(versionId);
            ShoppingItem shoppingItem = new ShoppingItem();
            shoppingItem.Product = product.ProductDS;
            shoppingItem.ProductVersion = version;
            shoppingItem.DurationInMonths = WebConstants.DEFAULT_DURATION;
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
            ReplaceShoppingItem(shoppingItems, shoppingItem);
            HttpContext.Current.Session[WebConstants.Session.TROLLEY] = shoppingItems;
        }

        private static void ReplaceShoppingItem(List<ShoppingItem> shoppingItems,ShoppingItem shoppingItemToAdd)
        {
            bool added = false;

            
            foreach (ShoppingItem shoppingItem in shoppingItems)
            {
                // if it is a product detail then it will have detail and version as well. 
                // both items should have the same set therefore it is imp to check for that.
                if (shoppingItemToAdd.ProductDetail != null)
                {
                    if (shoppingItemToAdd.ProductDetail != null && shoppingItemToAdd.ProductVersion != null
                        && shoppingItem.ProductDetail != null && shoppingItem.ProductVersion != null)
                    {
                        if (shoppingItemToAdd.ProductDetail.product_detail_id == shoppingItem.ProductDetail.product_detail_id
                            && shoppingItemToAdd.ProductVersion.version_id == shoppingItem.ProductVersion.version_id)
                        {
                            shoppingItem.Quantity += shoppingItemToAdd.Quantity;
                            added = true;
                        }
                    }
                }
                else
                {
                    if (shoppingItemToAdd.ProductVersion != null && shoppingItem.ProductVersion != null
                        && shoppingItemToAdd.ProductVersion.version_id == shoppingItem.ProductVersion.version_id)
                    {
                        shoppingItem.Quantity += shoppingItemToAdd.Quantity;
                        added = true;
                    }
                }
            }
            if (!added)
            {
                shoppingItems.Add(shoppingItemToAdd);
            }
        }

        public static void AddProductDetail(Product product, int productDetailId,int versionId)
        {
            //see if already exists in cart
            Products.ProductDetailEntityRow productDetail = product.GetLoadedProductDetail(productDetailId);
            Products.ProductVersionEntityRow version = product.GetLoadedVersion(versionId);
            ShoppingItem shoppingItem = new ShoppingItem();
            shoppingItem.Product = product.ProductDS;
            shoppingItem.ProductDetail = productDetail;
            shoppingItem.ProductVersion = version;
            shoppingItem.DurationInMonths = WebConstants.DEFAULT_DURATION;
            shoppingItem.Quantity = 1;
            AddShoppingItem(shoppingItem);
        }

    }
