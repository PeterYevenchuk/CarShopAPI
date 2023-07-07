using CarShop.Data_Access_Layer;
using DAL.Db;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services;

public class AddFuncPriceService : IService<AddFuncPrice>
{
    private readonly CarsDbContext _context;

    public AddFuncPriceService(CarsDbContext context)
    {
        _context = context;
    }

    public bool Delete(Guid id)
    {
        var car = _context.AdditionalFunctionalityPrices.FirstOrDefault(a => a.Id == id);
        if (car != null)
        {
            _context.AdditionalFunctionalityPrices.Remove(car);
            _context.SaveChanges();

            return true;
        }
        return false;
    }

    public List<AddFuncPrice> Get()
    {
        return _context.AdditionalFunctionalityPrices
        .Include(o => o.Car)
        .ToList();
    }

    public AddFuncPrice? GetById(Guid id)
    {
        var addFuncPrice = _context.AdditionalFunctionalityPrices
        .Include(o => o.Car)
        .FirstOrDefault(a => a.Id == id);

        return addFuncPrice;
    }

    public bool Insert(AddFuncPrice entity)
    {
        try
        {
            _context.AdditionalFunctionalityPrices.Add(entity);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(AddFuncPrice entity)
    {
        try
        {
            var additionalFunctionalityPrice = _context.AdditionalFunctionalityPrices.FirstOrDefault(a => a.Id == entity.Id);
            if (additionalFunctionalityPrice != null)
            {
                additionalFunctionalityPrice.ColorPrice = entity.ColorPrice;
                additionalFunctionalityPrice.GPSNavigationPrice = entity.GPSNavigationPrice;
                additionalFunctionalityPrice.ParkingSensorsPrice = entity.ParkingSensorsPrice;
                additionalFunctionalityPrice.PremiumSoundSystemPrice = entity.PremiumSoundSystemPrice;
                additionalFunctionalityPrice.LeatherSeatsPrice = entity.LeatherSeatsPrice;
                additionalFunctionalityPrice.Car  = entity.Car;
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
