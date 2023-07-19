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
    public DbSet<CarPhoto> CarPhotos { get; set; }
    public DbSet<AddFunc> AdditionalFunctionalities { get; set; }
    public DbSet<AddFuncPrice> AdditionalFunctionalityPrices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ReplaceService<IMigrationsSqlGenerator, SqliteMigrationsSqlGenerator>();
        optionsBuilder.UseSqlite("Data Source = cars.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Foreign key for CarPhoto table 
        modelBuilder.Entity<CarPhoto>()
            .HasOne(o => o.Car)
            .WithMany()
            .HasForeignKey("CarId")
            .OnDelete(DeleteBehavior.Cascade);

        // Foreign key for the Order table
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Car)
            .WithMany()
            .HasForeignKey("CarId")
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.AdditionalFunctionality)
            .WithMany()
            .HasForeignKey("AdditionalFunctionalityId")
            .OnDelete(DeleteBehavior.Restrict);

        // Foreign key for the AdditionalFunctionalityPrice table
        modelBuilder.Entity<AddFuncPrice>()
            .HasOne(o => o.Car)
            .WithMany()
            .HasForeignKey("CarId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
