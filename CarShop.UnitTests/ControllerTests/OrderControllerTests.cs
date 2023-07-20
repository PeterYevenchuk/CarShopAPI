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

public class OrderControllerTests
{
    #region Positive Tests

    [Fact]
    public void Get_ReturnsOk_WhenOrdersSuccessfullyRetrieved()
    {
        // Arrange
        var mockOrderService = new Mock<IService<Order>>();
        var orders = new List<Order>();

        mockOrderService.Setup(service => service.Get()).Returns(orders);

        var controller = new OrderController(mockOrderService.Object, null);

        // Act
        var result = controller.Get();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void GetById_ReturnsOk_WhenOrderSuccessfullyRetrieved()
    {
        // Arrange
        var mockOrderService = new Mock<IService<Order>>();
        var order = new Order();
        var orderId = Guid.NewGuid();

        mockOrderService.Setup(service => service.GetById(orderId)).Returns(order);

        var controller = new OrderController(mockOrderService.Object, null);

        // Act
        var result = controller.GetById(orderId);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Insert_ReturnsOk_WhenOrderSuccessfullyInserted()
    {
        // Arrange
        var mockOrderServiceDTO = new Mock<IService<OrderDTO>>();
        var orderDTO = new OrderDTO();

        mockOrderServiceDTO.Setup(service => service.Insert(orderDTO)).Returns(true);

        var controller = new OrderController(null, mockOrderServiceDTO.Object);

        // Act
        var result = controller.Insert(orderDTO);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Update_ReturnsOk_WhenOrderSuccessfullyUpdated()
    {
        // Arrange
        var mockOrderService = new Mock<IService<Order>>();
        var order = new Order();

        mockOrderService.Setup(service => service.Update(order)).Returns(true);

        var controller = new OrderController(mockOrderService.Object, null);

        // Act
        var result = controller.Update(order);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Delete_ReturnsOk_WhenOrderSuccessfullyDeleted()
    {
        // Arrange
        var mockOrderService = new Mock<IService<Order>>();
        var orderId = Guid.NewGuid();

        mockOrderService.Setup(service => service.Delete(orderId)).Returns(true);

        var controller = new OrderController(mockOrderService.Object, null);

        // Act
        var result = controller.Delete(orderId);

        // Assert
        Assert.IsType<OkResult>(result.Result);
    }

    #endregion

    #region Negative Tests

    [Fact]
    public void GetById_ReturnsNotFound_WhenOrderNotFound()
    {
        // Arrange
        var mockOrderService = new Mock<IService<Order>>();
        var orderId = Guid.NewGuid();

        mockOrderService.Setup(service => service.GetById(orderId)).Returns((Order)null);

        var controller = new OrderController(mockOrderService.Object, null);

        // Act
        var result = controller.GetById(orderId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void Insert_ReturnsBadRequest_WhenInvalidData()
    {
        // Arrange
        var mockOrderServiceDTO = new Mock<IService<OrderDTO>>();
        var orderDTO = new OrderDTO();

        mockOrderServiceDTO.Setup(service => service.Insert(orderDTO)).Returns(false);

        var controller = new OrderController(null, mockOrderServiceDTO.Object);

        // Act
        var result = controller.Insert(orderDTO);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public void Update_ReturnsBadRequest_WhenInvalidData()
    {
        // Arrange
        var mockOrderService = new Mock<IService<Order>>();
        var order = new Order();

        mockOrderService.Setup(service => service.Update(order)).Returns(false);

        var controller = new OrderController(mockOrderService.Object, null);

        // Act
        var result = controller.Update(order);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public void Delete_ReturnsBadRequest_WhenInvalidData()
    {
        // Arrange
        var mockOrderService = new Mock<IService<Order>>();
        var orderId = Guid.NewGuid();

        mockOrderService.Setup(service => service.Delete(orderId)).Returns(false);

        var controller = new OrderController(mockOrderService.Object, null);

        // Act
        var result = controller.Delete(orderId);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    #endregion
}
