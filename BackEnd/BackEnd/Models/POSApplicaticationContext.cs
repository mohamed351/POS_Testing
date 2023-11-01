using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd.Models
{
    public partial class POSApplicaticationContext : DbContext
    {
        public POSApplicaticationContext()
        {
        }

        public POSApplicaticationContext(DbContextOptions<POSApplicaticationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<ProductUnitType> ProductUnitTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;Initial Catalog=POSApplicatication;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gpc)
                    .HasMaxLength(50)
                    .HasColumnName("GPC");

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PackageName).HasMaxLength(150);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ProductImage).HasMaxLength(150);

                entity.Property(e => e.ProductName).HasMaxLength(500);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductUnitType");
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.PackageId });

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.PackageId).HasColumnName("PackageID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CodeType).HasMaxLength(10);

                entity.Property(e => e.Cost).HasColumnType("decimal(9, 5)");

                entity.Property(e => e.ParentPackageId).HasColumnName("ParentPackageID");

                entity.Property(e => e.ProductName).HasMaxLength(500);

                entity.Property(e => e.Quantity).HasColumnType("decimal(9, 5)");

                entity.Property(e => e.QuantityBase).HasColumnType("decimal(9, 5)");

                entity.Property(e => e.ReferenceNumber).HasMaxLength(50);

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(9, 5)");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDetails_Packages");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDetails_Product");
            });

            modelBuilder.Entity<ProductUnitType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("ProductUnitType");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
