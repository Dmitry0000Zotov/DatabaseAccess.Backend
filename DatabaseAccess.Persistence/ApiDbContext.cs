using Microsoft.EntityFrameworkCore;
using DatabaseAccess.Domain;
using DatabaseAccess.Application.Interfaces;

namespace DatabaseAccess.Persistence;

public partial class ApiDbContext : DbContext, IApiDbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options) { }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Nomenclature> Nomenclatures { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ResourseSpecification> ResourseSpecifications { get; set; }

    public virtual DbSet<ResourseSpecificationDetail> ResourseSpecificationDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_EmployeeId");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK_MaterialId");

            entity.Property(e => e.MaterialId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("numeric(15, 3)");

            entity.HasOne(d => d.Nomenclature).WithMany(p => p.Materials)
                .HasForeignKey(d => d.NomenclatureId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Nomenclature>(entity =>
        {
            entity.HasKey(e => e.NomenclatureId).HasName("PK_NomenclatureId");

            entity.HasIndex(e => e.NomenclatureName, "UQ__Nomencla__0FD2F43A4E203DEE").IsUnique();

            entity.Property(e => e.NomenclatureId).ValueGeneratedNever();
            entity.Property(e => e.CountType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NomenclatureName)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_ProductId");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTo).HasColumnType("datetime");
            entity.Property(e => e.PalletNumber).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Nomenclature).WithMany(p => p.Products)
                .HasForeignKey(d => d.NomenclatureId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Specification).WithMany(p => p.Products)
                .HasForeignKey(d => d.SpecificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ResorseSpec_SpecificationId");
        });

        modelBuilder.Entity<ResourseSpecification>(entity =>
        {
            entity.HasKey(e => e.SpecificationId).HasName("PK_SpecificationId");

            entity.Property(e => e.SpecificationId).ValueGeneratedNever();
            entity.Property(e => e.SpecificationName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ResourseSpecificationDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK_DetailId");

            entity.Property(e => e.DetailId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("numeric(10, 3)");
            entity.Property(e => e.ArticleCosting)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Characteristic)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.WayToObtain)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Specification).WithMany(p => p.ResourseSpecificationDetails)
                .HasForeignKey(d => d.SpecificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResourseSpecDetails_ResourseSpec_SpecificationId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
