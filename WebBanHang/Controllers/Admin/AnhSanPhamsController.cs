using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers.Admin
{
    [Authorize]
    public class AnhSanPhamsController : Controller
    {
        private WebHoa db = new WebHoa();

        // GET: AnhSanPhams
        public ActionResult Index()
        {
            var anhSanPhams = db.AnhSanPhams.Include(a => a.SanPham);
            return View(anhSanPhams.ToList());
        }

        // GET: AnhSanPhams/Details/5
        public ActionResult Details(int? masp, string duongdan)
        {
            if (masp == null || duongdan == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSanPham anhSanPham = db.AnhSanPhams.Find(masp, duongdan);
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
        public ActionResult Edit(int? masp, string duongdan)
        {
            if (masp == null || duongdan == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSanPham anhSanPham = db.AnhSanPhams.Find(masp, duongdan);
            if (anhSanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", anhSanPham.MaSanPham);
            return View(anhSanPham);
        }
        public ActionResult EditMini(int? masp, string duongdan)
        {
            if (masp == null || duongdan == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSanPham anhSanPham = db.AnhSanPhams.Find(masp, duongdan);
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
        public ActionResult Edit([Bind(Include = "MaSanPham,DuongDanAnh")] AnhSanPham anhSanPham, HttpPostedFileBase anhMoi)
        {
            
            if (ModelState.IsValid)
            {
                if(anhMoi!=null && anhMoi.ContentLength >0 )
                {
                    var filename = Path.GetRandomFileName() + Path.GetExtension(anhMoi.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploaded"), filename);
                    var pathDisplay = "/Uploaded/" + filename;
                    anhMoi.SaveAs(path);

                    AnhSanPham anhNew = new AnhSanPham { DuongDanAnh = pathDisplay, MaSanPham = anhSanPham.MaSanPham };

                    var anhCu = db.AnhSanPhams.Find(anhSanPham.MaSanPham, anhSanPham.DuongDanAnh);
                    db.AnhSanPhams.Remove(anhCu);
                    db.AnhSanPhams.Add(anhNew);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", anhSanPham.MaSanPham);
            return View(anhSanPham);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMini([Bind(Include = "MaSanPham,DuongDanAnh")] AnhSanPham anhSanPham, HttpPostedFileBase anhMoi)
        {

            if (ModelState.IsValid)
            {
                if (anhMoi != null && anhMoi.ContentLength > 0)
                {
                    var filename = Path.GetRandomFileName() + Path.GetExtension(anhMoi.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploaded"), filename);
                    var pathDisplay = "/Uploaded/" + filename;
                    anhMoi.SaveAs(path);

                    AnhSanPham anhNew = new AnhSanPham { DuongDanAnh = pathDisplay, MaSanPham = anhSanPham.MaSanPham };

                    var anhCu = db.AnhSanPhams.Find(anhSanPham.MaSanPham, anhSanPham.DuongDanAnh);
                    db.AnhSanPhams.Remove(anhCu);
                    db.AnhSanPhams.Add(anhNew);
                    db.SaveChanges();
                }
                return View("Blank");
            }
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", anhSanPham.MaSanPham);
            return View("EditMini",anhSanPham);
        }
        // GET: AnhSanPhams/Delete/5
        public ActionResult Delete(int? masp, string duongdan)
        {
            if (masp == null || duongdan == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSanPham anhSanPham = db.AnhSanPhams.Find(masp,duongdan);
            if (anhSanPham == null)
            {
                return HttpNotFound();
            }
            return View(anhSanPham);
        }

        // POST: AnhSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? masp, string duongdan)
        {
            AnhSanPham anhSanPham = db.AnhSanPhams.Find(masp, duongdan);
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
