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
        private WebHoa db = new WebHoa();
        public ActionResult Index()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart != null)
            {
                return View(cart.Details);
            }
            return View(new List<CartDetail>());
        }
        public ActionResult Add(int id)
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart ==null)
            {
                cart = new Cart();
            }
            var sanPhams = db.SanPhams.Find(id);
            cart.AddCart(id, sanPhams.TenSanPham, (int)sanPhams.GiaSanPham);
            Session["Cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}