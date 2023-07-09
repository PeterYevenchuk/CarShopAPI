using CarShop.Data_Access_Layer;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.SortingServices;

public class SortCarsService
{
    private readonly CarsDbContext _context;

    public SortCarsService(CarsDbContext context)
    {
        _context = context;
    }

    public List<Car> GetCarsSortedByBrand()
    {
        return _context.Cars.OrderBy(c => c.Brand).ToList();
    }

    public List<Car> GetCarsSortedByModel()
    {
        return _context.Cars.OrderBy(c => c.Model).ToList();
    }

    public List<Car> GetCarsSortedByCategory()
    {
        return _context.Cars.OrderBy(c => c.Category).ToList();
    }

    public List<Car> GetCarsSortedByCount()
    {
        return _context.Cars.OrderBy(c => c.Count).ToList();
    }

    public List<Car> GetCarsSortedByPrice()
    {
        return _context.Cars.OrderBy(c => (double)c.Price).ToList();
    }
}
