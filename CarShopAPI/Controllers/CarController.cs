﻿using DAL.Db;
using DAL.Models;
using DAL.Models.ModelsDTO;
using DAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    [Authorize(Roles = "Admin")]
    public ActionResult<Car> Insert(CarDTO carDTO)
    {
        Car car = new Car
        {
            Id = Guid.NewGuid(),
            Brand = carDTO.Brand,
            Model = carDTO.Model,
            Category = carDTO.Category,
            DateCreated = carDTO.DateCreated,
            StandartColor = carDTO.StandartColor,
            Count = carDTO.Count,
            Price = carDTO.Price
        };
        bool result = _carService.Insert(car);
        if (result) return Ok(car);
        return BadRequest();
    }

    [HttpPut("update")]
    [Authorize(Roles = "Admin")]
    public ActionResult<Car> Update(Car car)
    {
        bool result = _carService.Update(car);
        if (result) return Ok(car);
        return BadRequest();
    }

    [HttpDelete("delete")]
    [Authorize(Roles = "Admin")]
    public ActionResult<Car> Delete(Guid id)
    {
        bool result = _carService.Delete(id);
        if (result) return Ok();
        return BadRequest();
    }
}
