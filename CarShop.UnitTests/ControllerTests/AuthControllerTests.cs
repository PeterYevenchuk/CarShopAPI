using CarShop.API.Controllers;
using CarShop.BLL.Services.BasicServices;
using DAL.Models.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CarShopAPI.Tests.ControllerTests;

public class AuthControllerTests
{
    #region Positive Tests
    [Fact]
    public void Login_ShouldReturnToken_WhenValidCredentialsProvided()
    {
        // Arrange
        var mockAuthService = new Mock<IAuthService>();
        var loginDTO = new LoginDTO();

        mockAuthService.Setup(service => service.AuthenticateUser(loginDTO.Login, loginDTO.Password)).Returns(string.Empty);

        var controller = new AuthController(mockAuthService.Object);

        // Act
        var result = controller.Login(loginDTO);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }
    #endregion

    #region Negative Tests
    [Fact]
    public void Login_Returns401_WhenInvalidCredentialsProvided()
    {
        // Arrange
        var mockAuthService = new Mock<IAuthService>();
        var loginDTO = new LoginDTO();

        mockAuthService.Setup(service => service.AuthenticateUser(loginDTO.Login, loginDTO.Password)).Returns((string)null);

        var controller = new AuthController(mockAuthService.Object);

        // Act
        var result = controller.Login(loginDTO);

        // Assert
        Assert.IsType<UnauthorizedObjectResult>(result.Result);
    }
    #endregion
}
