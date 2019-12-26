namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CuaHang")]
    public partial class CuaHang
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string TenCuaHang { get; set; }

        [StringLength(200)]
        public string ThongTinCuaHang { get; set; }
        [Required]
        [StringLength(200)]
        public string TenChuCuaHang { get; set; }
        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }
        [Required]
        [StringLength(50)]
        public string SoDienThoai { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
    }
}
