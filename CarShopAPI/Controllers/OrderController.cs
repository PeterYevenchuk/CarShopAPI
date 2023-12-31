﻿using DAL.Db;
using DAL.Models;
using DAL.Models.ModelsDTO;
using DAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IService<Order> _orderService;
    private readonly IService<OrderDTO> _orderDTOService;

    public OrderController(IService<Order> orderService, IService<OrderDTO> orderDTOService)
    {
        _orderService = orderService;
        _orderDTOService = orderDTOService;
    }

    [HttpGet]
    public ActionResult<List<Order>> Get()
    {
        List<Order> order = _orderService.Get();
        return Ok(order);
    }

    [HttpGet("{id}")]
    public ActionResult<Order> GetById(Guid id)
    {
        Order order = _orderService.GetById(id);
        if (order != null) return Ok(order);
        return NotFound();
    }

    [Authorize(Roles = "User")]
    [HttpPost("save")]
    public ActionResult<Order> Insert(OrderDTO order)
    {
        bool result = _orderDTOService.Insert(order);
        if (result) return Ok(order);
        return BadRequest();
    }

    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "User")]
    [HttpPut("update")]
    public ActionResult<Order> Update(Order order)
    {
        bool result = _orderService.Update(order);
        if (result) return Ok(order);
        return BadRequest();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("delete")]
    public ActionResult<Order> Delete(Guid id)
    {
        bool result = _orderService.Delete(id);
        if (result) return Ok();
        return BadRequest();
    }
}
