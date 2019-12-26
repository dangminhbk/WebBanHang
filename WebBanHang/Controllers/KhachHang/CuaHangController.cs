using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Models.CuaHang;
using WebBanHang.Models.Page;
namespace WebBanHang.Controllers.KhachHang
{
    public class CuaHangController : Controller
    {
        int pageSize = 6;
        // GET: CuaHang
        private WebHoa db = new WebHoa();
        public ActionResult Index(int? maNhaHang, int? maDanhMuc, int page = 1)
        {
            IEnumerable<SanPham> sanPhams = db.SanPhams
                   .Where(sp => sp.MaNhaHang == maNhaHang && (!maDanhMuc.HasValue || sp.MaDanhMuc == maDanhMuc.Value))
                   .OrderBy(sp => sp.MaSanPham)
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize);
            System.Diagnostics.Debug.Print("Count: " + db.SanPhams.Where(sp => sp.MaNhaHang == maNhaHang).Count());
            SanPhamCuaHang sanPhamCuaHang = new SanPhamCuaHang
            {
                MaNhaHang = maNhaHang,
                SanPhams = sanPhams,
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = db.SanPhams.Where(sp => sp.MaNhaHang == maNhaHang && (!maDanhMuc.HasValue || sp.MaDanhMuc == maDanhMuc.Value)).Count()
                }
            };
            return View(sanPhamCuaHang);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }
        public ActionResult AsidePartial(int? maNhaHang)
        {
            //var DanhMucSP = db.NhaHang_DanhMucs.Where(nhdm => nhdm.MaNhaHang == maNhaHang).Select(nhdm => nhdm.DanhMucSanPham).ToList();
            var DanhMucSP = db.SanPhams.Where(sp => sp.MaNhaHang == maNhaHang).Select(sp => sp.DanhMucSanPham).Distinct().ToList();
            ViewBag.maNhaHang = maNhaHang;
            return PartialView(DanhMucSP);
        }
    }
}