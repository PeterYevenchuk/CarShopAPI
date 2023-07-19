using BLL.Services.PaymentSystem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentStrategy _paymentStrategy;
    private readonly ILogger<PaymentController> _logger;

    public PaymentController(IPaymentStrategy paymentStrategy, ILogger<PaymentController> logger)
    {
        _paymentStrategy = paymentStrategy;
        _logger = logger;
    }

    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "User")]
    [HttpPost("credit-card")]
    public IActionResult ProcessCreditCardPayment(decimal amount, string cardNumber)
    {
        try
        {
            var result = _paymentStrategy.ProcessPayment(amount, cardNumber);
            _logger.LogInformation(result);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing credit card payment.");
            return StatusCode(500, "An error occurred while processing the payment.");
        }
    }

    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "User")]
    [HttpPost("paypal")]
    public IActionResult ProcessPayPalPayment(decimal amount, string payPalMail)
    {
        try
        {
            var result = _paymentStrategy.ProcessPayment(amount, payPalMail);
            _logger.LogInformation(result);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing PayPal payment.");
            return StatusCode(500, "An error occurred while processing the payment.");
        }
    }
}