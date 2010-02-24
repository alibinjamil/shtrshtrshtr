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

        private byte quantity;
        public byte Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public double Total
        {
            get { return price * quantity * durationInMonths; }
        }

        public ShoppingItem()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
