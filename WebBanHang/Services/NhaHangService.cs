using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models;

namespace WebBanHang.Services
{
    public class NhaHangService : ServiceBase<CuaHang>
    {
        public CuaHang getNhaHangInfo(int id)
        {
            return this.db.CuaHang.Find(id);
        }
        public void ThemCuaHang(CuaHang cuaHang, NhanVien nhanvien)
        {
            db.CuaHang.Add(cuaHang);
            db.SaveChanges();
            nhanvien.MaNhaHang = cuaHang.ID;
            db.NhanVien.Add(nhanvien);
            db.SaveChanges();
        }
    }
}