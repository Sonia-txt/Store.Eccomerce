
using Microsoft.AspNetCore.Mvc;
using Store.Proyect.Api.Repositories.Interfaces;
using Store.Proyect.Core.Entities;
using Store.Proyect.Core.Http;

namespace Store.Proyect.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<User>>>> GetAll()
    {
        var users = await _userRepository.GetAllAsync();
        var response = new Response<List<User>>
        {
            Data = users
        };

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<User>>> Get(int id)
    {
        var user = await _userRepository.GetById(id);
        var response = new Response<User>();

        if (user == null)
        {
            response.Errors.Add("USER NOT FOUND");
            return NotFound(response);
        }

        response.Data = user;
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<User>>> Post([FromBody] User user)
    {
        var result = await _userRepository.SaveAsync(user);
        var response = new Response<User>
        {
            Data = result
        };

        return Created($"/api/[controller]/{result.Id}", response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<User>>> Update([FromBody] User user)
    {
        var result = await _userRepository.UpdateAsync(user);
        var response = new Response<User>
        {
            Data = result
        };

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _userRepository.DeleteAsync(id);
        var response = new Response<bool>
        {
            Data = result
        };

        return Ok(response);
    }
}