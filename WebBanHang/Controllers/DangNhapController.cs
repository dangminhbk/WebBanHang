using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult Index( bool fail=false)
        {
            if(fail)
            {
                ViewBag.text = "Đăng nhập không thành công";
            }
            else
            {
                ViewBag.text = "Đăng nhập";
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if(username =="admin" && password == "123")
            {
                Session["islog"] = true;
                
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}