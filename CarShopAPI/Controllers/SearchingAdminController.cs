using BLL.Services.SearchingServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchingAdminController : ControllerBase
{
    private readonly SearchingAdminService _searchingAdminService;

    public SearchingAdminController(SearchingAdminService searchingAdminService)
    {
        _searchingAdminService = searchingAdminService;
    }

    [HttpGet("login")]
    public ActionResult<List<Admin>> GetByLogin(string login)
    {
        var user = _searchingAdminService.SearchAdminByLogin(login);
        if (user != null) return Ok(user);
        return NotFound();
    }

    [HttpGet("email")]
    public ActionResult<List<Admin>> GetByEmail(string email)
    {
        var user = _searchingAdminService.SearchAdminByEmail(email);
        if (user != null) return Ok(user);
        return NotFound();
    }

    [HttpGet("fullname")]
    public ActionResult<List<Admin>> GetByFullName(string name = null, string lastName = null)
    {
        var user = _searchingAdminService.SearchAdminByFullName(name, lastName);
        if (user != null) return Ok(user);
        return NotFound();
    }
}
