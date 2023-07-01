using CarShop.Data_Access_Layer;
using DAL.Db;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services;

public class CarPhotoService : IService<CarPhoto>
{
    private readonly CarsDbContext _context;

    public CarPhotoService(CarsDbContext context)
    {
        _context = context;
    }

    public bool Delete(Guid id)
    {
        var carPhoto = _context.CarPhotos.FirstOrDefault(a => a.Id == id);
        if (carPhoto != null)
        {
            _context.CarPhotos.Remove(carPhoto);
            _context.SaveChanges();

            return true;
        }
        return false;
    }

    public List<CarPhoto> Get()
    {
        return _context.CarPhotos.ToList();
    }

    public CarPhoto? GetById(Guid id)
    {
        return _context.CarPhotos.FirstOrDefault(a => a.Id == id);
    }

    public bool Insert(CarPhoto entity)
    {
        try
        {
            _context.CarPhotos.Add(entity);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(CarPhoto entity)
    {
        try
        {
            var carPhoto = _context.CarPhotos.FirstOrDefault(a => a.Id == entity.Id);
            if (carPhoto != null)
            {
                carPhoto.IdCar = entity.IdCar;
                carPhoto.URLPhoto = entity.URLPhoto;
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
