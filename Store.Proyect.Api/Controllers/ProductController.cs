using Microsoft.AspNetCore.Mvc;
using Store.Proyect.Api.Repositories.Interfaces; 
using Store.Proyect.Core.Entities;
using Store.Proyect.Core.Http;

namespace Store.Proyect.Api.Controllers;

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
        return Ok(new Response<List<Product>> { Data = products });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Response<Product>>> Get(int id)
    {
        var product = await _productRepository.GetById(id);
        if (product == null)
        {
            var errorResponse = new Response<Product>();
            errorResponse.Errors.Add("PRODUCT NOT FOUND");
            return NotFound(errorResponse);
        }

        return Ok(new Response<Product> { Data = product });
    }

    [HttpPost]
    public async Task<ActionResult<Response<Product>>> Post([FromBody] Product product)
    {
        var result = await _productRepository.SaveAsync(product);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, new Response<Product> { Data = result });
    }

    [HttpPut]
    public async Task<ActionResult<Response<Product>>> Update([FromBody] Product product)
    {
        var result = await _productRepository.UpdateAsync(product);
        return Ok(new Response<Product> { Data = result });
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _productRepository.DeleteAsync(id);
        return Ok(new Response<bool> { Data = result });
    }
}