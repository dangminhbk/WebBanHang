namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            SanPham_HoaDon = new HashSet<SanPham_HoaDon>();
            KhachHangs = new HashSet<KhachHang>();
            NhanViens = new HashSet<NhanVien>();
        }
        [DisplayName("Mã hóa đơn")]
        [Key]
        public int MaHoaDon { get; set; }
        [DisplayName("Ngày xuất")]
        [Column(TypeName = "date")]
        public DateTime? NgaySuatHoaDon { get; set; }
        [DisplayName("Thanh toán")]
        [StringLength(100)]
        public string ThanhToan { get; set; }
        [DisplayName("Địa chỉ người nhận")]
        [StringLength(200)]
        public string DiaChiNguoiNhan { get; set; }
        [DisplayName("Số điện thoại")]
        [StringLength(20)]
        public string SoDienThoai { get; set; }
        [DisplayName("ĐƠn vị giao hàng")]
        [StringLength(100)]
        public string DonViGiaoHang { get; set; }
        [DisplayName("Mã vận đơn")]
        [StringLength(30)]
        public string MaVanDon { get; set; }
        [DisplayName("Tổng tiền")]
        public int? TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham_HoaDon> SanPham_HoaDon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
