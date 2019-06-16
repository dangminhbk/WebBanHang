using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers.KhachHang
{
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        public ActionResult Index()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart != null)
            {
                ViewBag.Cart = cart;
                return View();
            }
            return Redirect("/");
        }
    }
}