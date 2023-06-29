using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarShop.Data_Access_Layer;

public class CarsDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<CarPhoto> CarPhotos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = cars.db");
        optionsBuilder.ReplaceService<IMigrationsSqlGenerator, SqliteMigrationsSqlGenerator>();

        //Command for terminal
        //dotnet ef --project D:\MyCodeC#.NET\Git\CarShopAPI\DAL migrations add InitialMigration
        //dotnet ef migrations remove
    }
}
