using BLL.Helpers.PasswordHasher;
using DAL.Db;
using DAL.Models;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IService<User> _userService;
    private readonly IPasswordHash _hasher;

    public UserController(IService<User> userService, IPasswordHash hasher)
    {
        _userService = userService;
        this._hasher = hasher;
    }

    [HttpGet]
    public ActionResult<List<User>> Get()
    {
        List<User> users = _userService.Get();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetById(Guid id)
    {
        User user = _userService.GetById(id);
        if (user != null) return Ok(user);
        return NotFound();

    }

    [HttpPost("save")]
    public ActionResult Insert(User user)
    {
        user.Password = _hasher.EncryptPassword(user.Password);
        bool result = _userService.Insert(user);
        if (result) return Ok();
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        bool result = _userService.Delete(id);
        if (result) return Ok();
        return NotFound();

    }

    [HttpPut("update")]
    public ActionResult Update(User user)
    {
        bool result = _userService.Update(user);
        if (result) return Ok();
        return NotFound();
    }
}
