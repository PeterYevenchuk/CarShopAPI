using DAL.Models;
using DAL.Services.SortingServices;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SortCarsController : ControllerBase
{
    private readonly SortCarsService _sortCarsService;

    public SortCarsController(SortCarsService sortCarsService)
    {
        _sortCarsService = sortCarsService;
    }

    [HttpGet("brand")]
    public ActionResult<List<Car>> GetCarsByBrand()
    {
        return _sortCarsService.GetCarsSortedByBrand();
    }

    [HttpGet("model")]
    public ActionResult<List<Car>> GetCarsByModel()
    {
        return _sortCarsService.GetCarsSortedByModel();
    }

    [HttpGet("category")]
    public ActionResult<List<Car>> GetCarsByCategory()
    {
        return _sortCarsService.GetCarsSortedByCategory();
    }

    [HttpGet("count")]
    public ActionResult<List<Car>> GetCarsByCount()
    {
        return _sortCarsService.GetCarsSortedByCount();
    }

    [HttpGet("price")]
    public ActionResult<List<Car>> GetCarsByPrice()
    {
        return _sortCarsService.GetCarsSortedByPrice();
    }
}
