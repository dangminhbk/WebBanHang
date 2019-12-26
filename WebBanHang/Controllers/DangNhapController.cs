using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        private const string USER_ID_COOKIE_TYPE = "UserID";
        public ActionResult Index(bool? fail)
        {
            if(fail !=null&& fail== true)
            {
                ViewBag.fail = true;
            }
            return View();
        }
        public ActionResult Login(string username, string password)
        {
            var loggerUser = GetLoginInfo(username, password);
            if (loggerUser != null)
            {
                    FormsAuthentication.SetAuthCookie(loggerUser.MaNhanVien.ToString(), false);
                    return RedirectToAction("Index", "Admin");
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return RedirectToAction("Index",new { fail = true });
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "TrangChu");
        }
        private NhanVien GetLoginInfo(string username, string password)
        {
            using (var db = new WebBanHang.Models.WebHoaDBContext())
            {
                return db.NhanVien.Where(u => u.TenDangNhap == username && u.MatKhau == password).FirstOrDefault();
            }
        }
    }
}