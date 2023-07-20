using CarShopAPI.Controllers;
using DAL.Db;
using DAL.Models;
using DAL.Models.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CarShopAPI.Tests.ControllerTests;

public class AddFuncPriceControllerTests
{
    #region Positive Tests
    [Fact]
    public void Get_ReturnsOk_WhenFuncPriceSuccessfully()
    {
        // Arrange
        var mockAddFuncPriceService = new Mock<IService<AddFuncPrice>>();
        var addFuncPrices = new List<AddFuncPrice>();

        mockAddFuncPriceService.Setup(service => service.Get()).Returns(addFuncPrices);

        var controller = new AddFuncPriceController(mockAddFuncPriceService.Object, null);

        // Act
        var result = controller.Get();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void GetById_ReturnsOk_WhenFuncPriceSuccessfully()
    {
        // Arrange
        var mockAddFuncPriceService = new Mock<IService<AddFuncPrice>>();
        var addFuncPrice = new AddFuncPrice();
        var addFuncPriceId = Guid.NewGuid();

        mockAddFuncPriceService.Setup(service => service.GetById(addFuncPriceId)).Returns(addFuncPrice);

        var controller = new AddFuncPriceController(mockAddFuncPriceService.Object, null);

        // Act
        var result = controller.GetById(addFuncPriceId);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Insert_ReturnsOk_WhenFuncPriceSuccessfully()
    {
        // Arrange
        var mockAddFuncPriceServiceDTO = new Mock<IService<AddFuncPriceDTO>>();
        var addFuncPriceDTO = new AddFuncPriceDTO();

        mockAddFuncPriceServiceDTO.Setup(service => service.Insert(addFuncPriceDTO)).Returns(true);

        var controller = new AddFuncPriceController(null, mockAddFuncPriceServiceDTO.Object);

        // Act
        var result = controller.Insert(addFuncPriceDTO);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Update_ReturnsOk_WhenFuncPriceSuccessfully()
    {
        // Arrange
        var mockAddFuncPriceService = new Mock<IService<AddFuncPrice>>();
        var addFuncPrice = new AddFuncPrice();

        mockAddFuncPriceService.Setup(service => service.Update(addFuncPrice)).Returns(true);

        var controller = new AddFuncPriceController(mockAddFuncPriceService.Object, null);

        // Act
        var result = controller.Update(addFuncPrice);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Delete_ReturnsOk_WhenFuncPriceSuccessfully()
    {
        // Arrange
        var mockAddFuncPriceService = new Mock<IService<AddFuncPrice>>();
        var addFuncPrice = new AddFuncPrice();
        Guid addFuncPriceId = Guid.NewGuid();

        mockAddFuncPriceService.Setup(service => service.GetById(addFuncPriceId)).Returns(addFuncPrice);

        var controller = new AddFuncPriceController(mockAddFuncPriceService.Object, null);

        // Act
        var result = controller.GetById(addFuncPriceId);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }
    #endregion

    #region Negative Tests
    [Fact]
    public void GetById_ShouldReturnNotFound_WhenAddFuncPriceNotFound()
    {
        // Arrange
        var mockAddFuncPriceService = new Mock<IService<AddFuncPrice>>();
        var addFuncPriceId = Guid.NewGuid();

        mockAddFuncPriceService.Setup(service => service.GetById(addFuncPriceId)).Returns((AddFuncPrice)null);

        var controller = new AddFuncPriceController(mockAddFuncPriceService.Object, null);

        // Act
        var result = controller.GetById(addFuncPriceId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void Insert_BadRequest_ShouldReturn400WhenInvalidData()
    {
        // Arrange
        var mockAddFuncPriceServiceDTO = new Mock<IService<AddFuncPriceDTO>>();
        var addFuncPriceDTO = new AddFuncPriceDTO();

        mockAddFuncPriceServiceDTO.Setup(service => service.Insert(addFuncPriceDTO)).Returns(null);

        var controller = new AddFuncPriceController(null, mockAddFuncPriceServiceDTO.Object);

        // Act
        var result = controller.Insert(addFuncPriceDTO);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public void Update_BadRequest_ShouldReturn400WhenInvalidData()
    {
        // Arrange
        var mockAddFuncPriceService = new Mock<IService<AddFuncPrice>>();
        var addFuncPrice = new AddFuncPrice();

        mockAddFuncPriceService.Setup(service => service.Update(addFuncPrice)).Returns(null);

        var controller = new AddFuncPriceController(mockAddFuncPriceService.Object, null);

        // Act
        var result = controller.Update(addFuncPrice);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public void Delete_BadRequest_ShouldReturn400WhenInvalidData()
    {
        // Arrange
        var mockAddFuncPriceService = new Mock<IService<AddFuncPrice>>();
        Guid addFuncPriceId = Guid.NewGuid();

        mockAddFuncPriceService.Setup(service => service.GetById(addFuncPriceId)).Returns((AddFuncPrice)null);

        var controller = new AddFuncPriceController(mockAddFuncPriceService.Object, null);

        // Act
        var result = controller.GetById(addFuncPriceId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
    #endregion
}