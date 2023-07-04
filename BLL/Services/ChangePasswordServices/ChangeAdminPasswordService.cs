using CarShop.Data_Access_Layer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ChangePasswordServices;

public class ChangeAdminPasswordService
{
    private readonly CarsDbContext _context;

    public ChangeAdminPasswordService(CarsDbContext context)
    {
        _context = context;
    }

    public bool ChangePassword(Guid id, string newPassword, string oldPassword)
    {
        try
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Id == id);
            if (admin != null && admin.Password == oldPassword)
            {
                admin.Password = newPassword;
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
