using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarShop.Data_Access_Layer;

public class CarsDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<CarPhoto> CarPhotos { get; set; }
    public DbSet<AdditionalFunctionality> AdditionalFunctionalities { get; set; }
    public DbSet<AdditionalFunctionalityPrice> AdditionalFunctionalityPrices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ReplaceService<IMigrationsSqlGenerator, SqliteMigrationsSqlGenerator>();
        optionsBuilder.UseSqlite("Data Source = cars.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Foreign key for table CarPhoto
        modelBuilder.Entity<CarPhoto>()
            .HasOne(p => p.Car)
            .WithMany()
            .HasForeignKey("CarId")
            .OnDelete(DeleteBehavior.Cascade);

        // Foreign key for the Order table
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Car)
            .WithMany()
            .HasForeignKey("CarId")
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.AdditionalFunctionality)
            .WithMany()
            .HasForeignKey("AdditionalFunctionalityId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
