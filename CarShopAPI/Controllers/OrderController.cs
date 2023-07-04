using DAL.Db;
using DAL.Models;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IService<Order> _orderService;

    public OrderController(IService<Order> orderService)
    {
        _orderService = orderService;
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

    [HttpPost("save")]
    public ActionResult<Order> Insert(Order order)
    {
        bool result = _orderService.Insert(order);
        if (result) return Ok(order);
        return BadRequest();
    }

    [HttpPut("update")]
    public ActionResult<Order> Update(Order order)
    {
        bool result = _orderService.Update(order);
        if (result) return Ok(order);
        return BadRequest();
    }

    [HttpDelete("delete")]
    public ActionResult<Order> Delete(Guid id)
    {
        bool result = _orderService.Delete(id);
        if (result) return Ok();
        return BadRequest();
    }
}
