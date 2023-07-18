using BLL.Services.NotificationServices;
using DAL.Models;
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

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail(EmailRequestModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isSuccess = await _emailService.SendEmailAsync(model.RecipientEmail, model.Subject, model.Message);

        if (isSuccess)
        {
            return Ok("Email sent successfully");
        }
        else
        {
            return StatusCode(500, "Failed to send email");
        }
    }
}
