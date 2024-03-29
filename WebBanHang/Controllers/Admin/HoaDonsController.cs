﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers.Admin
{
    [Authorize]
    public class HoaDonsController : Controller
    {
        private WebHoa db = new WebHoa();

        // GET: HoaDons
        public ActionResult Index(int? page, int? pageSize)
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
                take = 7;
            }

            var sanPhams = db.HoaDons.ToList();
            pageTotal = sanPhams.Count() / take + 1;
            var sanPhamsTrang = sanPhams.Skip(skip).Take(take);
            ViewBag.pageCurrent = pageCurrent;
            ViewBag.pageTotal = pageTotal;
            return View(sanPhamsTrang);
        }

        // GET: HoaDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: HoaDons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,NgaySuatHoaDon,ThanhToan,DiaChiNguoiNhan,SoDienThoai,DonViGiaoHang,MaVanDon,TongTien,TenKhachHang")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                Cart cart = (Cart)Session["Cart"];
                int TongTien = 0;
                foreach (var item in cart.Details)
                {
                    var chiTiet = new SanPham_HoaDon {
                        SoLuong = item.Amount,
                        MaSanPham = item.Id,
                        Gia = item.Price
                    };
                    TongTien += item.Price * item.Amount;
                    hoaDon.SanPham_HoaDon.Add(chiTiet);
                }
                hoaDon.TongTien = TongTien;
                hoaDon.ThanhToan = "Chưa thanh toán";
                hoaDon.DonViGiaoHang = "Chưa có";
                hoaDon.MaVanDon = "Chưa có";
                hoaDon.NgaySuatHoaDon = DateTime.Now;
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hoaDon);
        }

        // GET: HoaDons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,NgaySuatHoaDon,ThanhToan,DiaChiNguoiNhan,SoDienThoai,DonViGiaoHang,MaVanDon,TongTien,TenKhachHang")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
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
