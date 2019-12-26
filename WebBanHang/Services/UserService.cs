using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models;

namespace WebBanHang.Services
{
    public class UserService :ServiceBase<NhanVien>
    {
        public NhanVien GetUser(int? id)
        {
            return this.db.NhanVien.Find(id.Value);
        }
        public IQueryable<NhanVien> GetRepo => this.db.NhanVien.AsQueryable(); 
    }
}