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

        // GET: api/SanPhamAPI
        public List<SanPham_simple> GetSanPhams()
        {
            //IQueryable<SanPham_simple> DanhSachSanPham = from item in db.SanPhams select new SanPham_simple(item);
            var ds = new List<SanPham_simple>();
            foreach (var item in db.SanPhams.ToList())
            {
                ds.Add(new SanPham_simple(item));
            }
            return ds;
        }

        // GET: api/SanPhamAPI/5
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