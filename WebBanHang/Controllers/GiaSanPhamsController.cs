using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class GiaSanPhamsController : Controller
    {
        private CuaHangHoaEntities db = new CuaHangHoaEntities();

        // GET: GiaSanPhams
        public ActionResult Index()
        {
            var giaSanPhams = db.GiaSanPhams.Include(g => g.SanPham);
            return View(giaSanPhams.ToList());
        }

        // GET: GiaSanPhams/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaSanPham giaSanPham = db.GiaSanPhams.Find(id);
            if (giaSanPham == null)
            {
                return HttpNotFound();
            }
            return View(giaSanPham);
        }

        // GET: GiaSanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: GiaSanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NgayBatDau,NgayKetThuc,GiaBanLe,Discount,MaSanPham")] GiaSanPham giaSanPham)
        {
            if (ModelState.IsValid)
            {
                db.GiaSanPhams.Add(giaSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", giaSanPham.MaSanPham);
            return View(giaSanPham);
        }

        // GET: GiaSanPhams/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaSanPham giaSanPham = db.GiaSanPhams.Find(id);
            if (giaSanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", giaSanPham.MaSanPham);
            return View(giaSanPham);
        }

        // POST: GiaSanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NgayBatDau,NgayKetThuc,GiaBanLe,Discount,MaSanPham")] GiaSanPham giaSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giaSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", giaSanPham.MaSanPham);
            return View(giaSanPham);
        }

        // GET: GiaSanPhams/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaSanPham giaSanPham = db.GiaSanPhams.Find(id);
            if (giaSanPham == null)
            {
                return HttpNotFound();
            }
            return View(giaSanPham);
        }

        // POST: GiaSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            GiaSanPham giaSanPham = db.GiaSanPhams.Find(id);
            db.GiaSanPhams.Remove(giaSanPham);
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
