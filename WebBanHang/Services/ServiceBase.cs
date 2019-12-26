using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models;
using WebBanHang.Services.Dto;

namespace WebBanHang.Services
{
    public class ServiceBase<T> where T : class
    {
        protected WebHoaDBContext db = new WebHoaDBContext();
        public ServiceBase()
        {

        }
        public T Detail(int Id)
        {
            return db.Set<T>().Find(Id);
        }
        public bool Delete(int Id)
        {
            T entity = db.Set<T>().Find(Id);
            db.Set<T>().Remove(entity);
            db.SaveChanges();
            return true;
        }
    }
}