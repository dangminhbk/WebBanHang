using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBanHang.Models;
using WebBanHang.Services;
using WebBanHang.Services.Dto;

namespace WebBanHang.Controllers.Admin
{
    [Authorize]
    public class SanPhamsController : Controller
    {
        SanPhamService sanPhamService;
        DanhMucService danhMucService;
        UserService userService;
        NhaHangService nhaHangService;
        public SanPhamsController()
        {
            sanPhamService = new SanPhamService();
            userService = new UserService();
            danhMucService = new DanhMucService();
            nhaHangService = new NhaHangService();
        }
        // GET: SanPhams
        public ActionResult Index(int page = 0, int pageSize = 5)
        {
            // get cookie
            this.setRestaurantInfo();
            var sanPhamModel = sanPhamService.GetAll(page,pageSize,RestaurantID);
            ViewBag.pageCurrent = sanPhamModel.currentPage;
            ViewBag.pageTotal = sanPhamModel.totalPage;
            ViewBag.MaDanhMuc = danhMucService.GetSelectList();
            return View(sanPhamModel.items);
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            this.setRestaurantInfo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sanPham = sanPhamService.DetailWithAnh(id.Value);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            this.setRestaurantInfo();
            ViewBag.MaDanhMuc = danhMucService.GetSelectList();
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,TenSanPham,MoTaSanPham,GiaSanPham,GiaKhuyenMai,KhuyenMai,MaDanhMuc")] SanPham sanPham, HttpPostedFileBase[] anhSP)
        {
            this.setRestaurantInfo();
            if (ModelState.IsValid)
            {
                sanPhamService.Create(sanPham, anhSP, this.Server);
                return RedirectToAction("Index");
            }
            ViewBag.MaDanhMuc = danhMucService.GetSelectList();
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            this.setRestaurantInfo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPhamDetailDto sanPham = sanPhamService.DetailWithAnh(id.Value);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.anhSP = sanPham.anhSanPhams;
            ViewBag.MaDanhMuc = danhMucService.GetSelectList();
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5

        // GET: SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            this.setRestaurantInfo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = sanPhamService.Detail(id.Value);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sanPhamService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        private void setRestaurantInfo()
        {
            ViewBag.RestaurantName = nhaHangService.getNhaHangInfo(RestaurantID).TenCuaHang;
        }
        private int RestaurantID { 
            get {
                HttpCookie authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName]; //Get the cookie by it's name
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
                var userId = Convert.ToInt32(ticket.Name); //You have the UserName!
                return userService.GetUser(userId).MaNhaHang.Value;
            } 
        }
    }
}
