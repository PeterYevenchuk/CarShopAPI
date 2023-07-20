using BLL.Helpers.PasswordHasher;
using BLL.Services.ChangePasswordServices;
using CarShopAPI.Controllers;
using DAL.Db;
using DAL.Models.ModelsDTO;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CarShopAPI.Tests.ControllerTests;

public class UserControllerTests
{
    #region Positive Tests
    [Fact]
    public void Get_ReturnsOk_WhenUsersFound()
    {
        // Arrange
        var mockUserService = new Mock<IService<User>>();
        var users = new List<User>();

        mockUserService.Setup(service => service.Get()).Returns(users);

        var controller = new UserController(mockUserService.Object, null, null);

        // Act
        var result = controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedUsers = Assert.IsType<List<User>>(okResult.Value);
        Assert.Equal(users.Count, returnedUsers.Count);
    }

    [Fact]
    public void GetById_ReturnsOk_WhenUserFound()
    {
        // Arrange
        var mockUserService = new Mock<IService<User>>();
        var userId = Guid.NewGuid();
        var user = new User();

        mockUserService.Setup(service => service.GetById(userId)).Returns(user);

        var controller = new UserController(mockUserService.Object, null, null);

        // Act
        var result = controller.GetById(userId);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Insert_ReturnsOk_WhenUserInserted()
    {
        // Arrange
        var mockUserService = new Mock<IService<User>>();
        var mockPasswordHasher = new Mock<IPasswordHash>();
        var userDTO = new UserDTO
        {
            Name = "John",
            Email = "john@example.com",
            Password = "P@ssw0rd",
            Role = RoleType.User
        };

        mockPasswordHasher.Setup(hasher => hasher.EncryptPassword(userDTO.Password, It.IsAny<byte[]>())).Returns(userDTO.Password);
        mockUserService.Setup(service => service.Insert(It.IsAny<User>())).Returns(true);

        var controller = new UserController(mockUserService.Object, mockPasswordHasher.Object, null);

        // Act
        var result = controller.Insert(userDTO);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void Update_ReturnsOk_WhenUserUpdated()
    {
        // Arrange
        var mockUserService = new Mock<IService<User>>();
        var user = new User { Id = Guid.NewGuid(), Name = "John", Email = "john@example.com" };

        mockUserService.Setup(service => service.Update(user)).Returns(true);

        var controller = new UserController(mockUserService.Object, null, null);

        // Act
        var result = controller.Update(user);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void Delete_ReturnsOk_WhenUserDeleted()
    {
        // Arrange
        var mockUserService = new Mock<IService<User>>();
        var userId = Guid.NewGuid();

        mockUserService.Setup(service => service.Delete(userId)).Returns(true);

        var controller = new UserController(mockUserService.Object, null, null);

        // Act
        var result = controller.Delete(userId);

        // Assert
        Assert.IsType<OkResult>(result);
    }
    #endregion

    #region Negative Tests
    [Fact]
    public void GetById_ShouldReturnNotFound_WhenUserNotFound()
    {
        // Arrange
        var mockUserService = new Mock<IService<User>>();
        var userId = Guid.NewGuid();

        mockUserService.Setup(service => service.GetById(userId)).Returns((User)null);

        var controller = new UserController(mockUserService.Object, null, null);

        // Act
        var result = controller.GetById(userId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void Update_BadRequest_ShouldReturnBadRequestWhenInvalidEmail()
    {
        // Arrange
        var mockUserService = new Mock<IService<User>>();
        var user = new User();

        var controller = new UserController(mockUserService.Object, null, null);

        // Act
        var result = controller.Update(user);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public void Delete_ShouldReturnNotFound_WhenUserNotFound()
    {
        // Arrange
        var mockUserService = new Mock<IService<User>>();
        var userId = Guid.NewGuid();

        mockUserService.Setup(service => service.Delete(userId)).Returns(false); // User not found

        var controller = new UserController(mockUserService.Object, null, null);

        // Act
        var result = controller.Delete(userId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
    #endregion
}
