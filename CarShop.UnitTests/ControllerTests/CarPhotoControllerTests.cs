using CarShopAPI.Controllers;
using DAL.Db;
using DAL.Models.ModelsDTO;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopAPI.Tests.ControllerTests;

public class CarPhotoControllerTests
{
    #region Positive Tests

    [Fact]
    public void Get_ReturnsOk_WhenCarPhotosSuccessfullyRetrieved()
    {
        // Arrange
        var mockCarPhotoService = new Mock<IService<CarPhoto>>();
        var carPhotos = new List<CarPhoto>();
        mockCarPhotoService.Setup(service => service.Get()).Returns(carPhotos);
        var controller = new CarPhotoController(mockCarPhotoService.Object, null);

        // Act
        var result = controller.Get();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void GetById_ReturnsOk_WhenCarPhotoSuccessfullyRetrieved()
    {
        // Arrange
        var mockCarPhotoService = new Mock<IService<CarPhoto>>();
        var carPhoto = new CarPhoto();
        var carPhotoId = Guid.NewGuid();
        mockCarPhotoService.Setup(service => service.GetById(carPhotoId)).Returns(carPhoto);
        var controller = new CarPhotoController(mockCarPhotoService.Object, null);

        // Act
        var result = controller.GetById(carPhotoId);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Insert_ReturnsOk_WhenCarPhotoSuccessfullyInserted()
    {
        // Arrange
        var mockCarPhotoDTOService = new Mock<IService<CarPhotoDTO>>();
        var carPhotoDTO = new CarPhotoDTO();
        mockCarPhotoDTOService.Setup(service => service.Insert(carPhotoDTO)).Returns(true);
        var controller = new CarPhotoController(null, mockCarPhotoDTOService.Object);

        // Act
        var result = controller.Insert(carPhotoDTO);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Update_ReturnsOk_WhenCarPhotoSuccessfullyUpdated()
    {
        // Arrange
        var mockCarPhotoService = new Mock<IService<CarPhoto>>();
        var carPhoto = new CarPhoto();
        mockCarPhotoService.Setup(service => service.Update(carPhoto)).Returns(true);
        var controller = new CarPhotoController(mockCarPhotoService.Object, null);

        // Act
        var result = controller.Update(carPhoto);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Delete_ReturnsOk_WhenCarPhotoSuccessfullyDeleted()
    {
        // Arrange
        var mockCarPhotoService = new Mock<IService<CarPhoto>>();
        var carPhotoId = Guid.NewGuid();
        mockCarPhotoService.Setup(service => service.Delete(carPhotoId)).Returns(true);
        var controller = new CarPhotoController(mockCarPhotoService.Object, null);

        // Act
        var result = controller.Delete(carPhotoId);

        // Assert
        Assert.IsType<OkResult>(result.Result);
    }

    #endregion

    #region Negative Tests

    [Fact]
    public void GetById_ReturnsNotFound_WhenCarPhotoNotFound()
    {
        // Arrange
        var mockCarPhotoService = new Mock<IService<CarPhoto>>();
        var carPhotoId = Guid.NewGuid();
        mockCarPhotoService.Setup(service => service.GetById(carPhotoId)).Returns((CarPhoto)null);
        var controller = new CarPhotoController(mockCarPhotoService.Object, null);

        // Act
        var result = controller.GetById(carPhotoId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void Insert_ReturnsBadRequest_WhenInvalidCarPhotoData()
    {
        // Arrange
        var mockCarPhotoDTOService = new Mock<IService<CarPhotoDTO>>();
        var carPhotoDTO = new CarPhotoDTO();
        mockCarPhotoDTOService.Setup(service => service.Insert(carPhotoDTO)).Returns(false);
        var controller = new CarPhotoController(null, mockCarPhotoDTOService.Object);

        // Act
        var result = controller.Insert(carPhotoDTO);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public void Update_ReturnsBadRequest_WhenInvalidCarPhotoData()
    {
        // Arrange
        var mockCarPhotoService = new Mock<IService<CarPhoto>>();
        var carPhoto = new CarPhoto();
        mockCarPhotoService.Setup(service => service.Update(carPhoto)).Returns(false);
        var controller = new CarPhotoController(mockCarPhotoService.Object, null);

        // Act
        var result = controller.Update(carPhoto);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public void Delete_ReturnsBadRequest_WhenInvalidCarPhotoData()
    {
        // Arrange
        var mockCarPhotoService = new Mock<IService<CarPhoto>>();
        var carPhotoId = Guid.NewGuid();
        mockCarPhotoService.Setup(service => service.Delete(carPhotoId)).Returns(false);
        var controller = new CarPhotoController(mockCarPhotoService.Object, null);

        // Act
        var result = controller.Delete(carPhotoId);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    #endregion
}
