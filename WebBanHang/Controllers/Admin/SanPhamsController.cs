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
using WebBanHang.Models;

namespace WebBanHang.Controllers.Admin
{
    public class SanPhamsController : Controller
    {
        private WebHoa db = new WebHoa();

        // GET: SanPhams
        public ActionResult Index(int? page, int?pageSize)
        {
            int skip = 0;
            int take = 0;
            int pageCurrent = 1;
            int pageTotal = 1;
            if(page !=null && pageSize != null)
            {
                pageCurrent = (int)page;
                skip = ((int)page - 1) * (int)pageSize;
                take = (int)pageSize;
            }
            else
            {
                skip = 0;
                take= 7;
            }
            var sanPhams = db.SanPhams.Include(s => s.DanhMucSanPham).ToList();
            pageTotal = sanPhams.Count() / take + 1;     
            var sanPhamsTrang = sanPhams.Skip(skip).Take(take);
            ViewBag.pageCurrent = pageCurrent;
            ViewBag.pageTotal = pageTotal;

            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc");
            ViewBag.mauSac = new SelectList(Color.mauCoBan, "tenMau", "tenMau");
            return View(sanPhamsTrang);
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MauSac = Color.mauCoBan;
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,TenSanPham,MoTaSanPham,MauSac,TrongLuong,GiaSanPham,GiaKhuyenMai,KhuyenMai,MaDanhMuc")] SanPham sanPham, HttpPostedFileBase[] anhSP)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in anhSP)
                {
                    if(item.ContentLength >0)
                    {
                        var filename = Path.GetRandomFileName()+Path.GetExtension(item.FileName);
                        var path = Path.Combine(Server.MapPath("~/Uploaded"), filename);
                        var pathDisplay = "/Uploaded/" + filename;
                        item.SaveAs(path);
                        var anhspTemp = new AnhSanPham { DuongDanAnh = pathDisplay };
                        sanPham.AnhSanPhams.Add(anhspTemp);
                    }
                }
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MauSac = Color.mauCoBan;
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc");
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.anhSP = sanPham.AnhSanPhams.ToList();
            ViewBag.MauSac = Color.mauCoBan;
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc");
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,TenSanPham,MoTaSanPham,MauSac,TrongLuong,GiaSanPham,GiaKhuyenMai,KhuyenMai,MaDanhMuc")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MauSac = Color.mauCoBan;
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc");
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
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
            SanPham sanPham = db.SanPhams.Find(id);
            sanPham.AnhSanPhams.Clear();
            db.SanPhams.Remove(sanPham);
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
