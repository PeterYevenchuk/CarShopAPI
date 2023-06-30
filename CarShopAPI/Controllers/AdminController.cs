using DAL.Models;
using DAL.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BLL.Helpers.PasswordHasher;
using System.Collections.Generic;
using System.Net;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IService<Admin> _adminService;
    private readonly IPasswordHash _hasher;

    public AdminController(IService<Admin> adminService, IPasswordHash hasher)
    {
        _adminService = adminService;
        this._hasher = hasher;
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
        admin.Password = _hasher.EncryptPassword(admin.Password);
        bool result = _adminService.Insert(admin);
        if (result) return Ok();
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        bool result = _adminService.Delete(id);
        if (result) return Ok();
        return NotFound();

    }

    [HttpPut("update")]
    public ActionResult Update(Admin admin)
    {
        bool result = _adminService.Update(admin);
        if (result) return Ok();
        return NotFound();
    }
}
