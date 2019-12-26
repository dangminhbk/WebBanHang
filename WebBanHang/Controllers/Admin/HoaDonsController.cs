using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBanHang.Models;
using WebBanHang.Services;

namespace WebBanHang.Controllers.Admin
{
    [Authorize]
    public class HoaDonsController : Controller
    {
        SanPhamService sanPhamService;
        DanhMucService danhMucService;
        UserService userService;
        NhaHangService nhaHangService;
        HoaDonService hoaDonService;
        // GET: HoaDons
        public HoaDonsController()
        {
            sanPhamService = new SanPhamService();
            userService = new UserService();
            danhMucService = new DanhMucService();
            nhaHangService = new NhaHangService();
            hoaDonService = new HoaDonService();
        }
        public ActionResult Index(int page = 0, int pageSize = 5)
        {
            this.setRestaurantInfo();
            var hoaDons = hoaDonService.GetAll(page, pageSize, this.RestaurantID);
            var hoadonTrang = hoaDons.items;
            ViewBag.pageCurrent = hoaDons.currentPage;
            ViewBag.pageTotal = hoaDons.totalPage;
            return View(hoadonTrang);
        }

        // GET: HoaDons/Details/5
        public ActionResult Details(int? id)
        {
            this.setRestaurantInfo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = hoaDonService.Detail(id.Value);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: HoaDons/Create
        public ActionResult Create()
        {
            this.setRestaurantInfo();
            return View();
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaHoaDon,NgaySuatHoaDon,ThanhToan,DiaChiNguoiNhan,SoDienThoai,DonViGiaoHang,MaVanDon,TongTien,TenKhachHang")] HoaDon hoaDon)
        //{
        //    this.setRestaurantInfo();
        //    if (ModelState.IsValid)
        //    {
        //        Cart cart = (Cart)Session["Cart"];
        //        int TongTien = 0;
        //        foreach (var item in cart.Details)
        //        {
        //            var chiTiet = new SanPham_HoaDon
        //            {
        //                SoLuong = item.Amount,
        //                MaSanPham = item.Id,
        //                Gia = item.Price
        //            };
        //            TongTien += item.Price * item.Amount;
        //            hoaDon.SanPham_HoaDon.Add(chiTiet);
        //        }
        //        hoaDon.TongTien = TongTien;
        //        hoaDon.ThanhToan = "Chưa thanh toán";
        //        hoaDon.DonViGiaoHang = "Chưa có";
        //        hoaDon.MaVanDon = "Chưa có";
        //        hoaDon.NgaySuatHoaDon = DateTime.Now;
        //        db.HoaDons.Add(hoaDon);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(hoaDon);
        //}

        // GET: HoaDons/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    this.setRestaurantInfo();
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HoaDon hoaDon = db.HoaDons.Find(id);
        //    if (hoaDon == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(hoaDon);
        //}

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MaHoaDon,NgaySuatHoaDon,ThanhToan,DiaChiNguoiNhan,SoDienThoai,DonViGiaoHang,MaVanDon,TongTien,TenKhachHang")] HoaDon hoaDon)
        //{
        //    this.setRestaurantInfo();
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(hoaDon).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(hoaDon);
        //}

        private void setRestaurantInfo()
        {
            ViewBag.RestaurantName = nhaHangService.getNhaHangInfo(RestaurantID).TenCuaHang;
        }
        private int RestaurantID
        {
            get
            {
                HttpCookie authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName]; //Get the cookie by it's name
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
                var userId = Convert.ToInt32(ticket.Name); //You have the UserName!
                return userService.GetUser(userId).MaNhaHang.Value;
            }
        }
    }
}
