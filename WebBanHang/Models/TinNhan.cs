namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinNhan")]
    public partial class TinNhan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaKhachHang { get; set; }

        [Key]
        [Column("TinNhan", Order = 1)]
        [StringLength(256)]
        public string TinNhan1 { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
