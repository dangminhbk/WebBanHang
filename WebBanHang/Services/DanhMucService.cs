using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Services
{
    public class DanhMucService : ServiceBase<DanhMucSanPham>
    {
        public SelectList GetSelectList()
        {
            return new SelectList(db.DanhMucSanPham, "MaDanhMuc", "TenDanhMuc");
        }
    }
}