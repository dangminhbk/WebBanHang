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
    public class DanhMucBaiVietsController : Controller
    {
        private CuaHangHoaEntities db = new CuaHangHoaEntities();

        // GET: DanhMucBaiViets
        public ActionResult Index()
        {
            return View(db.DanhMucBaiViets.ToList());
        }

        // GET: DanhMucBaiViets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucBaiViet danhMucBaiViet = db.DanhMucBaiViets.Find(id);
            if (danhMucBaiViet == null)
            {
                return HttpNotFound();
            }
            return View(danhMucBaiViet);
        }

        // GET: DanhMucBaiViets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMucBaiViets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDanhMucBaiViet,TenDanhMucBaiViet")] DanhMucBaiViet danhMucBaiViet)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucBaiViets.Add(danhMucBaiViet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhMucBaiViet);
        }

        // GET: DanhMucBaiViets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucBaiViet danhMucBaiViet = db.DanhMucBaiViets.Find(id);
            if (danhMucBaiViet == null)
            {
                return HttpNotFound();
            }
            return View(danhMucBaiViet);
        }

        // POST: DanhMucBaiViets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDanhMucBaiViet,TenDanhMucBaiViet")] DanhMucBaiViet danhMucBaiViet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMucBaiViet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMucBaiViet);
        }

        // GET: DanhMucBaiViets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucBaiViet danhMucBaiViet = db.DanhMucBaiViets.Find(id);
            if (danhMucBaiViet == null)
            {
                return HttpNotFound();
            }
            return View(danhMucBaiViet);
        }

        // POST: DanhMucBaiViets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMucBaiViet danhMucBaiViet = db.DanhMucBaiViets.Find(id);
            db.DanhMucBaiViets.Remove(danhMucBaiViet);
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
