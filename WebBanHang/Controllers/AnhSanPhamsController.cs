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
    public class AnhSanPhamsController : Controller
    {
        private CuaHangHoaEntities db = new CuaHangHoaEntities();

        // GET: AnhSanPhams
        public ActionResult Index()
        {
            var anhSanPhams = db.AnhSanPhams.Include(a => a.SanPham);
            return View(anhSanPhams.ToList());
        }

        // GET: AnhSanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSanPham anhSanPham = db.AnhSanPhams.Find(id);
            if (anhSanPham == null)
            {
                return HttpNotFound();
            }
            return View(anhSanPham);
        }

        // GET: AnhSanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: AnhSanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,DuongDanAnh")] AnhSanPham anhSanPham)
        {
            if (ModelState.IsValid)
            {
                db.AnhSanPhams.Add(anhSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", anhSanPham.MaSanPham);
            return View(anhSanPham);
        }

        // GET: AnhSanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSanPham anhSanPham = db.AnhSanPhams.Find(id);
            if (anhSanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", anhSanPham.MaSanPham);
            return View(anhSanPham);
        }

        // POST: AnhSanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,DuongDanAnh")] AnhSanPham anhSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anhSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", anhSanPham.MaSanPham);
            return View(anhSanPham);
        }

        // GET: AnhSanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSanPham anhSanPham = db.AnhSanPhams.Find(id);
            if (anhSanPham == null)
            {
                return HttpNotFound();
            }
            return View(anhSanPham);
        }

        // POST: AnhSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnhSanPham anhSanPham = db.AnhSanPhams.Find(id);
            db.AnhSanPhams.Remove(anhSanPham);
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
