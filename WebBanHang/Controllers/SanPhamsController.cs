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
    public class SanPhamsController : Controller
    {
        private CuaHangHoaEntities db = new CuaHangHoaEntities();

        // GET: SanPhams
        public ActionResult Index()
        {
            return View(db.SanPhams.ToList());
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Gia
            SanPham sanPham = db.SanPhams.Find(id);
            var GiaTemp = sanPham.GiaSanPhams.ToList().Find(item=>
            {
                DateTimeOffset ngayNow = new DateTimeOffset(DateTime.Now);
                var ngayBatDauTemp = new DateTimeOffset( item.NgayBatDau);
                var ngayKetThucTemp = new DateTimeOffset (item.NgayKetThuc);
                return ngayNow < ngayKetThucTemp && ngayNow > ngayBatDauTemp;
            });
            var GiaDisplay = GiaTemp.GiaBanLe;
            ViewBag.giaSp = GiaDisplay;

            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }   
        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
