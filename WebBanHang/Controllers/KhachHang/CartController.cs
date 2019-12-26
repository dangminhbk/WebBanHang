using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers.KhachHang
{
    public class CartController : Controller
    {
        // GET: Cart
        private WebHoaDBContext db = new WebHoaDBContext();
        public ActionResult Index()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart != null)
            {
                return View(cart.Details);
            }
            return View(new List<CartDetail>());
        }
        public ActionResult Add(int id)
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
            }
            var sanPhams = db.SanPham.Find(id);
            var gia = 0;
            if ((bool)sanPhams.KhuyenMai)
            {
                gia = (int)sanPhams.GiaKhuyenMai;
            }
            else
            {
                gia = (int)sanPhams.GiaSanPham;
            }
            cart.AddCart(id, sanPhams.TenSanPham, gia);
            Session["Cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Update(int id, int amount)
        {
            Cart cart = (Cart)Session["Cart"];
            cart.UpdateAmount(id, amount);
            return View("Index", cart.Details);
        }
    }
}