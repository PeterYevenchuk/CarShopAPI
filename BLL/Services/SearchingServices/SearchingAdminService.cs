using BLL.Helpers.EmailValidation;
using CarShop.Data_Access_Layer;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.SearchingServices;

public class SearchingAdminService
{
    private readonly CarsDbContext _context;

    public SearchingAdminService(CarsDbContext context)
    {
        _context = context;
    }

    public List<Admin> SearchAdminByLogin(string login)
    {
        return _context.Admins.Where(a => a.Login == login).ToList();
    }

    public List<Admin> SearchAdminByEmail(string email)
    {
        if (EmailValid.IsValidEmail(email))
        {
            return _context.Admins.Where(a => a.Email == email).ToList();
        }
        return null;
    }

    public List<Admin> SearchAdminByFullName(string name = null, string lastName = null)
    {
        if (name != null) return _context.Admins.Where(a => a.Name == name).ToList();
        else if (lastName != null) return _context.Admins.Where(a => a.LastName == lastName).ToList();
        else return _context.Admins.Where(a => a.Name == name && a.LastName == lastName).ToList();
    }
}
