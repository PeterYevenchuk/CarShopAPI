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

public class AdminService : IService<Admin>
{
    private readonly CarsDbContext _context;

    public AdminService(CarsDbContext context)
    {
        _context = context;
    }

    public bool Delete(Guid id)
    {
        try
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Id == id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
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

    public List<Admin> Get()
    {
        return _context.Admins.ToList();
    }

    public Admin? GetById(Guid id)
    {
        return _context.Admins.FirstOrDefault(a => a.Id == id);
    }

    public bool Insert(Admin entity)
    {
        try
        {
            _context.Admins.Add(entity);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(Admin entity)
    {
        try
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Id == entity.Id);
            if (admin != null)
            {
                admin.Name = entity.Name;
                admin.LastName = entity.LastName;
                admin.Login = entity.Login;
                admin.Email = entity.Email;
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
