using CarShop.Data_Access_Layer;
using DAL.Db;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services;

public class CarService : IService<Car>
{
    private readonly CarsDbContext _context;

    public CarService(CarsDbContext context)
    {
        _context = context;
    }

    public bool Delete(Guid id)
    {
        var car = _context.Cars.FirstOrDefault(a => a.Id == id);
        if (car != null)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();

            return true;
        }
        return false;
    }

    public List<Car> Get()
    {
        return _context.Cars.ToList();
    }

    public Car? GetById(Guid id)
    {
        return _context.Cars.FirstOrDefault(a => a.Id == id);
    }

    public bool Insert(Car entity)
    {
        try
        {
            _context.Cars.Add(entity);
            _context.SaveChanges();

            return true;
        }
        catch (Exception) 
        {
            return false;
        }
    }

    public bool Update(Car entity)
    {
        try
        {
            var car = _context.Cars.FirstOrDefault(a => a.Id == entity.Id);
            if (car != null)
            {
                car.Brand = entity.Brand;
                car.Model = entity.Model;
                car.Category = entity.Category;
                car.DateCreated = entity.DateCreated;
                car.StandartColor = entity.StandartColor;
                car.Count = entity.Count;
                car.Price = entity.Price;
                _context.SaveChanges();

                return true;
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
