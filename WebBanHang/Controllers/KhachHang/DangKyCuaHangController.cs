using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Services;

namespace WebBanHang.Controllers.KhachHang
{
    public class DangKyCuaHangController : Controller
    {
        private WebHoaDBContext db = new WebHoaDBContext();

        SanPhamService sanPhamService;
        DanhMucService danhMucService;
        UserService userService;
        NhaHangService nhaHangService;
        public DangKyCuaHangController()
        {
            sanPhamService = new SanPhamService();
            userService = new UserService();
            danhMucService = new DanhMucService();
            nhaHangService = new NhaHangService();
        }
        // GET: DangKyCuaHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DangKyCuaHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenCuaHang,ThongTinCuaHang,TenChuCuaHang,DiaChi,SoDienThoai,Email")] CuaHang cuaHang, string TaiKhoan, string Password)
        {
            if (ModelState.IsValid)
            {
                if (TaiKhoan.Trim() != TaiKhoan)
                {
                    return View(cuaHang);
                }
                var tk = userService.GetRepo.Where(s => s.TenDangNhap == TaiKhoan);
                if (tk.Any())
                {
                    return View(cuaHang);
                }
                nhaHangService.ThemCuaHang(cuaHang, new NhanVien {TenDangNhap = TaiKhoan, MatKhau = Password });
                return RedirectToAction("Index", "TrangChu");
            }

            return View(cuaHang);
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
