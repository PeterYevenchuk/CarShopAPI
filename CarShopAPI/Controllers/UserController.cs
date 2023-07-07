using BLL.Helpers.EmailValidation;
using BLL.Helpers.PasswordHasher;
using BLL.Helpers.PasswordValidation;
using BLL.Services.ChangePasswordServices;
using DAL.Db;
using DAL.Models;
using DAL.Models.ModelsDTO;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ChangeUserPasswordService _changeUserPasswordService;
    private readonly IService<User> _userService;
    private readonly IPasswordHash _hasher;

    public UserController(IService<User> userService, IPasswordHash hasher, ChangeUserPasswordService changeUserPasswordService)
    {
        _userService = userService;
        this._hasher = hasher;
        _changeUserPasswordService = changeUserPasswordService;
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
    public ActionResult Insert(UserDTO userDTO)
    {
        if (PasswordValid.IsValidatePassword(userDTO.Password) && EmailValid.IsValidEmail(userDTO.Email))
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = userDTO.Name,
                LastName = userDTO.LastName,
                Login = userDTO.Login,
                Password = userDTO.Password,
                Email = userDTO.Email
            };
            user.Password = _hasher.EncryptPassword(user.Password, user.Id.ToByteArray());
            bool result = _userService.Insert(user);
            if (result) return Ok();
            return BadRequest();
        }
        return StatusCode(500, "Password or email write not correct!");
    }

    [HttpPut("update")]
    public ActionResult Update(User user)
    {
        if (EmailValid.IsValidEmail(user.Email))
        {
            bool result = _userService.Update(user);
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
            bool result = _changeUserPasswordService.ChangePassword(id, newPassword, oldPassword);
            if (result) return Ok();
            return BadRequest();
        }
        return StatusCode(500, "New password write not correct!");
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        bool result = _userService.Delete(id);
        if (result) return Ok();
        return NotFound();
    }
}
