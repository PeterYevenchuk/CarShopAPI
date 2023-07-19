using CarShop.Data_Access_Layer;
using DAL.Db;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services;

public class UserService : IService<User>
{
    private readonly CarsDbContext _context;

    public UserService(CarsDbContext context)
    {
        _context = context;
    }

    public bool Delete(Guid id)
    {
        try
        {
            var user = _context.Users.FirstOrDefault(a => a.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
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

    public List<User> Get()
    {
        return _context.Users.ToList();
    }

    public User? GetById(Guid id)
    {
        return _context.Users.FirstOrDefault(a => a.Id == id);
    }

    public bool Insert(User entity)
    {
        try
        {
            _context.Users.Add(entity);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(User entity)
    {
        try
        {
            var user = _context.Users.FirstOrDefault(a => a.Id == entity.Id);
            if (user != null)
            {
                user.Name = entity.Name;
                user.LastName = entity.LastName;
                user.Login = entity.Login;
                user.Email = entity.Email;
                user.PhoneNumber = entity.PhoneNumber;
                user.Role = entity.Role;
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
