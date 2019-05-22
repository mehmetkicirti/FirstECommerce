using SomethingHere.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SomethingHere.Utility;

namespace SomethingHere.Web.UI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [HttpPost]//manager kur response kur jsondan cagır..
        public ActionResult AddToCart(AddToCartRequest request)
        {
            CartManager manager = new CartManager();
            string message = manager.Add(request.ProductID);
            AddToCartResponse response = new AddToCartResponse();
            response.Message = message;
            return Json(response);
        }
        //jqueryy ile gelen istekleri post belirledik
           [HttpPost]
           public ActionResult CartInfo()
        {
            CartManager manager = new CartManager();
            CartInfoResponse cartInfoResponse = new CartInfoResponse();
            cartInfoResponse.ItemCount = manager.ItemCount();
            cartInfoResponse.TotalPrice = manager.TotalCartPrice();
            return Json(cartInfoResponse);
        }
        public ActionResult CartDetail()
        {
            CartManager manager = new CartManager();
            ViewBag.List = manager.GetCartItems();
            return View();
        }
        [HttpPost]
        public ActionResult ProductProcess(ProductProcessRequest request)
        {
            CartManager manager = new CartManager();
            bool state=manager.ChangeProductState(request.ProductID, request.ProcessName);
            return Json(state);
        }
        public ActionResult Buy()
        {
            //otel de oda vardır elma olamaz ama kullanıcı login mi degilmi bu key ile kontrol ederiz
            if (Session[KeyManager.LoginSessionKey] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
    }
}