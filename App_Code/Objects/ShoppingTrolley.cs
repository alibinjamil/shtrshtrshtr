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
        public static Products.ExchangeRateRow GetCurrentCurrency()
        {
            if (HttpContext.Current.Session[WebConstants.Session.CURRENT_CURRENCY] != null)
            {
                return (Products.ExchangeRateRow)HttpContext.Current.Session[WebConstants.Session.CURRENT_CURRENCY];
            }
            else
            {
                Products.ExchangeRateRow exchangeRate = ShoppingTrolley.Web.Objects.Product.GetExchangeRate("GBP");
                if (exchangeRate != null)
                {
                    //TODO: If there is no exchange rate for GBP, then application will crash
                    HttpContext.Current.Session[WebConstants.Session.CURRENT_CURRENCY] = exchangeRate;
                    return exchangeRate;
                }
            }
            return null;
        }

        public static void SetCurrency(string currencyCode)
        {
            Products.ExchangeRateRow exchangeRate = ShoppingTrolley.Web.Objects.Product.GetExchangeRate(currencyCode);
            if (exchangeRate != null)
            {                
                HttpContext.Current.Session[WebConstants.Session.CURRENT_CURRENCY] = exchangeRate;                
            }
        }

        public static void AddProductVersion(Product product, int versionId, int quantity)
        {
            //see if already exists in cart
            Products.ProductVersionEntityRow version = product.GetLoadedVersion(versionId);
            ShoppingItem shoppingItem = new ShoppingItem();
            shoppingItem.Product = product.ProductDS;
            shoppingItem.ProductVersion = version;
            shoppingItem.DurationInMonths = WebConstants.DEFAULT_DURATION;
            shoppingItem.Quantity = quantity;
            AddShoppingItem(shoppingItem);
        }

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
                    //if it is version the detail should be null
                    if ( shoppingItemToAdd.ProductDetail == null && shoppingItem.ProductDetail == null
                        && shoppingItemToAdd.ProductVersion != null && shoppingItem.ProductVersion != null
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
            AddProductDetail(product, productDetailId, versionId, 1);
        }
        public static void AddProductDetail(Product product, int productDetailId, int versionId, int quantity)
        {
            //see if already exists in cart
            Products.ProductDetailEntityRow productDetail = product.GetLoadedProductDetail(productDetailId);
            Products.ProductVersionEntityRow version = product.GetLoadedVersion(versionId);
            ShoppingItem shoppingItem = new ShoppingItem();
            shoppingItem.Product = product.ProductDS;
            shoppingItem.ProductDetail = productDetail;
            shoppingItem.ProductVersion = version;
            shoppingItem.DurationInMonths = WebConstants.DEFAULT_DURATION;
            shoppingItem.Quantity = quantity;
            AddShoppingItem(shoppingItem);
        }

        public static double GetTotalAmount()
        {
            double totalAmount = 0;
            if (HttpContext.Current.Session[WebConstants.Session.TROLLEY] != null)
            {
                foreach (ShoppingItem shoppingItem in (List<ShoppingItem>)HttpContext.Current.Session[WebConstants.Session.TROLLEY])
                {
                    totalAmount += shoppingItem.Total;
                }
            }
            return totalAmount;
        }
        public static void ClearTrolley()
        {
            HttpContext.Current.Session[WebConstants.Session.TROLLEY] = null;
        }
    }
