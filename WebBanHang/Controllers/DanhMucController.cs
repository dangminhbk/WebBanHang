using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        private CuaHangHoaEntities db = new CuaHangHoaEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AsidePartial()
        {
            var DanhMucSP = db.DanhMucSanPhams.ToList();
            return PartialView(DanhMucSP);
        }
        public ActionResult DanhSach( string searchString)
        {
            var danhSach = db.SanPhams.ToList();
            return PartialView(danhSach);
        }
    }
}