using System;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Bank.API.Controllers.Customer
{
  [ApiController]
  [Route("api/customer/[controller]")]
  public class CustomerController : ControllerBase
  {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;
    private readonly LinkGenerator _linkGenerator;

    public CustomerController(ICustomerRepository repository, IMapper mapper, LinkGenerator linkGenerator)
    {
      _repository = repository;
      _mapper = mapper;
      _linkGenerator = linkGenerator;
    }

    [HttpGet("{customerEmail}")]
    public async Task<ActionResult<CustomerModel>> Get(string customerEmail)
    {
      try
      {
        var result = await _repository.GetCustomerAsync(customerEmail);
        if (result == null) return BadRequest();
        return _mapper.Map<CustomerModel>(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }
      
    }
    
    [HttpPut("{email}")]
    public async Task<ActionResult<CustomerModel>> Put(string email, CustomerModel model)
    {
      try
      {
        var old = await _repository.GetCustomerAsync(email);
        if (old == null) return BadRequest("customer not found");

        // _mapper.Map(model, old);
        // Here we only want the customer to be able to change their budget
        old.Budget = model.Budget;
        if (await _repository.SaveChangesAsync()) return _mapper.Map<CustomerModel>(old);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }

      return BadRequest();
    }



  }

}