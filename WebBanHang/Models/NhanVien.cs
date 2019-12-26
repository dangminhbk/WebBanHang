namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [StringLength(20)]
        public string TenDangNhap { get; set; }

        [StringLength(128)]
        public string MatKhau { get; set; }

        [StringLength(20)]
        public string VaiTro { get; set; }

        [Key]
        public int MaNhanVien { get; set; }

        public int? MaNhaHang { get; set; }
    }
}
