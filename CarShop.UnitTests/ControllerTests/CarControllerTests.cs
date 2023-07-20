using CarShopAPI.Controllers;
using DAL.Db;
using DAL.Models;
using DAL.Models.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarShopAPI.Tests.ControllerTests;

public class CarControllerTests
{
    #region Positive Tests
    [Fact]
    public void Get_ReturnsOk_WhenCarSuccessfully()
    {
        // Arrange
        var mockCarService = new Mock<IService<Car>>();
        var car = new List<Car>();

        mockCarService.Setup(service => service.Get()).Returns(car);

        var controller = new CarController(mockCarService.Object);

        // Act
        var result = controller.Get();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void GetById_ReturnsOk_WhenCarSuccessfully()
    {
        // Arrange
        var mockCarService = new Mock<IService<Car>>();
        var car = new Car();
        var carId = Guid.NewGuid();

        mockCarService.Setup(service => service.GetById(carId)).Returns(car);

        var controller = new CarController(mockCarService.Object);

        // Act
        var result = controller.GetById(carId);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Insert_ReturnsOk_WhenCarSuccessfully()
    {
        // Arrange
        var mockCarService = new Mock<IService<Car>>();
        var carDTO = new CarDTO();
        var car = new Car();

        mockCarService.Setup(service => service.Insert(It.IsAny<Car>())).Returns(true);

        var controller = new CarController(mockCarService.Object);

        // Act
        var result = controller.Insert(carDTO);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Update_ReturnsOk_WhenCarSuccessfully()
    {
        // Arrange
        var mockCarService = new Mock<IService<Car>>();
        var car = new Car();

        mockCarService.Setup(service => service.Update(car)).Returns(true);

        var controller = new CarController(mockCarService.Object);

        // Act
        var result = controller.Update(car);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Delete_ReturnsOk_WhenCarSuccessfully()
    {
        // Arrange
        var mockCarService = new Mock<IService<Car>>();
        var car = new Car();
        var carId = Guid.NewGuid();

        mockCarService.Setup(service => service.Delete(carId)).Returns(true);

        var controller = new CarController(mockCarService.Object);

        // Act
        var result = controller.Delete(carId);

        // Assert
        Assert.IsType<OkResult>(result.Result);
    }
    #endregion

    #region Negative Tests
    [Fact]
    public void GetById_ShouldReturnNotFound_WhenCarNotFound()
    {
        // Arrange
        var mockCarService = new Mock<IService<Car>>();
        var carId = Guid.NewGuid();

        mockCarService.Setup(service => service.GetById(carId)).Returns((Car)null);

        var controller = new CarController(mockCarService.Object);

        // Act
        var result = controller.GetById(carId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void Insert_BadRequest_ShouldReturn400WhenInvalidData()
    {
        // Arrange
        var mockCarService = new Mock<IService<Car>>();
        var carDTO = new CarDTO();
        var car = new Car();

        mockCarService.Setup(service => service.Insert(It.IsAny<Car>())).Returns(null);

        var controller = new CarController(mockCarService.Object);

        // Act
        var result = controller.Insert(carDTO);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public void Update_BadRequest_ShouldReturn400WhenInvalidData()
    {
        // Arrange
        var mockCarService = new Mock<IService<Car>>();
        var car = new Car();

        mockCarService.Setup(service => service.Update(car)).Returns(null);

        var controller = new CarController(mockCarService.Object);

        // Act
        var result = controller.Update(car);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public void Delete_BadRequest_ShouldReturn400WhenInvalidData()
    {
        // Arrange
        var mockCarService = new Mock<IService<Car>>();
        var carId = Guid.NewGuid();

        mockCarService.Setup(service => service.Delete(carId)).Returns(null);

        var controller = new CarController(mockCarService.Object);

        // Act
        var result = controller.Delete(carId);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }
    #endregion
}
