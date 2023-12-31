﻿using DAL.Db;
using DAL.Models;
using DAL.Models.ModelsDTO;
using DAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarPhotoController : ControllerBase
{
    private readonly IService<CarPhoto> _carPhotoService;
    private readonly IService<CarPhotoDTO> _carPhotoDTOService;

    public CarPhotoController(IService<CarPhoto> carPhotoService, IService<CarPhotoDTO> carPhotoDTOService)
    {
        _carPhotoService = carPhotoService;
        _carPhotoDTOService = carPhotoDTOService;
    }

    [HttpGet]
    public ActionResult<List<CarPhoto>> Get()
    {
        List<CarPhoto> order = _carPhotoService.Get();
        return Ok(order);
    }

    [HttpGet("{id}")]
    public ActionResult<CarPhoto> GetById(Guid id)
    {
        CarPhoto order = _carPhotoService.GetById(id);
        if (order != null) return Ok(order);
        return NotFound();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("save")]
    public ActionResult<CarPhoto> Insert(CarPhotoDTO carPhoto)
    {
        bool result = _carPhotoDTOService.Insert(carPhoto);
        if (result) return Ok(carPhoto);
        return BadRequest();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("update")]
    public ActionResult<CarPhoto> Update(CarPhoto carPhoto)
    {
        bool result = _carPhotoService.Update(carPhoto);
        if (result) return Ok(carPhoto);
        return BadRequest();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("delete")]
    public ActionResult<CarPhoto> Delete(Guid id)
    {
        bool result = _carPhotoService.Delete(id);
        if (result) return Ok();
        return BadRequest();
    }
}
