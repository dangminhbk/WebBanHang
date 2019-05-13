namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiViet")]
    public partial class BaiViet
    {
        [Key]
        public int MaBaiViet { get; set; }

        [StringLength(200)]
        public string TenBaiViet { get; set; }

        [Column(TypeName = "xml")]
        public string NoiDungBaiViet { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayViet { get; set; }

        public int? MaDanhMucBaiViet { get; set; }

        public virtual DanhMucBaiViet DanhMucBaiViet { get; set; }
    }
}
