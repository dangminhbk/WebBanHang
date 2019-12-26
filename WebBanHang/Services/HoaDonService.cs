using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models;
using WebBanHang.Services.Dto;

namespace WebBanHang.Services
{
    public class HoaDonService : ServiceBase<HoaDon>
    {
        public PagingDto<HoaDon> GetAll(int page, int pageSize, int? nhaHangId)
        {
            var hoaDon = db.HoaDon.AsQueryable().Where(s => s.MaCuaHang == nhaHangId);
            var total = hoaDon.Count();
            var totalPage = total / pageSize + 1;
            var hoaDons = hoaDon.OrderBy(s => s.NgaySuatHoaDon).Skip(page * pageSize).Take(pageSize);
            return new PagingDto<HoaDon>
            {
                items = hoaDons.ToList(),
                currentPage = page,
                totalPage = totalPage
            };
        }
    }
}