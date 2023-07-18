using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data_Access_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BLL.Services.NotificationServices;

public class EmailService
{
    private readonly string _sendGridApiKey;
    private readonly CarsDbContext _context;

    public EmailService(IConfiguration configuration, CarsDbContext context)
    {
        _sendGridApiKey = configuration.GetValue<string>("SendGridSettings:ApiKey");
        _context = context;
    }

    public async Task<bool> SendEmailAsync(string recipientEmail, string subject, string message) //subject it is a topic message
    {
        var emailExists = await CheckEmailExist(recipientEmail);
        if (!emailExists) return false;

        var client = new SendGridClient(_sendGridApiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("petroyevenchuk@gmail.com", "Petro Yevenchuk"),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
        };
        msg.AddTo(new EmailAddress(recipientEmail));

        var response = await client.SendEmailAsync(msg);

        return response.IsSuccessStatusCode;
    }

    private async Task<bool> CheckEmailExist(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user != null;
    }
}
