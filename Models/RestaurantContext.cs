using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Restaurant.Models
{
    public partial class RestaurantContext : DbContext
    {
        public RestaurantContext()
        {
        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<GopY> Gopies { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<ThanhToan> ThanhToans { get; set; }
        public virtual DbSet<ThucDon> ThucDons { get; set; }
        public virtual DbSet<VanChuyen> VanChuyens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER01;Database=Restaurant;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.MaTk);

                entity.ToTable("Admin");

                entity.Property(e => e.Mk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MK");

                entity.Property(e => e.Tk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TK");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasKey(e => e.MaBlog);

                entity.ToTable("Blog");

                entity.Property(e => e.Anh).HasMaxLength(50);

                entity.Property(e => e.NgayDang).HasColumnType("datetime");

                entity.Property(e => e.NoiDung).HasMaxLength(1000);

                entity.Property(e => e.TieuDe).HasMaxLength(50);

                entity.Property(e => e.Tk).HasColumnName("TK");

                entity.HasOne(d => d.TkNavigation)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.Tk)
                    .HasConstraintName("FK_Blog_Admin");
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasKey(e => new { e.MaHoaDon, e.MaSanPham });

                entity.ToTable("ChiTietHoaDon");

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.MaHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDon_HoaDon");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDon_SanPham1");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaChucVu)
                    .HasName("PK__PhanQuen__529AB12BB293190A");

                entity.ToTable("ChucVu");

                entity.Property(e => e.ChucVu1)
                    .HasMaxLength(20)
                    .HasColumnName("ChucVu")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<GopY>(entity =>
            {
                entity.HasKey(e => e.MaGopY);

                entity.ToTable("GopY");

                entity.Property(e => e.MaGopY).ValueGeneratedNever();

                entity.Property(e => e.NoiDung).HasMaxLength(1000);

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.Gopies)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("FK_GopY_KhachHang");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon)
                    .HasName("PK__HoaDon__835ED13B34E20335");

                entity.ToTable("HoaDon");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("FK_HoaDon_KhachHang");

                entity.HasOne(d => d.MaThanhToanNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaThanhToan)
                    .HasConstraintName("FK_HoaDon_ThanhToan");

                entity.HasOne(d => d.MaVanChuyenNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaVanChuyen)
                    .HasConstraintName("FK_HoaDon_VanChuyen");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang)
                    .HasName("PK__KhachHan__88D2F0E527EA2F0F");

                entity.ToTable("KhachHang");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenKhachHang).HasMaxLength(30);

                entity.HasOne(d => d.MaChucVuNavigation)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.MaChucVu)
                    .HasConstraintName("FK__KhachHang__MaPha__398D8EEE");
            });

            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(e => e.MaLoaiSanPham)
                    .HasName("PK__loaiSanP__ECCF699F4924860F");

                entity.ToTable("loaiSanPham");

                entity.Property(e => e.TenLoaiSanPham).HasMaxLength(30);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSanPham)
                    .HasName("PK__SanPham__FAC7442DBFE42F55");

                entity.ToTable("SanPham");

                entity.Property(e => e.AnhSanPham).HasMaxLength(50);

                entity.Property(e => e.ChiTiet).HasMaxLength(30);

                entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.Property(e => e.NguyenLieu).HasMaxLength(30);

                entity.Property(e => e.TenSanPham).HasMaxLength(30);

                entity.Property(e => e.Tien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaLoaiSanPhamNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaLoaiSanPham)
                    .HasConstraintName("FK__SanPham__MaLoaiS__3B75D760");

                entity.HasOne(d => d.MaThucDonNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaThucDon)
                    .HasConstraintName("FK__SanPham__MaThucD__3C69FB99");
            });

            modelBuilder.Entity<ThanhToan>(entity =>
            {
                entity.HasKey(e => e.MaThanhToan);

                entity.ToTable("ThanhToan");

                entity.Property(e => e.TrangThaiThanhToan).HasMaxLength(20);
            });

            modelBuilder.Entity<ThucDon>(entity =>
            {
                entity.HasKey(e => e.MaThucDon)
                    .HasName("PK__ThucDon__5596A475D551A1AD");

                entity.ToTable("ThucDon");
            });

            modelBuilder.Entity<VanChuyen>(entity =>
            {
                entity.HasKey(e => e.MaVanChuyen);

                entity.ToTable("VanChuyen");

                entity.Property(e => e.TrangThaiVanChuyen).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
