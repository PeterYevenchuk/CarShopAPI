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

public class OrderService : IService<Order>
{
    private readonly CarsDbContext _context;

    public OrderService(CarsDbContext context)
    {
        _context = context;
    }

    public bool Delete(Guid id)
    {
        var order = _context.Orders.FirstOrDefault(a => a.Id == id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();

            return true;
        }
        return false;
    }

    public List<Order> Get()
    {
        return _context.Orders
        .Include(o => o.User)
        .Include(o => o.Car)
        .Include(o => o.AdditionalFunctionality)
        .ToList();
    }

    public Order? GetById(Guid id)
    {
        var order = _context.Orders
        .Include(o => o.User)
        .Include(o => o.Car)
        .Include(o => o.AdditionalFunctionality)
        .FirstOrDefault(a => a.Id == id);

        return order;
    }

    public bool Insert(Order entity)
    {
        try
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(Order entity)
    {
        var existingOrder = _context.Orders.FirstOrDefault(a => a.Id == entity.Id);
        if (existingOrder != null)
        {
            existingOrder.TotalPrice = entity.TotalPrice;
            existingOrder.Car = entity.Car;
            existingOrder.User = entity.User;
            existingOrder.AdditionalFunctionality = entity.AdditionalFunctionality;
            _context.SaveChanges();

            return true;
        }
        return false;
    }
}
