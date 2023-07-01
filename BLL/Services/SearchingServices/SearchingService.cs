using CarShop.Data_Access_Layer;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services;

public class SearchingService
{
    private readonly CarsDbContext _context;

    public List<User> SearchUserByLogin(string login)
    {
        return _context.Users.Where(a => a.Login == login).ToList();
    }

    public List<User> SearchUserByEmail(string email)
    {
        if (IsValidEmail(email))
        {
            return _context.Users.Where(a => a.Email == email).ToList();
        }
        return null;
    }



    private bool IsValidEmail(string email)
    {
        try
        {
            var mailAddress = new System.Net.Mail.MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
