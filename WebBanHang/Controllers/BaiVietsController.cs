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
    public class BaiVietsController : Controller
    {
        private CuaHangHoaEntities db = new CuaHangHoaEntities();

        // GET: BaiViets
        public ActionResult Index()
        {
            var baiViets = db.BaiViets.Include(b => b.DanhMucBaiViet);
            return View(baiViets.ToList());
        }

        // GET: BaiViets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // GET: BaiViets/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhMucBaiViet = new SelectList(db.DanhMucBaiViets, "MaDanhMucBaiViet", "TenDanhMucBaiViet");
            return View();
        }

        // POST: BaiViets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBaiViet,TenBaiViet,NoiDungBaiViet,NgayViet,MaDanhMucBaiViet")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                db.BaiViets.Add(baiViet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDanhMucBaiViet = new SelectList(db.DanhMucBaiViets, "MaDanhMucBaiViet", "TenDanhMucBaiViet", baiViet.MaDanhMucBaiViet);
            return View(baiViet);
        }

        // GET: BaiViets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhMucBaiViet = new SelectList(db.DanhMucBaiViets, "MaDanhMucBaiViet", "TenDanhMucBaiViet", baiViet.MaDanhMucBaiViet);
            return View(baiViet);
        }

        // POST: BaiViets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBaiViet,TenBaiViet,NoiDungBaiViet,NgayViet,MaDanhMucBaiViet")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiViet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDanhMucBaiViet = new SelectList(db.DanhMucBaiViets, "MaDanhMucBaiViet", "TenDanhMucBaiViet", baiViet.MaDanhMucBaiViet);
            return View(baiViet);
        }

        // GET: BaiViets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // POST: BaiViets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiViet baiViet = db.BaiViets.Find(id);
            db.BaiViets.Remove(baiViet);
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
