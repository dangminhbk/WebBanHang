using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers.KhachHang_React
{
    public class KhachHangReactController : Controller
    {
        private WebHoaDBContext db = new WebHoaDBContext();
        // GET: KhachHangReact
        public ActionResult CuaHang()
        {
            return View();
        }
        public ActionResult AsidePartial()
        {
            var DanhMucSP = db.DanhMucSanPham.ToList();
            return PartialView(DanhMucSP);
        }
    }
}