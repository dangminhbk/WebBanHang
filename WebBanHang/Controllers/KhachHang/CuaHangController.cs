using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers.KhachHang
{
    public class CuaHangController : Controller
    {
        // GET: CuaHang
        private WebHoa db = new WebHoa();
        public ActionResult Index(int? page, int? pageSize , int?danhMuc)
        {
            int skip = 0;
            int take = 0;
            int pageCurrent = 1;
            int pageTotal = 1;
            if (page != null && pageSize != null)
            {
                pageCurrent = (int)page;
                skip = ((int)page - 1) * (int)pageSize;
                take = (int)pageSize;
            }
            else
            {
                skip = 0;
                take = 9;
            }
            var sanPhams = db.SanPhams.ToList();
            if (danhMuc!= null)
            {
                sanPhams = db.DanhMucSanPhams.Find(danhMuc).SanPhams.ToList();
            }
            pageTotal = sanPhams.Count() / take + 1;
            var sanPhamsTrang = sanPhams.Skip(skip).Take(take).ToList();
            ViewBag.pageCurrent = pageCurrent;
            ViewBag.pageTotal = pageTotal;
            return View(sanPhamsTrang);
        }
        public ActionResult AsidePartial()
        {
            var DanhMucSP = db.DanhMucSanPhams.ToList();
            return PartialView(DanhMucSP);
        }
    }
}