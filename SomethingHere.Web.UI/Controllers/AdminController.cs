using SomethingHere.DataAccess;
using SomethingHere.Service;
using SomethingHere.Utility;
using SomethingHere.Web.UI.Models;
using SomethingHere.Web.UI.ResFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SomethingHere.Web.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session[KeyManager.LoginSessionKey] != null)
            {
                LoginUser user = Session[KeyManager.LoginSessionKey] as LoginUser;
                List<string> managers = RoleManager.GetManagers();
                if (managers.Contains(user.Username))
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index1", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
           
        }public ActionResult ProductManager()
        {
            BrandService brandService = new BrandService();
            ViewBag.Brands = brandService.SelectAll();
            SupplierService supplierService = new SupplierService();
            ViewBag.Supplier = supplierService.SelectAll();
            return View();
        }
        [HttpPost]
        public ActionResult SaveProduct(SaveProductDTO saveProduct)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductService productService = new ProductService();
                    Product product = new Product();
                    product.ProductName = saveProduct.Name;
                    product.BrandID = saveProduct.BrandId;
                    product.CreatedDate = DateTime.Now;
                    product.IsActive = saveProduct.IsActive == "on" ? true : false;
                    product.SupplierID = saveProduct.SupplierId;
                    product.Price = saveProduct.Price;
                    product.Stock = saveProduct.Stock;
                    productService.Insert(product);
                    Session["Message"] = MainResource.ProductSaveMessageSuccess;
                    //resource file kullanabiliriz 
                }
                else
                {
                    List<ModelState> values = ModelState.Values.ToList();
                    string errorMessage = string.Empty;
                    foreach (var item in values)
                    {
                        if (item.Errors.Count > 0)
                        {
                            errorMessage += item.Errors[0].ErrorMessage+"</br>";//html basıcagımız icin html raw kullanmalıyız 
                        }
                        
                    }
                    Session["Message"] = errorMessage;
                }

            }
            catch (Exception e)
            {

                Session["Message"] = MainResource.ProductSaveMessageFailed+e.Message;
            }
            return RedirectToAction("ProductManager");
        }
        public ActionResult ImageManager()
        {
            ProductService productService = new ProductService();
            ViewBag.Products = productService.SelectAll();

            return View();
        }
        public ActionResult SaveImage(SaveImageDTO model)
        {
            //Sadece Dosya tasıması sırasında post ederken forma bir özellikle byte array olarak gönderecegimiz icin enctype= ile bi attribute vermemiz gerekiyor
            return null;
        }
    }
}