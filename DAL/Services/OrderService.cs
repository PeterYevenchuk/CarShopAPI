using CarShop.Data_Access_Layer;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services;

public class OrderService
{
    public bool AddNewOrder(Order order)
    {
        try
        {
            using (var context = new CarsDbContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
