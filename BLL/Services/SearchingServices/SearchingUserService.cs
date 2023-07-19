using BLL.Helpers.EmailValidation;
using CarShop.Data_Access_Layer;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.SearchingServices;

public class SearchingUserService
{
    private readonly CarsDbContext _context;

    public SearchingUserService(CarsDbContext context)
    {
        _context = context;
    }

    public List<User> SearchUserByLogin(string login)
    {
        return _context.Users.Where(a => a.Login == login).ToList();
    }

    public List<User> SearchUserByNumber(string phoneNumber)
    {
        return _context.Users.Where(a => a.PhoneNumber == phoneNumber).ToList();
    }

    public List<User> SearchUserByRole(RoleType role)
    {
        return _context.Users.Where(a => a.Role == role).ToList();
    }

    public List<User> SearchUserByEmail(string email)
    {
        if (EmailValid.IsValidEmail(email))
        {
            return _context.Users.Where(a => a.Email == email).ToList();
        }
        return null;
    }

    public List<User> SearchUserByFullName(string name = null, string lastName = null)
    {
        if (name != null) return _context.Users.Where(a => a.Name == name).ToList();
        else if (lastName != null) return _context.Users.Where(a => a.LastName == lastName).ToList();
        else return _context.Users.Where(a => a.Name == name && a.LastName == lastName).ToList();
    }
}
