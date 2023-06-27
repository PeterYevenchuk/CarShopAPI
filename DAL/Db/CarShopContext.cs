using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL.Db;

public class CarShopContext : DbContext
{
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarPhoto> CarPhotos { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data Source=DESKTOP-JH7RBMI;Initial Catalog=CarShopPetProject;Integrated Security=True;";
        optionsBuilder.UseSqlServer(connectionString);
    }
}
