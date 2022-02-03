using System;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Models;
using Bank.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers.Officer
{
  [ApiController]
  [Route("api/officer/[controller]")]
  public class AddressController: ControllerBase
  {
    private readonly IOfficerRepository _repository;
    private readonly IMapper _mapper;

    public AddressController(IOfficerRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<AddressModel>> Post(AddressModel model)
    {
      try
      {
        if (model.CustomerId < 1) return BadRequest();
        var address = _mapper.Map<Address>(model);
        _repository.Add(address);

        if (await _repository.SaveChangesAsync())
        {
          return Created("" ,_mapper.Map<AddressModel>(address));
        }
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }

      return BadRequest();
    }

    [HttpGet("{customerId}/{addressId}")]
    public async Task<ActionResult<AddressModel[]>> Get(int customerId, int addressId)
    {
      try
      {
        // we are catching errors before they cause problems by making sure customerId is above 0
        if (customerId < 1)
        {
          //this is only future proofing if we decide to add more features to the officer
          return BadRequest();
        }
        else
        {
          var results = await _repository.GetAllAddressesAsync(customerId);
          return _mapper.Map<AddressModel[]>(results);
        }
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }

      return BadRequest();
    }
    
    [HttpPut("{addressId}")]
    public async Task<ActionResult<AddressModel>> Put(int addressId, AddressModel model)
    {
      try
      {
        var old = await _repository.GetAddressAsync(addressId);
        if (old == null) return BadRequest("notification not found!");

        _mapper.Map(model, old);
        old.AddressId = addressId;
        if (await _repository.SaveChangesAsync()) return _mapper.Map<AddressModel>(old);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }

      return BadRequest();
    }
    
    [HttpDelete("{addressId}")]
    public async Task<IActionResult> Delete(int addressId)
    {
      try
      {
        var old = await _repository.GetAddressAsync(addressId);
        if (old == null) return NotFound();
        
        _repository.Delete(old);
        if (await _repository.SaveChangesAsync()) return Ok();
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }
      return BadRequest();
    }
    
    

  }
}