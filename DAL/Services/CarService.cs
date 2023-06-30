using CarShop.Data_Access_Layer;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services;

public class CarService
{
    public bool AddNewCar(Car car)
    {
        try
        {
            using (var context = new CarsDbContext())
            {
                context.Cars.Add(car);
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
