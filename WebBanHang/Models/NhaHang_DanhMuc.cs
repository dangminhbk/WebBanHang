namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NhaHang_DanhMuc
    {
        public int? MaNhaHang { get; set; }

        public int? MaDanhMuc { get; set; }

        public int ID { get; set; }

        public virtual DanhMucSanPham DanhMucSanPham { get; set; }

        public virtual NhaHang NhaHang { get; set; }
    }
}
