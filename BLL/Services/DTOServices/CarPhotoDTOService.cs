using CarShop.Data_Access_Layer;
using DAL.Db;
using DAL.Models;
using DAL.Models.ModelsDTO;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DTOService;

public class CarPhotoDTOService : IService<CarPhotoDTO>
{
    private readonly IService<CarPhoto> _carPhotoService;
    private readonly CarsDbContext _context;

    public CarPhotoDTOService(IService<CarPhoto> carPhotoService, CarsDbContext context)
    {
        _carPhotoService = carPhotoService;
        _context = context;
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<CarPhotoDTO> Get()
    {
        throw new NotImplementedException();
    }

    public CarPhotoDTO? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Insert(CarPhotoDTO entity)
    {
        try
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == entity.CarId);

            if (car == null)
            {
                return false;
            }

            var carPhoto = new CarPhoto
            {
                Id = Guid.NewGuid(),
                URLPhoto = entity.URLPhoto,
                Car = car
            };

            return _carPhotoService.Insert(carPhoto);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(CarPhotoDTO entity)
    {
        throw new NotImplementedException();
    }
}
