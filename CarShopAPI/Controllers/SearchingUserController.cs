using BLL.Services.SearchingServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchingUserController : ControllerBase
{
    private readonly SearchingUserService _searchingUserService;

    public SearchingUserController(SearchingUserService searchingUserService)
    {
        _searchingUserService = searchingUserService;
    }

    [HttpGet("login")]
    public ActionResult<List<User>> GetByLogin(string login)
    {
        var user = _searchingUserService.SearchUserByLogin(login);
        if (user != null) return Ok(user);
        return NotFound();
    }

    [HttpGet("phone-number")]
    public ActionResult<List<User>> GetByPhoneNumber(string number)
    {
        var user = _searchingUserService.SearchUserByNumber(number);
        if (user != null) return Ok(user);
        return NotFound();
    }

    [HttpGet("role")]
    public ActionResult<List<User>> GetByRole(RoleType role)
    {
        var user = _searchingUserService.SearchUserByRole(role);
        if (user != null) return Ok(user);
        return NotFound();
    }

    [HttpGet("email")]
    public ActionResult<List<User>> GetByEmail(string email)
    {
        var user = _searchingUserService.SearchUserByEmail(email);
        if (user != null) return Ok(user);
        return NotFound();
    }

    [HttpGet("fullname")]
    public ActionResult<List<User>> GetByFullName(string name = null, string lastName = null)
    {
        var user = _searchingUserService.SearchUserByFullName(name, lastName);
        if (user != null) return Ok(user);
        return NotFound();
    }
}
