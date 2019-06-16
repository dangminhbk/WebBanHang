namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

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
        [DisplayName("Mã sản phẩm")]
        public int MaSanPham { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập trường này")]
        [StringLength(100)]
        [DisplayName("Tên sản phẩm")]
        public string TenSanPham { get; set; }

        [DisplayName("Mô tả sản phẩm")]
        [AllowHtml]
        public string MoTaSanPham { get; set; }

        [StringLength(50)]
        [DisplayName("Màu sắc")]
        public string MauSac { get; set; }

        [DisplayName("Trọng lượng")]
        [Required(ErrorMessage = "Vui lòng nhập trường này")]
        public double? TrongLuong { get; set; }

        [DisplayName("Giá bán")]
        [Required(ErrorMessage = "Vui lòng nhập trường này")]
        public int? GiaSanPham { get; set; }

        [DisplayName("Giá khuyến mãi")]
        [Required(ErrorMessage = "Vui lòng nhập trường này")]
        public int? GiaKhuyenMai { get; set; }

        [DisplayName("Khuyến mãi")]
        [Required(ErrorMessage = "Vui lòng nhập trường này")]
        public bool? KhuyenMai { get; set; }

        [DisplayName("Danh mục")]
        [Required(ErrorMessage = "Vui lòng nhập trường này")]
        public int? MaDanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnhSanPham> AnhSanPhams { get; set; }

        public virtual DanhMucSanPham DanhMucSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham_HoaDon> SanPham_HoaDon { get; set; }
    }
}
