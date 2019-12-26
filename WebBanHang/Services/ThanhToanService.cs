using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models;

namespace WebBanHang.Services
{
    public class ThanhToanService : ServiceBase<object>
    {
        public bool ThanhToan(HoaDon hoaDon, Cart cart)
        {
            var cartGroup = cart.Details.GroupBy(c => c.IdCuaHang);
            foreach (var item in cartGroup)
            {
                var hoaDonRestaurant = hoaDon.Clone;
                int TongTien = 0;
                foreach (var detail in item)
                {
                    var chiTiet = new SanPham_HoaDon
                    {
                        SoLuong = detail.Amount,
                        MaSanPham = detail.Id,
                        Gia = detail.Price
                    };
                    TongTien += detail.Price * detail.Amount;
                }
                hoaDonRestaurant.TongTien = TongTien;
                hoaDonRestaurant.ThanhToan = "Chưa thanh toán";
                hoaDonRestaurant.DonViGiaoHang = "Chưa có";
                hoaDonRestaurant.MaVanDon = "Chưa có";
                hoaDonRestaurant.NgaySuatHoaDon = DateTime.Now;
                hoaDonRestaurant.MaCuaHang = item.Key;
                this.db.HoaDon.Add(hoaDonRestaurant);
                this.db.SaveChanges();
                foreach (var detail in item)
                {
                    var chiTiet = new SanPham_HoaDon
                    {
                        SoLuong = detail.Amount,
                        MaSanPham = detail.Id,
                        Gia = detail.Price,
                        MaHoaDon = hoaDonRestaurant.MaHoaDon
                    };
                    this.db.SanPham_HoaDon.Add(chiTiet);
                }
                this.db.SaveChanges();
            }
            return true;
        }
    }
}