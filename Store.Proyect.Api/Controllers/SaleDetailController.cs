
using Microsoft.AspNetCore.Mvc;
using Store.Proyect.Api.Repositories.Interfaces;
using Store.Proyect.Core.Entities;
using Store.Proyect.Core.Http;

namespace Store.Proyect.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleDetailController : ControllerBase
{
    private readonly ISaleDetailRepository _saleDetailRepository;

    public SaleDetailController(ISaleDetailRepository saleDetailRepository)
    {
        _saleDetailRepository = saleDetailRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<SaleDetail>>>> GetAll()
    {
        var details = await _saleDetailRepository.GetAllAsync();
        var response = new Response<List<SaleDetail>>
        {
            Data = details
        };

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<SaleDetail>>> Get(int id)
    {
        var detail = await _saleDetailRepository.GetById(id);
        var response = new Response<SaleDetail>();

        if (detail == null)
        {
            response.Errors.Add("SALE DETAIL NOT FOUND");
            return NotFound(response);
        }

        response.Data = detail;
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<SaleDetail>>> Post([FromBody] SaleDetail saleDetail)
    {
        var result = await _saleDetailRepository.SaveAsync(saleDetail);
        var response = new Response<SaleDetail>
        {
            Data = result
        };

        return Created($"/api/[controller]/{result.Id}", response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<SaleDetail>>> Update([FromBody] SaleDetail saleDetail)
    {
        var result = await _saleDetailRepository.UpdateAsync(saleDetail);
        var response = new Response<SaleDetail>
        {
            Data = result
        };

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _saleDetailRepository.DeleteAsync(id);
        var response = new Response<bool>
        {
            Data = result
        };

        return Ok(response);
    }
}