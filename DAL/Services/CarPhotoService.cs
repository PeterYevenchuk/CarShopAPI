using CarShop.Data_Access_Layer;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services;

public class CarPhotoService
{
    public bool AddNewCarPhoto(CarPhoto carPhoto)
    {
        try
        {
            using (var context = new CarsDbContext())
            {
                context.CarPhotos.Add(carPhoto);
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
