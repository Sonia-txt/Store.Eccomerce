
using Microsoft.AspNetCore.Mvc;
using Store.Proyect.Api.Repositories.Interfaces;
using Store.Proyect.Core.Entities;
using Store.Proyect.Core.Http;

namespace Store.Proyect.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleController : ControllerBase
{
    private readonly ISaleRepository _saleRepository;

    public SaleController(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Sale>>>> GetAll()
    {
        var sales = await _saleRepository.GetAllAsync();
        var response = new Response<List<Sale>>
        {
            Data = sales
        };

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Sale>>> Get(int id)
    {
        var sale = await _saleRepository.GetById(id);
        var response = new Response<Sale>();

        if (sale == null)
        {
            response.Errors.Add("SALE NOT FOUND");
            return NotFound(response);
        }

        response.Data = sale;
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Sale>>> Post([FromBody] Sale sale)
    {
        // En ventas, el Save suele incluir la lógica de persistir el encabezado y el detalle
        var result = await _saleRepository.SaveAsync(sale);
        var response = new Response<Sale>
        {
            Data = result
        };

        return Created($"/api/[controller]/{result.Id}", response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Sale>>> Update([FromBody] Sale sale)
    {
        var result = await _saleRepository.UpdateAsync(sale);
        var response = new Response<Sale>
        {
            Data = result
        };

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _saleRepository.DeleteAsync(id);
        var response = new Response<bool>
        {
            Data = result
        };

        return Ok(response);
    }
}