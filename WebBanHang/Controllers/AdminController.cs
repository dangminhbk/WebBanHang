using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if(Session["isLog"] == null ||!(bool)Session["isLog"])
            {
                return RedirectToAction("Index", "DangNhap", new { fail = true });
            }
            else
            {
                return View();
            }
        }
    }
}