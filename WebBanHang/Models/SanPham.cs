namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSanPham { get; set; }

        public string MoTaSanPham { get; set; }

        public int? GiaSanPham { get; set; }

        public int? GiaKhuyenMai { get; set; }

        public bool? KhuyenMai { get; set; }

        public int? MaDanhMuc { get; set; }

        public int? MaCuaHang { get; set; }
    }
}
