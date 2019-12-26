using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Models.CuaHang;
namespace WebBanHang.Controllers
{
    public class TrangChuController : Controller
    {
        WebHoa db = new WebHoa();
        int pageSize = 6;
        // GET: TrangChu
        public ActionResult Index(int page = 1)
        {
            var danhSachNhaHang = db.NhaHangs.OrderBy(nh => nh.MaNhaHang).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            CuaHangViewModel cuaHangVM = new CuaHangViewModel
            {
                NhaHangs = danhSachNhaHang,
                PageInfo = new Models.Page.PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = db.NhaHangs.Count()
                }
            };
            return View(cuaHangVM);
        }
        public ActionResult Index2()
        {
            return View();
        }
    }
}