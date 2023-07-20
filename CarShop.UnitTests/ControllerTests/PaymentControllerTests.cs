using BLL.Services.PaymentSystem;
using CarShopAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopAPI.Tests.ControllerTests;

public class PaymentControllerTests
{
    #region Positive Tests

    [Fact]
    public void ProcessCreditCardPayment_ReturnsOk_WhenPaymentProcessedSuccessfully()
    {
        // Arrange
        var mockPaymentStrategy = new Mock<IPaymentStrategy>();
        var mockLogger = new Mock<ILogger<PaymentController>>();

        var amount = 100.00m;
        var cardNumber = "1234-5678-9012-3456";

        var controller = new PaymentController(mockPaymentStrategy.Object, mockLogger.Object);

        // Act
        var result = controller.ProcessCreditCardPayment(amount, cardNumber);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void ProcessPayPalPayment_ReturnsOk_WhenPaymentProcessedSuccessfully()
    {
        // Arrange
        var mockPaymentStrategy = new Mock<IPaymentStrategy>();
        var mockLogger = new Mock<ILogger<PaymentController>>();

        var amount = 50.00m;
        var payPalMail = "user@example.com";

        var controller = new PaymentController(mockPaymentStrategy.Object, mockLogger.Object);

        // Act
        var result = controller.ProcessPayPalPayment(amount, payPalMail);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    #endregion
}
