using BLL.Services.SearchingServices;
using DAL.Models;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchingOrderController : ControllerBase
{
    private readonly SearchingOrderService _searchingOrderService;

    public SearchingOrderController(SearchingOrderService searchingOrderService)
    {
        _searchingOrderService = searchingOrderService;
    }

    [HttpGet("{iduser}")]
    public ActionResult<Order> GetByIdUser(Guid idUser)
    {
        Order order = _searchingOrderService.SearchOrderByUserId(idUser);
        if (order != null) return Ok(order);
        return NotFound();
    }

    [HttpGet("nameuser")]
    public ActionResult<List<Order>> GetByNameUser(string name = null, string lastName = null)
    {
        List<Order> order = _searchingOrderService.SearchOrderByFullNameUser(name, lastName);
        if (order != null) return Ok(order);
        return NotFound();
    }

    [HttpGet("brandcar")]
    public ActionResult<List<Order>> GetByBrandCar(string brand)
    {
        List<Order> order = _searchingOrderService.SearchOrderByBrandCar(brand);
        if (order != null) return Ok(order);
        return NotFound();
    }

    [HttpGet("modelcar")]
    public ActionResult<List<Order>> GetByModelCar(string model)
    {
        List<Order> order = _searchingOrderService.SearchOrderByModelCar(model);
        if (order != null) return Ok(order);
        return NotFound();
    }

    [HttpGet("categorycar")]
    public ActionResult<List<Order>> GetByCategoryCar(string category)
    {
        List<Order> order = _searchingOrderService.SearchOrderByCategoryCar(category);
        if (order != null) return Ok(order);
        return NotFound();
    }

    [HttpGet("pricecar")]
    public ActionResult<List<Order>> GetByPriceRangeCar(decimal minPrice = 0, decimal maxPrice = 0)
    {
        List<Order> order = _searchingOrderService.SearchOrderByPriceRangeCar(minPrice, maxPrice);
        if (order != null) return Ok(order);
        return NotFound();
    }
}
