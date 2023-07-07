using BLL.Helpers.EmailValidation;
using BLL.Helpers.PasswordValidation;
using BLL.Services.ChangePasswordServices;
using BLL.Services.DTOService;
using DAL.Db;
using DAL.Models;
using DAL.Models.ModelsDTO;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddFuncPriceController : ControllerBase
{
    private readonly IService<AddFuncPrice> _addFuncPriceService;
    private readonly IService<AddFuncPriceDTO> _addFuncPriceDTOService;

    public AddFuncPriceController(IService<AddFuncPrice> addFuncPriceService, IService<AddFuncPriceDTO> addFuncPriceDTOService)
    {
        _addFuncPriceService = addFuncPriceService;
        _addFuncPriceDTOService = addFuncPriceDTOService;
    }

    [HttpGet]
    public ActionResult<List<AddFuncPrice>> Get()
    {
        List<AddFuncPrice> additionalFunctionalityPrice = _addFuncPriceService.Get();

        return Ok(additionalFunctionalityPrice);
    }

    [HttpGet("{id}")]
    public ActionResult<AddFuncPrice> GetById(Guid id)
    {
        AddFuncPrice additionalFunctionalityPrice = _addFuncPriceService.GetById(id);
        if (additionalFunctionalityPrice != null) return Ok(additionalFunctionalityPrice);
        return NotFound();
    }

    [HttpPost("save")]
    public ActionResult<AddFuncPrice> Insert(AddFuncPriceDTO additionalFunctionalityPriceDTO)
    {
        bool result = _addFuncPriceDTOService.Insert(additionalFunctionalityPriceDTO);
        if (result) return Ok(additionalFunctionalityPriceDTO);
        return BadRequest();
    }

    [HttpPut("update")]
    public ActionResult<AddFuncPrice> Update(AddFuncPrice addFuncPrice)
    {
        bool result = _addFuncPriceService.Update(addFuncPrice);
        if (result) return Ok(addFuncPrice);
        return BadRequest();
    }

    [HttpDelete("delete")]
    public ActionResult<AddFuncPrice> Delete(Guid id)
    {
        bool result = _addFuncPriceService.Delete(id);
        if (result) return Ok();
        return BadRequest();
    }
}
