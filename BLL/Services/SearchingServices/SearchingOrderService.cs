using CarShop.Data_Access_Layer;
using DAL.Models;
using System.Xml.Linq;

namespace BLL.Services.SearchingServices;

public class SearchingOrderService
{
    private readonly CarsDbContext _context;

    public SearchingOrderService(CarsDbContext context)
    {
        _context = context;
    }

    public Order SearchOrderByUserId(Guid userId)
    {
        return _context.Orders.FirstOrDefault(a => a.User.Id == userId);
    }

    public List<Order> SearchOrderByFullNameUser(string name = null, string lastName = null)
    {
        if (name != null) return _context.Orders.Where(a => a.User.Name == name).ToList();
        else if (lastName != null) return _context.Orders.Where(a => a.User.LastName == lastName).ToList();
        else return _context.Orders.Where(a => a.User.Name == name && a.User.LastName == lastName).ToList();
    }

    public List<Order> SearchOrderByBrandCar(string brand)
    {
        return _context.Orders.Where(a => a.Car.Brand == brand).ToList();
    }

    public List<Order> SearchOrderByModelCar(string model)
    {
        return _context.Orders.Where(a => a.Car.Model == model).ToList();
    }

    public List<Order> SearchOrderByCategoryCar(string category)
    {
        return _context.Orders.Where(a => a.Car.Category == category).ToList();
    }

    public List<Order> SearchOrderByPriceRangeCar(decimal minPrice = 0, decimal maxPrice = 0)
    {
        if (maxPrice == 0) return _context.Orders.Where(a => a.Car.Price == minPrice).ToList();
        else if (minPrice == 0) return _context.Orders.Where(a => a.Car.Price == maxPrice).ToList();
        else return _context.Orders.Where(a => a.Car.Price >= minPrice && a.Car.Price <= maxPrice).ToList();
    }
}
