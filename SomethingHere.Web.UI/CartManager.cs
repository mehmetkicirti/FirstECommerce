using SomethingHere.DataAccess;
using SomethingHere.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomethingHere.Web.UI
{
    public class CartManager
    {
        private List<Product> _products;
        public string Add(int Productid)
        {
            ProductService productService = new ProductService();
            Product product = productService.SelectByID(Productid);
            if (HttpContext.Current.Session["Cart"] == null)
            {
                //sepet yok
                _products = new List<Product>();
                _products.Add(product);
                product.Quantity = 1;
                HttpContext.Current.Session["Cart"] = _products;
                return "Success";
            }
            else
            {
                _products = HttpContext.Current.Session["Cart"] as List<Product>;//cast islemi gerekiyor liste olarak aldık
                //sepet var
                Product hasProduct = _products.SingleOrDefault(p => p.ID == Productid);
                if (hasProduct == null)
                {
                    product.Quantity = 1;
                    //ürün sepette yok ise
                    _products.Add(product);
                    HttpContext.Current.Session["Cart"] = _products;
                    return "Success";
                }
                else
                {
                    hasProduct.Quantity++;
                    if (hasProduct.Quantity > hasProduct.Stock)
                    {
                        hasProduct.Quantity--;
                        return "Stock is not enough";
                    }
                    HttpContext.Current.Session["Cart"] = _products;
                    return "Success";
                }

            }
        }
        //Get Cart İtem Count
        public int ItemCount()//sessionlar belli süre sonra ucabilir ondan dolayı herzaman null mu degilmi kontrol ettik..
        {
            int itemCount = 0;
            if (HttpContext.Current.Session["Cart"] == null)
            {
                return itemCount;
            }
            else
            {
                _products = HttpContext.Current.Session["Cart"] as List<Product>;
                itemCount = _products.Count;
                return itemCount;
            }
            
        }
        //get cart item total price
         public decimal TotalCartPrice()
        {
            decimal totalPrice = 0;
            if (HttpContext.Current.Session["Cart"] == null)
            {
                return totalPrice;
            }
            else
            {
                _products = HttpContext.Current.Session["Cart"] as List<Product>;
                foreach  (Product product in _products)
                {
                    totalPrice += (decimal)(product.Quantity * product.Price);
                }
                return totalPrice;
            }
        }
        public  List<Product> GetCartItems()
        {
            List<Product> products = new List<Product>();
            if (HttpContext.Current.Session["Cart"] == null)
            {
                return products;
            }
            else
            {
                products = HttpContext.Current.Session["Cart"] as List<Product>;
                return products;
            }
        }
        public bool ChangeProductState(int productID,string process)
        {
            bool state = true;
            _products=HttpContext.Current.Session["Cart"] as List<Product>;
            switch (process)
            {
                case "minus":
                   Product product= _products.FirstOrDefault(p => p.ID == productID);
                    product.Quantity--;
                    if (product.Quantity == 0)
                    {
                        _products.Remove(product);
                        state = false;
                    }
                    break;
                case "plus":
                    _products.FirstOrDefault(p => p.ID == productID).Quantity++;
                    break;
                case "remove":
                    Product removeProduct = _products.FirstOrDefault(p => p.ID == productID);
                    _products.Remove(removeProduct);
                    state = false;
                    break;

            }
            HttpContext.Current.Session["Cart"] = _products;
            return state;
        }
    }
}