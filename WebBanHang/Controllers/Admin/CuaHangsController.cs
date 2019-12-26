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
    public class CuaHangsController : Controller
    {
        SanPhamService sanPhamService;
        DanhMucService danhMucService;
        UserService userService;
        NhaHangService nhaHangService;
        private WebHoaDBContext db = new WebHoaDBContext();

        // GET: CuaHangs
        public CuaHangsController()
        {
            sanPhamService = new SanPhamService();
            userService = new UserService();
            danhMucService = new DanhMucService();
            nhaHangService = new NhaHangService();
        }
        public ActionResult Index()
        {
            return View(db.CuaHang.ToList());
        }

        // GET: CuaHangs/Details/5
        public ActionResult Details()
        {
            this.setRestaurantInfo();
            CuaHang cuaHang = nhaHangService.Detail(RestaurantID);
            if (cuaHang == null)
            {
                return HttpNotFound();
            }
            return View(cuaHang);
        }
        // GET: CuaHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            CuaHang cuaHang = nhaHangService.Detail(RestaurantID);
            if (cuaHang == null)
            {
                return HttpNotFound();
            }
            return View(cuaHang);
        }

        // POST: CuaHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenCuaHang,ThongTinCuaHang,TenChuCuaHang,DiaChi,SoDienThoai,Email")] CuaHang cuaHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuaHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
