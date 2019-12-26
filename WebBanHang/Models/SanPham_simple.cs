using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class SanPham_simple
    {
        private SanPham _sanPham;
        public SanPham_simple(SanPham sanPham)
        {
            _sanPham = sanPham;
        }
        //public string anhHienThi
        //{
        //    get
        //    {
        //        var duongDan = _sanPham.AnhSanPhams;
        //        if (duongDan.Count == 0)
        //        {
        //            return "";
        //        }
        //        return duongDan.First().DuongDanAnh;
        //    }
        //}
        public string TenSanPham
        {
            get
            {
                return _sanPham.TenSanPham;
            }
        }
        public int MaSanPham
        {
            get
            {
                return _sanPham.MaSanPham;
            }
        }
        public int GiaSanPham
        {
            get
            {
                return (int)_sanPham.GiaSanPham;
            }
        }
        public int GiaKhuyenMai
        {
            get
            {
                return (int)_sanPham.GiaKhuyenMai;
            }
        }
    }
}