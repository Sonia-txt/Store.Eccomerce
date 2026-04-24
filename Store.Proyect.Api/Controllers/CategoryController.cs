using Microsoft.AspNetCore.Mvc;
using Store.Proyect.Core.Entities;
using Store.Proyect.Core.Interfaces;

namespace Store.Proyect.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _repository;

    public CategoryController(ICategoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _repository.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Category category)
    {
        if (category == null) return BadRequest();
        
        var result = await _repository.AddAsync(category);
    

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Category category)
    {
        if (category == null) return BadRequest();
    
        var result = await _repository.UpdateAsync(category);
    
        if (result == null) return NotFound();
    
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _repository.DeleteAsync(id);
        if (!success) return NotFound();
        
        return NoContent();
    }
}