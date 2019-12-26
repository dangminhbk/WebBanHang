namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySuatHoaDon { get; set; }

        [StringLength(100)]
        public string ThanhToan { get; set; }

        [StringLength(200)]
        public string DiaChiNguoiNhan { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string DonViGiaoHang { get; set; }

        [StringLength(30)]
        public string MaVanDon { get; set; }

        public int? TongTien { get; set; }

        [StringLength(200)]
        public string TenKhachHang { get; set; }
        public int? MaCuaHang { get; set; }
        public HoaDon Clone
        {
            get
            {
                var obj = new HoaDon
                {
                    NgaySuatHoaDon = this.NgaySuatHoaDon,
                    ThanhToan = this.ThanhToan,
                    DiaChiNguoiNhan = this.DiaChiNguoiNhan,
                    DonViGiaoHang = this.DonViGiaoHang,
                    TenKhachHang = this.TenKhachHang
                };
                return obj;
            }
        }
    }
}
