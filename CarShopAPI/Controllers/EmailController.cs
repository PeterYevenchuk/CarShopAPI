using BLL.Services.NotificationServices;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly EmailService _emailService;

    public EmailController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "User")]
    [HttpPost("send")]
    public async Task<IActionResult> SendEmail(EmailRequestModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // if it is real project i just connect this and write real api key in appsetings
        #region forRealProject
        //var isSuccess = await _emailService.SendEmailAsync(model.RecipientEmail, model.Subject, model.Message);

        //if (isSuccess) return Ok("Email sent successfully");
        //else return StatusCode(500, "Failed to send email");
        #endregion

        var isCheckEmailExist = await _emailService.CheckEmailExist(model.RecipientEmail); 
        if (isCheckEmailExist) return Ok("Email sent successfully");
        else return StatusCode(500, "Failed to send email");
    }
}
