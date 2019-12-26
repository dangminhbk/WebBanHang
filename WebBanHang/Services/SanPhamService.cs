using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebBanHang.Models;
using WebBanHang.Services.Dto;
using System.Collections;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using WebBanHang.Services;

namespace WebBanHang.Services
{
    public class SanPhamService : ServiceBase<SanPham>
    {
        public PagingDto<SanPham> GetAll(int page, int pageSize, int? nhaHangId)
        {
            var sanPhams = db.SanPham.AsQueryable().Where(s=>s.MaCuaHang == nhaHangId);
            var total = sanPhams.Count();
            var totalPage = total / pageSize + 1;
            var sanPhamsTrang = sanPhams.OrderBy(s=>s.TenSanPham).Skip(page * pageSize).Take(pageSize);
            return new PagingDto<SanPham>
            {
                items = sanPhamsTrang.ToList(),
                currentPage = page,
                totalPage = totalPage
            }; 
        }
        public SanPhamDetailDto DetailWithAnh(int Id)
        {
            var sp = db.SanPham.Find(Id);
            var anhSp = db.AnhSanPham.Where(s => s.MaSanPham == Id);
            return new SanPhamDetailDto
            {
                anhSanPhams = anhSp.ToList(),
                sanPham = sp
            };
        }
        public void Create(SanPham sanPham, HttpPostedFileBase[] anhSP, HttpServerUtilityBase Server)
        {
            db.SanPham.Add(sanPham);
            db.SaveChanges();
            var Id = sanPham.MaSanPham;
            if (anhSP != null && anhSP.Count() > 0)
            {
                foreach (var item in anhSP)
                {
                    if (item != null && item.ContentLength > 0)
                    {
                        var filename = Path.GetRandomFileName() + Path.GetExtension(item.FileName);
                        var path = Path.Combine(Server.MapPath("~/Uploaded"), filename);
                        var pathDisplay = "/Uploaded/" + filename;
                        item.SaveAs(path);
                        var anhspTemp = new AnhSanPham { DuongDanAnh = pathDisplay, MaSanPham = Id };
                        db.AnhSanPham.Add(anhspTemp);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}