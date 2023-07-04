using DAL.Db;
using DAL.Models;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/controller")]
public class CarController : ControllerBase
{
    private readonly IService<Car> _carService;

    public CarController(IService<Car> carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public ActionResult<List<Car>> Get()
    {
        List<Car> cars = _carService.Get();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetById(Guid id)
    {
        Car car = _carService.GetById(id);
        if (car != null) return Ok(car);
        return NotFound();
    }

    [HttpPost("save")]
    public ActionResult<Car> Insert(Car car)
    {
        bool result = _carService.Insert(car);
        if (result) return Ok(car);
        return BadRequest();
    }

    [HttpPut("update")]
    public ActionResult<Car> Update(Car car)
    {
        bool result = _carService.Update(car);
        if (result) return Ok(car);
        return BadRequest();
    }

    [HttpDelete("delete")]
    public ActionResult<Car> Delete(Guid id)
    {
        bool result = _carService.Delete(id);
        if (result) return Ok();
        return BadRequest();
    }
}
