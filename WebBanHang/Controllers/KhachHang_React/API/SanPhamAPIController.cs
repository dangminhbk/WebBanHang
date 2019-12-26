using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebBanHang.Models;

namespace WebBanHang.Controllers.KhachHang_React.Api
{
    public class SanPhamAPIController : ApiController
    {
        private WebHoaDBContext db = new WebHoaDBContext();
        /// <summary>
        /// Tra ve danh sach san pham o trang 
        /// </summary>
        /// <param name="page"></param>
        [HttpGet]
        public List<SanPham_simple> GetSanPhams(int? page)
        {
            int pageT = (int)((page == null) ? 1 : page);
            //IQueryable<SanPham_simple> DanhSachSanPham = from item in db.SanPhams select new SanPham_simple(item);
            var dsSkip = db.SanPham.ToList().Skip((pageT - 1) * 9).Take(9).ToList();
            var ds = new List<SanPham_simple>();
            foreach (var item in dsSkip)
            {
                ds.Add(new SanPham_simple(item));
            }
            return ds;
        }
        /// <summary>
        /// Tra ve so luong trang toi da
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int SoLuongTrang()
        {
            var count = db.SanPham.Count();
            if (count % 9 == 0)
            {
                return count / 9;
            }
            return count / 9 + 1;
        }
        /// <summary>
        /// Tra ve danh sach san pham theo tieu chi tim
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="DanhMuc"></param>
        /// <param name="MauSac"></param>
        /// <param name="TenSanPham"></param>
        /// <param name="GiaThapNhat"></param>
        /// <param name="GiaCaoNhat"></param>
        /// <returns></returns>
        [HttpGet]
        public List<SanPham_simple> TimKiem(int? Page, int DanhMuc, string MauSac, string TenSanPham, int GiaThapNhat, int GiaCaoNhat)
        {
            // Tim kiem bang query thuan
            string sqlQuery = "select * from SanPham where SanPham.MaDanhMuc = @maDanhMuc and MauSac = @mauSac and GiaSanPham< @maxGia and GiaSanPham > @minGia and TenSanPham like @ten ";
            object[] paramList =  {
                new SqlParameter{
                    ParameterName = "@maDanhMuc",
                    SqlDbType = SqlDbType.Int,
                    Value = DanhMuc,
                },
                new SqlParameter{
                    ParameterName = "@mauSac",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = MauSac,
                },
                new SqlParameter{
                    ParameterName = "@maxGia",
                    SqlDbType = SqlDbType.Int,
                    Value = GiaCaoNhat,
                },
                new SqlParameter{
                    ParameterName = "@minGia",
                    SqlDbType = SqlDbType.Int,
                    Value = GiaThapNhat,
                },
                new SqlParameter{
                    ParameterName = "@ten",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = "%"+TenSanPham+"%",
                }
            };
            var result = db.SanPham.SqlQuery(sqlQuery, paramList).ToList<SanPham>();
            var ds = new List<SanPham_simple>();
            if (result != null)
            {
                int pageT = (int)((Page == null) ? 1 : Page);
                var dsSkip = result.Skip((pageT - 1) * 9).Take(9).ToList();
                foreach (var item in dsSkip)
                {
                    ds.Add(new SanPham_simple(item));
                }
            }
            return ds;
        }
        // GET: api/SanPhamAPI/5
        [HttpGet]
        public List<SanPham_simple> SanPhamDanhMuc(int? page, string DanhMuc)
        {
            var result = db.DanhMucSanPham.Where(item => item.TenDanhMuc == DanhMuc).First();
            var ds = new List<SanPham_simple>();
            if (result != null)
            {
                int pageT = (int)((page == null) ? 1 : page);
                var dsSkip = db.SanPham.Where(s=>s.MaDanhMuc == result.MaDanhMuc).ToList().Skip((pageT - 1) * 9).Take(9).ToList();
                foreach (var item in dsSkip)
                {
                    ds.Add(new SanPham_simple(item));
                }
            }
            return ds;
        }
        [HttpGet]
        public int SoLuongTrangTheoDanhMuc(string DanhMuc)
        {
            var result = db.DanhMucSanPham.Where(item => item.TenDanhMuc == DanhMuc).First();
            var count = 0;
            if (result != null)
            {
                count = db.SanPham.Where(s => s.MaDanhMuc == result.MaDanhMuc).Count();
            }
            if (count % 9 == 0)
            {
                return count / 9;
            }
            return count / 9 + 1;
        }
        [HttpGet]
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult GetSanPham(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return Ok(sanPham);
        }
    }
}