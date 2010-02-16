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
namespace ShoppingTrolley.Web.Objects
{
    public class ShoppingItem
    {
        private string productLogoUrl;
        public string ProductLogoUrl
        {
            get { return productLogoUrl; }
            set { productLogoUrl = value; }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private string productDescription;
        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; }
        }

        private string imageUrl;
        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
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

        private double total;
        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        private int productId;
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        private string termsUrl;
        public string TermsUrl
        {
            get { return termsUrl; }
            set { termsUrl = value; }
        }
        public ShoppingItem()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
