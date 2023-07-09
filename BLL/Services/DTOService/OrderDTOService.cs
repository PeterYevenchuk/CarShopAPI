using CarShop.Data_Access_Layer;
using DAL.Db;
using DAL.Models;
using DAL.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DTOService;

public class OrderDTOService : IService<OrderDTO>
{
    private readonly IService<Order> _orderService;
    private readonly CarsDbContext _context;

    public OrderDTOService(IService<Order> orderService, CarsDbContext context)
    {
        _orderService = orderService;
        _context = context;
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<OrderDTO> Get()
    {
        throw new NotImplementedException();
    }

    public OrderDTO? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Insert(OrderDTO entity)
    {
        try
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == entity.CarId);
            var user = _context.Users.FirstOrDefault(u => u.Id == entity.UserId);
            var addFuncPrice = _context.AdditionalFunctionalityPrices.FirstOrDefault(a => a.CarId == entity.CarId);

            if (car == null || user == null || addFuncPrice == null) return false;

            car.Count--;
            _context.SaveChanges();
            decimal totalPrice = car.Price;

            var additionalFunctionality = new AddFunc
            {
                Id = Guid.NewGuid(),
                Color = entity.AdditionalFunctionalityDTO.Color,
                GPSNavigation = entity.AdditionalFunctionalityDTO.GPSNavigation,
                ParkingSensors = entity.AdditionalFunctionalityDTO.ParkingSensors,
                PremiumSoundSystem = entity.AdditionalFunctionalityDTO.PremiumSoundSystem,
                LeatherSeats = entity.AdditionalFunctionalityDTO.LeatherSeats
            };

            if (additionalFunctionality.Color != null) totalPrice += addFuncPrice.ColorPrice;
            if (additionalFunctionality.GPSNavigation == true) totalPrice += addFuncPrice.GPSNavigationPrice;
            if (additionalFunctionality.ParkingSensors == true) totalPrice += addFuncPrice.ParkingSensorsPrice;
            if (additionalFunctionality.PremiumSoundSystem == true) totalPrice += addFuncPrice.PremiumSoundSystemPrice;
            if (additionalFunctionality.LeatherSeats == true) totalPrice += addFuncPrice.LeatherSeatsPrice;

            var order = new Order
            {
                Id = Guid.NewGuid(),
                TotalPrice = totalPrice,
                DateOrdered = DateTime.Now,
                Car = car,
                User = user,
                AdditionalFunctionality = additionalFunctionality
            };

            return _orderService.Insert(order);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(OrderDTO entity)
    {
        throw new NotImplementedException();
    }
}
