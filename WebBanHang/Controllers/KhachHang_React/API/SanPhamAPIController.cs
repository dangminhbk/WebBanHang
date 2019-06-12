using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
        private WebHoa db = new WebHoa();
        /// <summary>
        /// Tra ve danh sach san pham o trang 
        /// </summary>
        /// <param name="page"></param>
        [HttpGet]
        public List<SanPham_simple> GetSanPhams(int? page)
        {
            int pageT = (int)((page == null) ? 1 : page);
            //IQueryable<SanPham_simple> DanhSachSanPham = from item in db.SanPhams select new SanPham_simple(item);
            var dsSkip = db.SanPhams.ToList().Skip((pageT - 1) * 9).Take(9).ToList();
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
            var count = db.SanPhams.Count();
            if(count % 9 ==0)
            {
                return count / 9;
            }
            return count / 9 + 1;
        }

        // GET: api/SanPhamAPI/5
        [HttpGet]
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult GetSanPham(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return Ok(sanPham);
        }        
    }
}