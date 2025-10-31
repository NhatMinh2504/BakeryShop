using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BakeryShop.Models;

public partial class KingBakeryManagementContext : DbContext
{
    public KingBakeryManagementContext()
    {
    }

    public KingBakeryManagementContext(DbContextOptions<KingBakeryManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bakery> Bakeries { get; set; }

    public virtual DbSet<BakeryOption> BakeryOptions { get; set; }

    public virtual DbSet<BlogPost> BlogPosts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Favourite> Favourites { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server= Admin-PC;uid=minhpnhe;pwd=123;database= KingBakeryManagement;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bakery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bakery__3214EC270E8BA0FB");

            entity.ToTable("Bakery");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Bakeries)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Bakery__Category__412EB0B6");
        });

        modelBuilder.Entity<BakeryOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BakeryOp__3214EC275CB7CF5C");

            entity.ToTable("BakeryOption");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BakeryId).HasColumnName("BakeryID");

            entity.HasOne(d => d.Bakery).WithMany(p => p.BakeryOptions)
                .HasForeignKey(d => d.BakeryId)
                .HasConstraintName("FK__BakeryOpt__Baker__440B1D61");
        });

        modelBuilder.Entity<BlogPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BlogPost__3214EC07B4ECE53F");

            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC27345CB9EF");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Customer__1788CCACD340DC23");

            entity.ToTable("Customer");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Ranking).HasMaxLength(10);

            entity.HasOne(d => d.User).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.UserId)
                .HasConstraintName("FK__Customer__UserID__3C69FB99");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Employee__1788CCACC5C103AD");

            entity.ToTable("Employee");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Status).HasMaxLength(100);

            entity.HasOne(d => d.User).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.UserId)
                .HasConstraintName("FK__Employee__UserID__398D8EEE");
        });

        modelBuilder.Entity<Favourite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favourit__3214EC27305207BE");

            entity.ToTable("Favourite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BakeryId).HasColumnName("BakeryID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            entity.HasOne(d => d.Bakery).WithMany(p => p.Favourites)
                .HasForeignKey(d => d.BakeryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Favourite__Baker__5812160E");

            entity.HasOne(d => d.Customer).WithMany(p => p.Favourites)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Favourite__Custo__571DF1D5");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3214EC27887AC3C3");

            entity.ToTable("Feedback");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BakeryId).HasColumnName("BakeryID");
            entity.Property(e => e.ContentFb)
                .HasMaxLength(4000)
                .HasColumnName("ContentFB");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Bakery).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.BakeryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Feedback__Bakery__5441852A");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Feedback__Custom__534D60F1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC27D4049E27");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdrDelivery).HasMaxLength(300);
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.DenyReason).HasMaxLength(2000);
            entity.Property(e => e.HasFb)
                .HasDefaultValue(false)
                .HasColumnName("HasFB");
            entity.Property(e => e.Note).HasMaxLength(2000);
            entity.Property(e => e.Payment)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

            entity.HasOne(d => d.Shipper).WithMany(p => p.OrderShippers)
                .HasForeignKey(d => d.ShipperId)
                .HasConstraintName("FK__Orders__ShipperI__4AB81AF0");

            entity.HasOne(d => d.Staff).WithMany(p => p.OrderStaffs)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__Orders__StaffID__49C3F6B7");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Orders__VoucherI__4BAC3F29");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC2708ABA9F7");

            entity.ToTable("OrderItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BakeryId).HasColumnName("BakeryID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.Bakery).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.BakeryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OrderItem__Baker__4F7CD00D");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OrderItem__Custo__4E88ABD4");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OrderItem__Order__5070F446");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC2725F3E828");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(11);
            entity.Property(e => e.Username).HasMaxLength(100);
            entity.Property(e => e.VertificationCode).HasMaxLength(200);
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId).HasName("PK__Vouchers__3AEE79C165DDCDF5");

            entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Vpercent).HasColumnName("VPercent");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
