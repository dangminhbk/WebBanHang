using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class CartDetail
    {
        [Key]
        [DisplayName("Mã hàng hóa")]
        public int Id { get; set; }
        [DisplayName("Giá cả")]
        public int Price { get; set; }
        [DisplayName("Tên mặt hàng")]
        public string Name { get; set; }
        [DisplayName("Số lượng")]
        public int Amount { get; set; }
    }
}