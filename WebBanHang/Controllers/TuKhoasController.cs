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
    public class TuKhoasController : Controller
    {
        private CuaHangHoaEntities db = new CuaHangHoaEntities();

        // GET: TuKhoas
        public ActionResult Index()
        {
            return View(db.TuKhoas.ToList());
        }

        // GET: TuKhoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuKhoa tuKhoa = db.TuKhoas.Find(id);
            if (tuKhoa == null)
            {
                return HttpNotFound();
            }
            return View(tuKhoa);
        }

        // GET: TuKhoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TuKhoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTuKhoa,TuKhoa1")] TuKhoa tuKhoa)
        {
            if (ModelState.IsValid)
            {
                db.TuKhoas.Add(tuKhoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tuKhoa);
        }

        // GET: TuKhoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuKhoa tuKhoa = db.TuKhoas.Find(id);
            if (tuKhoa == null)
            {
                return HttpNotFound();
            }
            return View(tuKhoa);
        }

        // POST: TuKhoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTuKhoa,TuKhoa1")] TuKhoa tuKhoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuKhoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tuKhoa);
        }

        // GET: TuKhoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuKhoa tuKhoa = db.TuKhoas.Find(id);
            if (tuKhoa == null)
            {
                return HttpNotFound();
            }
            return View(tuKhoa);
        }

        // POST: TuKhoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TuKhoa tuKhoa = db.TuKhoas.Find(id);
            db.TuKhoas.Remove(tuKhoa);
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
