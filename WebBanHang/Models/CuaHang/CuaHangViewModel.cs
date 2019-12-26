using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models.Page;
namespace WebBanHang.Models.CuaHang
{
    public class CuaHangViewModel
    {
        public IEnumerable<NhaHang> NhaHangs;
        public PageInfo PageInfo { get; set; }
    }
}