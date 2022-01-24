using System;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Controllers.Customer;
using Bank.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers.Officer
{
  [ApiController]
  [Route("api/officer/[controller]")]
  public class CustomerController: ControllerBase
  {
    private readonly IOfficerRepository _repository;
    private readonly IMapper _mapper;

    public CustomerController(IOfficerRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<CustomerModel>> Post(CustomerModel model)
    {
      /*
            
        
        
        Julie is the best teacher, and I will give her many caramel chocolates
         ___  ___  ___  ___  ___.---------------.
        .'\__\'\__\'\__\'\__\'\__,`   .  ____ ___ \
        |\/ __\/ __\/ __\/ __\/ _:\   |`.  \  \___ \
         \\'\__\'\__\'\__\'\__\'\_`.__|""`. \  \___ \
          \\/ __\/ __\/ __\/ __\/ __:                \
           \\'\__\'\__\'\__\ \__\'\_;-----------------`
            \\/   \/   \/   \/   \/ :    caramel choco|
             \|______________________;________________|
             
               */
      
      try
      {
        var customer = _mapper.Map<Data.Entities.Customer>(model);
        _repository.Add(customer);
        if (await _repository.SaveChangesAsync()) return Created("", _mapper.Map<CustomerModel>(customer));
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }

      return BadRequest();
    }

    [HttpPut("{customerId}")]
    public async Task<ActionResult<CustomerModel>> Put(int customerId, CustomerModel model)
    {
      
      try
      {
        var old = await _repository.GetCustomerAsync(customerId);
        if (old == null) return BadRequest("Customer not found");
        _mapper.Map(model, old);
        old.CustomerId = customerId;
        if (await _repository.SaveChangesAsync()) return _mapper.Map<CustomerModel>(old);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }

      return BadRequest();
    }

    [HttpGet("{email}")]
    public async Task<ActionResult<CustomerModel>> Get(string email)
    {
      try
      {
        var result = await _repository.GetCustomerByEmailAsync(email);
        if (result == null) return BadRequest();
        return _mapper.Map<CustomerModel>(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }
    }

  }
}