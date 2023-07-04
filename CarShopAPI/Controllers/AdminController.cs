using DAL.Models;
using DAL.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BLL.Helpers.PasswordHasher;
using System.Collections.Generic;
using System.Net;
using BLL.Helpers.EmailValidation;
using BLL.Helpers.PasswordValidation;
using BLL.Services.ChangePasswordServices;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IService<Admin> _adminService;
    private readonly ChangeAdminPasswordService _changeAdminPasswordService;
    private readonly IPasswordHash _hasher;

    public AdminController(IService<Admin> adminService, IPasswordHash hasher, ChangeAdminPasswordService changeAdminPasswordService)
    {
        _adminService = adminService;
        this._hasher = hasher;
        _changeAdminPasswordService = changeAdminPasswordService;
    }

    [HttpGet]
    public ActionResult<List<Admin>> Get()
    {
        List<Admin> admins = _adminService.Get();

        return Ok(admins);
    }

    [HttpGet("{id}")]
    public ActionResult<Admin> GetById(Guid id)
    {
        Admin admin = _adminService.GetById(id);
        if (admin != null) return Ok(admin);
        return NotFound();

    }

    [HttpPost("save")]
    public ActionResult Insert(Admin admin)
    {
        if (PasswordValid.IsValidatePassword(admin.Password))
        {
            admin.Password = _hasher.EncryptPassword(admin.Password, admin.Id.ToByteArray());
            if (EmailValid.IsValidEmail(admin.Email))
            {
                bool result = _adminService.Insert(admin);
                if (result) return Ok();
                return BadRequest();
            }
            return StatusCode(500, "Email write not correct!");
        }
        return StatusCode(500, "Password write not correct!");
    }

    [HttpPut("update")]
    public ActionResult Update(Admin admin)
    {
        if (EmailValid.IsValidEmail(admin.Email))
        {
            bool result = _adminService.Update(admin);
            if (result) return Ok();
            return NotFound();
        }
        return BadRequest();
    }

    [HttpPut("changepassword")]
    public ActionResult ChangePassword(Guid id, string newPassword, string oldPassword)
    {
        if (PasswordValid.IsValidatePassword(newPassword))
        {
            newPassword = _hasher.EncryptPassword(newPassword, id.ToByteArray());
            oldPassword = _hasher.EncryptPassword(oldPassword, id.ToByteArray());
            bool result = _changeAdminPasswordService.ChangePassword(id, newPassword, oldPassword);
            if (result) return Ok();
            return BadRequest();
        }
        return StatusCode(500, "New password write not correct!");
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        bool result = _adminService.Delete(id);
        if (result) return Ok();
        return NotFound();

    }
}
