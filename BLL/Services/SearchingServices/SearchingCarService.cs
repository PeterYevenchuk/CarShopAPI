using CarShop.Data_Access_Layer;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.SearchingServices;

public class SearchingCarService
{
    private readonly CarsDbContext _context;

    public SearchingCarService(CarsDbContext context)
    {
        _context = context;
    }

    public List<Car> SearchCarByBrand(string brand)
    {
        return _context.Cars.Where(a => a.Brand == brand).ToList();
    }

    public List<Car> SearchCarByModel(string model)
    {
        return _context.Cars.Where(a => a.Model == model).ToList();
    }

    public List<Car> SearchCarByCategory(string category)
    {
        return _context.Cars.Where(a => a.Category == category).ToList();
    }

    public List<Car> SearchCarByPriceRange(decimal minPrice = 0, decimal maxPrice = 0)
    {
        if (maxPrice == 0) return _context.Cars.Where(a => a.Price == minPrice).ToList();
        else if (minPrice == 0) return _context.Cars.Where(a => a.Price == maxPrice).ToList();
        else return _context.Cars.Where(a => a.Price >= minPrice && a.Price <= maxPrice).ToList();
    }
}
