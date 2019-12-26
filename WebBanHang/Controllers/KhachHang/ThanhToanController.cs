using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Services;

namespace WebBanHang.Controllers.KhachHang
{
    public class ThanhToanController : Controller
    {
        //GET: ThanhToan
        ThanhToanService thanhToanService;
        public ThanhToanController()
        {
            thanhToanService = new ThanhToanService();
        }
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
                this.thanhToanService.ThanhToan(hoaDon, cart);           
                return RedirectToAction("Index", "TrangChu");
            }
            return View("Index");
        }
    }
}