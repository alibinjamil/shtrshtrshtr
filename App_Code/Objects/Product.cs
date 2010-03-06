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
/// Summary description for Product
/// </summary>
///                                                                                                                                   
namespace ShoppingTrolley.Web.Objects
{
    public class Product
    {
        public Product()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private Products.ProductEntityRow productDS;
        public Products.ProductEntityRow ProductDS
        {
            get { return productDS; }
            set { productDS = value; }
        }

        private List<Products.ProductVersionEntityRow> versions = new List<Products.ProductVersionEntityRow>();
        public List<Products.ProductVersionEntityRow> Versions
        {
            get { return versions; }
            set { versions = value; }
        }

        private List<Products.ProductDetailEntityRow> mandatoryDetails = new List<Products.ProductDetailEntityRow>();
        public List<Products.ProductDetailEntityRow> MandatoryDetails
        {
            get { return mandatoryDetails; }
            set { mandatoryDetails = value; }
        }

        private List<Products.ProductDetailEntityRow> optionalDetails = new List<Products.ProductDetailEntityRow>();
        public List<Products.ProductDetailEntityRow> OptionalDetails
        {
            get { return optionalDetails; }
            set { optionalDetails = value; }
        }

        public Products.ProductVersionEntityRow GetLoadedVersion(int versionId)
        {
            foreach (Products.ProductVersionEntityRow version in this.versions)
            {
                if (version.version_id == versionId)
                {
                    return version;
                }
            }
            return null;
        }

        public Products.ProductDetailEntityRow GetLoadedProductDetail(int productDetailId)
        {
            foreach (Products.ProductDetailEntityRow productDetail in this.MandatoryDetails)
            {
                if (productDetail.product_detail_id == productDetailId)
                {
                    return productDetail;
                }
            }
            foreach (Products.ProductDetailEntityRow productDetail in this.OptionalDetails)
            {
                if (productDetail.product_detail_id == productDetailId)
                {
                    return productDetail;
                }
            }
            return null;
        }

        public static Product LoadCompleteProduct(int productId)
        {
            ProductsTableAdapters.ProductTableAdapter productTA = new ProductsTableAdapters.ProductTableAdapter();
            IEnumerator<Products.ProductEntityRow> products = productTA.GetProductById(productId).GetEnumerator();
            if (products.MoveNext())
            {
                Product product = new Product();
                product.ProductDS = products.Current;
                ProductsTableAdapters.ProductDetailTableAdapter detailTA = new ProductsTableAdapters.ProductDetailTableAdapter();
                IEnumerator<Products.ProductDetailEntityRow> details = detailTA.GetDetailsByProduct(productId).GetEnumerator();
                double totalPrice = 0;
                while (details.MoveNext())
                {
                    if (details.Current.mandatory)
                    {
                        product.mandatoryDetails.Add(details.Current);
                        totalPrice += details.Current.price;
                    }
                    else
                    {
                        product.optionalDetails.Add(details.Current);
                    }
                }

                ProductsTableAdapters.ProductVersionTableAdapter versionTA = new ProductsTableAdapters.ProductVersionTableAdapter();
                IEnumerator<Products.ProductVersionEntityRow> versions = versionTA.GetVersionByProduct(productId).GetEnumerator();
                while (versions.MoveNext())
                {                    
                    product.versions.Add(versions.Current);
                }
                return product;
            }
            else
            {
                return null;
            }
        }

        public static Products.ProductVersionEntityRow GetVersion(int versionId)
        {
            Products.ProductVersionEntityRow version = null;
            ProductsTableAdapters.ProductVersionTableAdapter ta = new ProductsTableAdapters.ProductVersionTableAdapter();
            IEnumerator<Products.ProductVersionEntityRow> versions = ta.GetVersionById(versionId).GetEnumerator();
            if (versions.MoveNext())
            {
                version = versions.Current;
            }
            return version;
        }

        public static Products.ProductDetailEntityRow GetProductDetail(int productDetailId)
        {
            Products.ProductDetailEntityRow productDetail = null;
            ProductsTableAdapters.ProductDetailTableAdapter ta = new ProductsTableAdapters.ProductDetailTableAdapter();
            IEnumerator<Products.ProductDetailEntityRow> productDetails = ta.GetDetailById(productDetailId).GetEnumerator();
            if (productDetails.MoveNext())
            {
                productDetail = productDetails.Current;
            }
            return productDetail;
        }

        public static Products.ProductEntityRow GetProduct(int productId)
        {
            Products.ProductEntityRow product = null;
            ProductsTableAdapters.ProductTableAdapter ta = new ProductsTableAdapters.ProductTableAdapter();
            IEnumerator<Products.ProductEntityRow> products = ta.GetProductById(productId).GetEnumerator();
            if (products.MoveNext())
            {
                product = products.Current;
            }
            return product;
        }

        public static Products.ExchangeRateRow GetExchangeRate(string country)
        {
            Products.ExchangeRateRow exchangeRate = null;
            
            ProductsTableAdapters.ExchangeRateTableAdapter ta = new ProductsTableAdapters.ExchangeRateTableAdapter();
            IEnumerator<Products.ExchangeRateRow> exchangeRates;
            try
            {
                exchangeRates = ta.GetExchangeRateByCountry(country).GetEnumerator();
                if (exchangeRates.MoveNext())
                {
                    exchangeRate = exchangeRates.Current;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            return exchangeRate;
        }
    }
}