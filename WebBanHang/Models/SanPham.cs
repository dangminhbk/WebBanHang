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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            AnhSanPhams = new HashSet<AnhSanPham>();
            SanPham_HoaDon = new HashSet<SanPham_HoaDon>();
        }

        [Key]
        public int MaSanPham { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên sản phẩm")]
        public string TenSanPham { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        public string MoTaSanPham { get; set; }

        [StringLength(50)]
        [Display(Name = "Màu sắc")]
        public string MauSac { get; set; }

        [Display(Name = "Trọng lượng")]
        public double? TrongLuong { get; set; }
        [Display(Name = "Giá sản phẩm")]
        public int? GiaSanPham { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        public int? GiaKhuyenMai { get; set; }
        public bool? KhuyenMai { get; set; }

        public int? MaDanhMuc { get; set; }

        public int? MaNhaHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnhSanPham> AnhSanPhams { get; set; }

        public virtual DanhMucSanPham DanhMucSanPham { get; set; }

        public virtual NhaHang NhaHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham_HoaDon> SanPham_HoaDon { get; set; }
    }
}
