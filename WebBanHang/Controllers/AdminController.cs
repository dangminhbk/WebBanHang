using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        private WebHoa db = new WebHoa();
        public ActionResult Index()
        {
            var TongSoSanPham = db.SanPhams.Count();
            var TongSoHoaDon = db.HoaDons.Count();
            ViewBag.TongSoSanPham = TongSoSanPham;
            ViewBag.TongSoHoaDon = TongSoHoaDon;
            return View();
        }
    }
}