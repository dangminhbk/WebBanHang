namespace WebBanHang.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=WebModel")
        {
        }

        public virtual DbSet<AnhSanPham> AnhSanPhams { get; set; }
        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<DanhMucBaiViet> DanhMucBaiViets { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<NhaHang> NhaHangs { get; set; }
        public virtual DbSet<NhaHang_DanhMuc> NhaHang_DanhMuc { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<SanPham_HoaDon> SanPham_HoaDon { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnhSanPham>()
                .Property(e => e.DuongDanAnh)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaVanDon)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.SanPham_HoaDon)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.NhanViens)
                .WithMany(e => e.HoaDons)
                .Map(m => m.ToTable("NhanVien_HoaDon").MapLeftKey("MaHoaDon").MapRightKey("MaNhanVien"));

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.VaiTro)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.AnhSanPhams)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.SanPham_HoaDon)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);
        }
    }
}
