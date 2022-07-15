using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SachOnline.Models
{
    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=DataBase")
        {
        }

        public virtual DbSet<AccountAdmin> AccountAdmins { get; set; }
        public virtual DbSet<BLOG> BLOGs { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMucSanPham>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.DanhMucSanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.GioHangs)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaXuatBan>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.NhaXuatBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.GioHangs)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);
        }
    }
}
