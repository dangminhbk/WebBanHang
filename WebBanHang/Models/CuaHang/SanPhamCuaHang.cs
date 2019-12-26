using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models.Page;
namespace WebBanHang.Models.CuaHang
{
    public class SanPhamCuaHang
    {
        public int? MaNhaHang { get; set; }
        public IEnumerable<SanPham> SanPhams;
        public PageInfo PageInfo { get; set; }
    }
}