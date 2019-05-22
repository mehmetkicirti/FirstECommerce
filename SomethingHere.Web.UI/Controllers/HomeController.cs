using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SomethingHere.DataAccess;
using SomethingHere.Service;
using SomethingHere.Utility;
using SomethingHere.Web.UI.Models;

namespace SomethingHere.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index1()
        {
            ProductService productService = new ProductService();
            ViewBag.Latest = productService.LatestProducts();
            CookieManager manager = new CookieManager();
            ViewBag.cookie = manager.GetCookieProducts();
            CartManager Cartmanager = new CartManager();
            return View();
        }
        public PartialViewResult BrandList()
        {
            BrandService brand = new BrandService();
            ViewBag.List = brand.SelectAll();
            return PartialView();
        }
        public PartialViewResult CategoryList()
        {
            CategoryService category = new CategoryService();
            ViewBag.List = category.SelectAll();
            return PartialView();
        }
        public ActionResult ProductDetail(int id)
        {
            ProductService product = new ProductService();
            Product urun= product.SelectByID(id);
            CookieManager manager = new CookieManager();
            manager.SendCookie(id);
            return View(urun);
        }
        public ActionResult BrandProducts(int brandId)
        {
            ProductService brandService = new ProductService();
            ViewBag.List = brandService.SelectByBrandId(brandId);

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCheck(LoginCheckDTO login)
        {
            LoginUserService userService = new LoginUserService();
            LoginUser user = userService.CheckLogin(login.UserName, login.Password);
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                Session[KeyManager.LoginSessionKey] = user;//Session dolu gidiyor..
                return RedirectToAction("Index1", "Home");
            }
        }
    }
}