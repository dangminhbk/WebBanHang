using System;
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
    public class TinNhansController : Controller
    {
        private WebHoa db = new WebHoa();

        // GET: TinNhans
        public ActionResult Index()
        {
            var tinNhans = db.TinNhans.Include(t => t.KhachHang);
            return View(tinNhans.ToList());
        }

        // GET: TinNhans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinNhan tinNhan = db.TinNhans.Find(id);
            if (tinNhan == null)
            {
                return HttpNotFound();
            }
            return View(tinNhan);
        }

        // GET: TinNhans/Create
        public ActionResult Create()
        {
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang");
            return View();
        }

        // POST: TinNhans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhachHang,TinNhan1")] TinNhan tinNhan)
        {
            if (ModelState.IsValid)
            {
                db.TinNhans.Add(tinNhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", tinNhan.MaKhachHang);
            return View(tinNhan);
        }

        // GET: TinNhans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinNhan tinNhan = db.TinNhans.Find(id);
            if (tinNhan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", tinNhan.MaKhachHang);
            return View(tinNhan);
        }

        // POST: TinNhans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhachHang,TinNhan1")] TinNhan tinNhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tinNhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", tinNhan.MaKhachHang);
            return View(tinNhan);
        }

        // GET: TinNhans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinNhan tinNhan = db.TinNhans.Find(id);
            if (tinNhan == null)
            {
                return HttpNotFound();
            }
            return View(tinNhan);
        }

        // POST: TinNhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TinNhan tinNhan = db.TinNhans.Find(id);
            db.TinNhans.Remove(tinNhan);
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
