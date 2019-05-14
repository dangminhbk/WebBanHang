using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebBanHang.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
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
            if (isValidUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
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
        private bool isValidUser(string username, string password)
        {
            using (var db = new WebBanHang.Models.WebHoa())
            {
                return db.NhanViens.Any(u => u.TenDangNhap == username && u.MatKhau == password);
            }
        }
    }
}