using SomethingHere.DataAccess;
using SomethingHere.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SomethingHere.Web.UI
{
    public class CookieProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
    }
    public class CookieManager
    {
        public void SendCookie(int productId)
        {
            CookieProduct cproduct = new CookieProduct();
            ProductService service = new ProductService();
            Product product = service.SelectByID(productId);
            cproduct.ID = product.ID;
            cproduct.Name = product.ProductName;
            cproduct.BrandName = product.Brand.Name;
            cproduct.ImagePath = product.ProductImage.FirstOrDefault(i => i.IsActive == true).ImagePath;
            cproduct.Price = (decimal)product.Price;
            if (HttpContext.Current.Request.Cookies["REVIEWS"] != null)
            {
                //Cookie varsa
                HttpCookie cookie = HttpContext.Current.Request.Cookies["REVIEWS"];
                string json = cookie["products"];
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<CookieProduct> products = serializer.Deserialize<List<CookieProduct>>(json);
                cookie.Values.Clear();
                if (products.FirstOrDefault(p => p.ID == cproduct.ID) == null)
                {
                    if (products.Count == 3)
                    {
                        //üc tane varsa fifo yapılıcak
                        products.Remove(products[0]);
                    }
                    products.Add(cproduct);
                    json = serializer.Serialize(products);
                    cookie.Values.Add("products", json);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
            else
            {
                //cookie yok
                List<CookieProduct> products = new List<CookieProduct>();
                products.Add(cproduct);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string json = serializer.Serialize(products);
                HttpCookie cookie = new HttpCookie("REVIEWS");
                cookie.Expires = DateTime.Now.AddDays(10);
                cookie.Secure = false;//default
                cookie.Values.Add("products", json);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        public List<CookieProduct> GetCookieProducts()
        {
            List<CookieProduct> products = new List<CookieProduct>();
            if (HttpContext.Current.Request.Cookies["REVIEWS"] == null)
            {
                return products;
            }
            HttpCookie cookie = HttpContext.Current.Request.Cookies["REVIEWS"];
            string json = cookie["products"];
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            products = serializer.Deserialize<List<CookieProduct>>(json);
            return products;
        }
    }
}