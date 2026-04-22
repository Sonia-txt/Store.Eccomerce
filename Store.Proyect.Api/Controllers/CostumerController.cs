
using Microsoft.AspNetCore.Mvc;
using Store.Proyect.Api.Repositories.Interfaces;
using Store.Proyect.Core.Entities;
using Store.Proyect.Core.Http;

namespace Store.Proyect.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Customer>>>> GetAll()
    {
        var customers = await _customerRepository.GetAllAsync();
        var response = new Response<List<Customer>>
        {
            Data = customers
        };

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Customer>>> Get(int id)
    {
        var customer = await _customerRepository.GetById(id);
        var response = new Response<Customer>();

        if (customer == null)
        {
            response.Errors.Add("CUSTOMER NOT FOUND");
            return NotFound(response);
        }

        response.Data = customer;
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Customer>>> Post([FromBody] Customer customer)
    {
        var result = await _customerRepository.SaveAsync(customer);
        var response = new Response<Customer>
        {
            Data = result
        };

        return Created($"/api/[controller]/{result.Id}", response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Customer>>> Update([FromBody] Customer customer)
    {
        var result = await _customerRepository.UpdateAsync(customer);
        var response = new Response<Customer>
        {
            Data = result
        };

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _customerRepository.DeleteAsync(id);
        var response = new Response<bool>
        {
            Data = result
        };

        return Ok(response);
    }
}