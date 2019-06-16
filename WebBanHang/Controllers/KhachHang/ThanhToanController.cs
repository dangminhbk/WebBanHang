using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers.KhachHang
{
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        private WebHoa db = new WebHoa();
        public ActionResult Index()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart != null)
            {
                ViewBag.Cart = cart;
                return View();
            }
            return Redirect("/");
        }
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
                    var chiTiet = new SanPham_HoaDon
                    {
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
                return RedirectToAction("Index","TrangChu");
            }
            return View("Index");
        }
    }
}