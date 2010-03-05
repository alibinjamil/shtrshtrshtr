﻿using System;
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

/// <summary>
/// Summary description for PurchasedObject
/// </summary>

    public class ShoppingItem
    {
        private Products.ProductEntityRow product;
        public Products.ProductEntityRow Product 
        {
            get{ return product;}
            set{product = value;}
        }

        private Products.ProductDetailEntityRow productDetail;
        public Products.ProductDetailEntityRow ProductDetail
        {
            get { return productDetail; }
            set { productDetail = value; }
        }

        private Products.ProductVersionEntityRow productVersion;
        public Products.ProductVersionEntityRow ProductVersion
        {
            get { return productVersion; }
            set { productVersion = value; }
        }

        private int durationInMonths;
        public int DurationInMonths
        {
            get { return durationInMonths; }
            set { durationInMonths = value; }
        }

        public string DurationString
        {
            get
            {
                string durationString = string.Empty;
                int months = durationInMonths % 12;
                int years = durationInMonths / 12;
                if (years > 0)
                {
                    durationString = years.ToString() + " years";
                }
                durationString += months.ToString() + " months";
                return durationString;
            }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private double conversionRate = 1;
        public double ConversionRate
        {
            get { return conversionRate; }
            set { conversionRate = value; }
        }

        private string currency = "&pound";
        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }
        
        public double Price
        {
            get 
            {
                if (this.ProductDetail != null)
                {
                    if (this.ProductVersion != null && this.ProductVersion.IsdiscountNull() == false)
                    {
                        return (this.ProductDetail.price - this.ProductDetail.price * this.ProductVersion.discount / 100)*this.conversionRate;
                    }
                    return this.ProductDetail.price * this.conversionRate;
                }
                else
                {
                    return this.ProductVersion.price * this.conversionRate;
                }
            }
        }

        public double Total
        {
            get { return this.Price * quantity; }
        }

        public ShoppingItem()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static ShoppingItem Load(WishList.WishListDSRow wishList)
        {
            ShoppingItem shoppingItem = new ShoppingItem();
            shoppingItem.product = ShoppingTrolley.Web.Objects.Product.GetProduct(wishList.product_id);
            shoppingItem.DurationInMonths = wishList.duration;
            shoppingItem.Quantity = wishList.quantity;
            shoppingItem.wishListItemId = wishList.wish_list_id;
            if(wishList.Isversion_idNull() == false)
            {
                shoppingItem.ProductVersion = ShoppingTrolley.Web.Objects.Product.GetVersion(wishList.version_id);
            }
            if (wishList.Isproduct_detail_idNull() == false)
            {
                shoppingItem.ProductDetail = ShoppingTrolley.Web.Objects.Product.GetProductDetail(wishList.product_detail_id);
            }
            return shoppingItem;
        }

        private int wishListItemId;
        public int WishListItemId
        {
            get { return wishListItemId; }
            set { wishListItemId = value; }
        }

    }
