using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Services.Dto
{
    public class PagingDto<T> where T : class
    {
        public int currentPage { get; set; }
        public int totalPage { get; set; }
        public List<T> items { get; set; }
    }
}