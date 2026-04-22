using Microsoft.AspNetCore.Mvc;
using Store.Proyect.Api.Repositories.Interfaces; 
using Store.Proyect.Core.Entities;
using Store.Proyect.Core.Http;

namespace Store.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Product>>>> GetAll()
    {
        var products = await _productRepository.GetAllAsync();
        var response = new Response<List<Product>>
        {
            Data = products
        };
        
        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Product>>> Get(int id)
    {
        var product = await _productRepository.GetById(id);
        var response = new Response<Product>();
        
        if (product == null)
        {
            response.Errors.Add("PRODUCT NOT FOUND");
            return NotFound(response);
        }

        response.Data = product;
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Product>>> Post([FromBody] Product product)
    {
        var result = await _productRepository.SaveAsync(product);
        var response = new Response<Product>
        {
            Data = result
        };

        return Created($"/api/[controller]/{result.Id}", response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Product>>> Update([FromBody] Product product)
    {
        var result = await _productRepository.UpdateAsync(product);
        var response = new Response<Product>
        {
            Data = result
        };
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _productRepository.DeleteAsync(id);
        var response = new Response<bool>
        {
            Data = result
        };
        
        return Ok(response);
    }
}