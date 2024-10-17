using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Website_Ban_Thuc_Pham.Models;

public partial class Bantraicayraucu1Context : DbContext
{
    public Bantraicayraucu1Context()
    {
    }

    public Bantraicayraucu1Context(DbContextOptions<Bantraicayraucu1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminMenu> AdminMenus { get; set; }

    public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }

    public virtual DbSet<LoaiSp> LoaiSps { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HMU56RR;Initial Catalog=bantraicayraucu1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminMenu>(entity =>
        {
            entity.ToTable("AdminMenu");

            entity.Property(e => e.AdminMenuId)
                .ValueGeneratedNever()
                .HasColumnName("AdminMenuID");
            entity.Property(e => e.ActionName).HasMaxLength(20);
            entity.Property(e => e.AreaName).HasMaxLength(20);
            entity.Property(e => e.ControllerName).HasMaxLength(20);
            entity.Property(e => e.Icon).HasMaxLength(50);
            entity.Property(e => e.IdName).HasMaxLength(50);
            entity.Property(e => e.ItemName).HasMaxLength(50);
            entity.Property(e => e.ItemTarget).HasMaxLength(20);
        });

        modelBuilder.Entity<DanhMucSanPham>(entity =>
        {
            entity.HasKey(e => e.MaDmuc);

            entity.ToTable("DanhMucSanPham");

            entity.Property(e => e.MaDmuc)
                .ValueGeneratedNever()
                .HasColumnName("MaDMuc");
            entity.Property(e => e.Mtdm)
                .HasMaxLength(255)
                .HasColumnName("MTDM");
            entity.Property(e => e.TenDmuc)
                .HasMaxLength(50)
                .HasColumnName("TenDMuc");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("User");

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Username");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Password");
            entity.Property(e => e.UserID).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("Email");

        });

        modelBuilder.Entity<LoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoai);

            entity.ToTable("LoaiSP");

            entity.Property(e => e.MaLoai)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Loai).HasMaxLength(50);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.MenuId)
                .ValueGeneratedNever()
                .HasColumnName("MenuID");
            entity.Property(e => e.ActionName).HasMaxLength(50);
            entity.Property(e => e.ControllerName).HasMaxLength(50);
            entity.Property(e => e.Link).HasMaxLength(50);
            entity.Property(e => e.MenuName).HasMaxLength(50);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
        });

        modelBuilder.Entity<ChiTietSanPham>(entity =>
        {
            entity.ToTable("ChiTietSanPham");
            entity.Property(e => e.MaChiTietSP)
            .ValueGeneratedNever()
            .HasColumnName("MaChiTietSP");
            entity.Property(e => e.MaSp).HasMaxLength(25);
            entity.Property(e => e.MaSp)
                .ValueGeneratedNever()
                .HasColumnName("MaSP");
            entity.Property(e => e.AnhSP)
            .ValueGeneratedNever()
            .HasColumnName("AnhSP");
            entity.Property(e => e.Price).HasColumnType("money");

        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.PostID)
                .ValueGeneratedNever()
                .HasColumnName("PostID");
            entity.Property(e => e.Abstract).HasMaxLength(255);
            entity.Property(e => e.Author).HasMaxLength(30);
            entity.Property(e => e.Contents).HasColumnType("ntext");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Images).HasMaxLength(200);
            entity.Property(e => e.Link).HasMaxLength(200);
            entity.Property(e => e.MenuID).HasColumnName("MenuID");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Menu).WithMany(p => p.Posts)
                .HasForeignKey(d => d.MenuID)
                .HasConstraintName("FK_Post_Menu");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp);

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp)
                .ValueGeneratedNever()
                .HasColumnName("MaSP");
            entity.Property(e => e.AnhSp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AnhSP");
            entity.Property(e => e.MaDmuc).HasColumnName("MaDMuc");
            entity.Property(e => e.MaLoai)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Mtsp)
                .HasMaxLength(255)
                .HasColumnName("MTSP");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.TenSp)
                .HasMaxLength(50)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK_SanPham_LoaiSP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
