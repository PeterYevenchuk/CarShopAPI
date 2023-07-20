using CarShop.BLL.Services.BasicServices;
using CarShop.Data_Access_Layer;
using DAL.Models;
using DAL.Models.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public ActionResult<string> Login([FromBody] LoginDTO model)
    {
        var token = _authService.AuthenticateUser(model.Login, model.Password);

        if (token == null) return Unauthorized("Invalid login or password");
        return Ok(token);
    }
}
