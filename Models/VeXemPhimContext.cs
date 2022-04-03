using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookingMovie.Models
{
    public partial class VeXemPhimContext : DbContext
    {
        public VeXemPhimContext()
        {
        }

        public VeXemPhimContext(DbContextOptions<VeXemPhimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ChiTietChieuPhim> ChiTietChieuPhims { get; set; }
        public virtual DbSet<ChiTietChoNgoi> ChiTietChoNgois { get; set; }
        public virtual DbSet<ChiTietPhimLive> ChiTietPhimLives { get; set; }
        public virtual DbSet<Ghe> Ghes { get; set; }
        public virtual DbSet<Phim> Phims { get; set; }
        public virtual DbSet<PhimLive> PhimLives { get; set; }
        public virtual DbSet<PhongChieu> PhongChieus { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ve> Ves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RMVGJCB\\MSSQLSERVER01;Database=VeXemPhim;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ChiTietChieuPhim>(entity =>
            {
                entity.HasKey(e => e.IdChiTietChieu)
                    .HasName("PK_ChiTietChieuPhim_1");

                entity.ToTable("ChiTietChieuPhim");

                entity.Property(e => e.GioBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayChieu).HasColumnType("datetime");

                entity.HasOne(d => d.IdPhongNavigation)
                    .WithMany(p => p.ChiTietChieuPhims)
                    .HasForeignKey(d => d.IdPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietChieuPhim_Phong");

                entity.HasOne(d => d.IdPhimNavigation)
                    .WithMany(p => p.ChiTietChieuPhims)
                    .HasForeignKey(d => d.IdPhim)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietChieuPhim_Phim");

                //entity.HasOne(d => d.IdPhong1)
                //    .WithMany(p => p.ChiTietChieuPhims)
                //    .HasForeignKey(d => d.IdPhong)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_ChiTietChieuPhim_PhongChieu");
            });

            modelBuilder.Entity<ChiTietChoNgoi>(entity =>
            {
                entity.HasKey(e => e.IdChoNgoi);

                entity.ToTable("ChiTietChoNgoi");

                entity.HasOne(d => d.IdGheNavigation)
                    .WithMany(p => p.ChiTietChoNgois)
                    .HasForeignKey(d => d.IdGhe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietChoNgoi_Ghe");

                entity.HasOne(d => d.IdPhongNavigation)
                    .WithMany(p => p.ChiTietChoNgois)
                    .HasForeignKey(d => d.IdPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietChoNgoi_PhongChieu");
            });

            modelBuilder.Entity<ChiTietPhimLive>(entity =>
            {
                entity.HasKey(e => e.IdChiTietPhimLive);

                entity.ToTable("ChiTietPhimLive");

                entity.HasOne(d => d.IdPhimLiveNavigation)
                    .WithMany(p => p.ChiTietPhimLives)
                    .HasForeignKey(d => d.IdPhimLive)
                    .HasConstraintName("FK_ChiTietPhimLive_PhimLive");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.ChiTietPhimLives)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_ChiTietPhimLive_User");
            });

            modelBuilder.Entity<Ghe>(entity =>
            {
                entity.HasKey(e => e.IdGhe);

                entity.ToTable("Ghe");

                entity.Property(e => e.TenGhe)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Phim>(entity =>
            {
                entity.HasKey(e => e.IdPhim);

                entity.ToTable("Phim");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TenPhim)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ThoiLuong)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Trailer)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdTheLoaiNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.IdTheLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Phim_TheLoai");
            });

            modelBuilder.Entity<PhimLive>(entity =>
            {
                entity.HasKey(e => e.IdPhimLive);

                entity.ToTable("PhimLive");

                entity.Property(e => e.GioBatDau)
                .HasColumnType("datetime");

                entity.Property(e => e.KeyPhim)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(e => e.TenPhim)
                .IsRequired()
                .HasMaxLength(200);

                entity.HasOne(d => d.IdTheLoaiNavigation)
                    .WithMany(p => p.PhimLives)
                    .HasForeignKey(d => d.IdTheLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhimLive_TheLoai");
            });

            modelBuilder.Entity<PhongChieu>(entity =>
            {
                entity.HasKey(e => e.IdPhong);

                entity.ToTable("PhongChieu");

                entity.Property(e => e.TenPhong)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TheLoai>(entity =>
            {
                entity.HasKey(e => e.IdTheLoai);

                entity.ToTable("TheLoai");

                entity.Property(e => e.TenTheLoai)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_KhachHang");

                entity.ToTable("User");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);

                entity.Property(e => e.TaiKhoan)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ve>(entity =>
            {
                entity.HasKey(e => e.IdVe)
                    .HasName("PK_VE");

                entity.ToTable("Ve");

                entity.HasOne(d => d.IdChiTietChieuNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.IdChiTietChieu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ve_ChiTietChieuPhim");

                entity.HasOne(d => d.IdChoNgoiNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.IdChoNgoi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ve_ChiTietChoNgoi1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ve_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
