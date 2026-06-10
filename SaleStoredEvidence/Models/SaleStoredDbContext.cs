
using Microsoft.EntityFrameworkCore;

namespace SaleStoredEvidence.Models;

public partial class SaleStoredDbContext : DbContext
{
    public SaleStoredDbContext()
    {
    }
    public SaleStoredDbContext(DbContextOptions<SaleStoredDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SaleStoredDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasIndex(e => e.SalesId, "IX_Properties_SalesId");

            entity.HasOne(d => d.Sales).WithMany(p => p.Properties).HasForeignKey(d => d.SalesId);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SalesId);

            entity.HasIndex(e => e.PaymentMethodId, "IX_Sales_PaymentMethodId");

            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Sales).HasForeignKey(d => d.PaymentMethodId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
