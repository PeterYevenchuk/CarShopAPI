using BLL.Services.SearchingServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchingCarController : ControllerBase
{
    private readonly SearchingCarService _searchingCarService;

    public SearchingCarController(SearchingCarService searchingCarService)
    {
        _searchingCarService = searchingCarService;
    }

    [HttpGet("brandcar")]
    public ActionResult<List<Car>> GetByBrandCar(string brand)
    {
        List<Car> order = _searchingCarService.SearchCarByBrand(brand);
        if (order != null) return Ok(order);
        return NotFound();
    }

    [HttpGet("modelcar")]
    public ActionResult<List<Car>> GetByModelCar(string model)
    {
        List<Car> order = _searchingCarService.SearchCarByModel(model);
        if (order != null) return Ok(order);
        return NotFound();
    }

    [HttpGet("categorycar")]
    public ActionResult<List<Car>> GetByCategoryCar(string category)
    {
        List<Car> order = _searchingCarService.SearchCarByCategory(category);
        if (order != null) return Ok(order);
        return NotFound();
    }

    [HttpGet("nameuser")]
    public ActionResult<List<Car>> GetByPriceRangeCar(decimal minPrice = 0, decimal maxPrice = 0)
    {
        List<Car> order = _searchingCarService.SearchCarByPriceRange(minPrice, maxPrice);
        if (order != null) return Ok(order);
        return NotFound();
    }

}
