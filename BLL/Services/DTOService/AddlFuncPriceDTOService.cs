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

public class AddlFuncPriceDTOService : IService<AddFuncPriceDTO>
{
    private readonly IService<AddFuncPrice> _additionalFunctionalityPriceService;
    private readonly CarsDbContext _context;

    public AddlFuncPriceDTOService(IService<AddFuncPrice> additionalFunctionalityPriceService, CarsDbContext context)
    {
        _additionalFunctionalityPriceService = additionalFunctionalityPriceService;
        _context = context;
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<AddFuncPriceDTO> Get()
    {
        throw new NotImplementedException();
    }

    public AddFuncPriceDTO? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Insert(AddFuncPriceDTO entity)
    {
        try
        {
            var car = _context.Cars.FirstOrDefault(a => a.Id == entity.CarId);

            if (car == null)
            {
                return false;
            }

            var additionalFunctionalityPrice = new AddFuncPrice
            {
                Id = Guid.NewGuid(),
                ColorPrice = entity.ColorPrice,
                GPSNavigationPrice = entity.GPSNavigationPrice,
                ParkingSensorsPrice = entity.ParkingSensorsPrice,
                PremiumSoundSystemPrice = entity.PremiumSoundSystemPrice,
                LeatherSeatsPrice = entity.LeatherSeatsPrice,
                Car = car
            };

            return _additionalFunctionalityPriceService.Insert(additionalFunctionalityPrice);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(AddFuncPriceDTO entity)
    {
        throw new NotImplementedException();
    }
}
