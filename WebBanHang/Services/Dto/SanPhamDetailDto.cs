using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models;

namespace WebBanHang.Services.Dto
{
    public class SanPhamDetailDto
    {
        public SanPham sanPham { get; set; }
        public List<AnhSanPham> anhSanPhams { get; set; }
    }
}