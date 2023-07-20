using CarShop.BLL.Services.ChangePasswordServices;
using CarShop.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ChangePasswordServices;

public class ChangeUserPasswordService : IChangeUserPasswordService
{
    private readonly CarsDbContext _context;

    public ChangeUserPasswordService(CarsDbContext context)
    {
        _context = context;
    }

    public bool ChangePassword(Guid id, string newPassword, string oldPassword)
    {
        try
        {
            var user = _context.Users.FirstOrDefault(a => a.Id == id);
            if (user != null && user.Password == oldPassword)
            {
                user.Password = newPassword;
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
