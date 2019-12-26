using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Services;

namespace WebBanHang.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        UserService userService;
        NhaHangService nhaHangService;
        public AdminController()
        {
            userService = new UserService();
            nhaHangService = new NhaHangService();
        }
        public ActionResult Index()
        {
            ViewBag.TongSoSanPham = 100000;
            ViewBag.TongSoHoaDon = 100000;
            return View();
        }
        private void setRestaurantInfo()
        {
            ViewBag.RestaurantName = nhaHangService.getNhaHangInfo(RestaurantID).TenCuaHang;
        }
        private int RestaurantID
        {
            get
            {
                var userId = Convert.ToInt32(Request.Cookies.Get("UserId").Value);
                return userService.GetUser(userId).MaNhaHang.Value;
            }
        }
    }
}