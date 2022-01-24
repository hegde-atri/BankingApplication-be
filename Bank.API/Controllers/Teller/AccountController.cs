using System;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Models;
using Bank.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Bank.API.Controllers.Teller
{
  
  [ApiController]
  [Route("api/teller/[controller]")]
  public class AccountController: ControllerBase
  {
    // In this class we just use to make sure that the account being used exists
    // and another method to get the account if it exists
    
    private readonly ITellerRepository _repository;
    private readonly IMapper _mapper;

    public AccountController(ITellerRepository repository, IMapper mapper)
    {
      // object instances we will be using in this class
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet("{accountNo}")]
    public async Task<ActionResult<bool>> Get(string accountNo)
    {
      try
      {
        if (accountNo == null) return BadRequest();
        if (accountNo.Length != 16) return BadRequest();

        var result = await _repository.GetAccountByNumberAsync(accountNo);
        if (result == null) return false;
        return true;
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }
    }
    
    // We are going to repurpose this Post to actually return us what we want
     [HttpPost("{accountNo}")]
     public async Task<ActionResult<AccountModel>> Post(string accountNo)
     {
       try
       {
         if (accountNo == null) return BadRequest();
         if (accountNo.Length != 16) return BadRequest();
    
         var result = await _repository.GetAccountByNumberAsync(accountNo);
         if (result == null) return NotFound();
         return _mapper.Map<AccountModel>(result);
       }
       catch (Exception e)
       {
         return StatusCode(StatusCodes.Status500InternalServerError, e);
       }
    
     }




  }
}