using System;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Models;
using Bank.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Bank.API.Controllers.Customer
{
  [ApiController]
  [Route("api/customer/[controller]")]
  public class AccountController: ControllerBase
  {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;
    private readonly LinkGenerator _linkGenerator;

    public AccountController(ICustomerRepository repository, IMapper mapper, 
      LinkGenerator linkGenerator)
    {
      // object instances we will be using in this class
      _repository = repository;
      _mapper = mapper;
      _linkGenerator = linkGenerator;
    }

    // This post doesnt create a new account, since a customer should not be able to do that,
    // Instead is a user-defined, complex algorithm that is used to retrieve account/s
    [HttpPost]
    public async Task<ActionResult<AccountModel[]>> Post(CustomerRequest model)
    {
      try
      {
        if (model == null) return BadRequest();
        if (model.CustomerId != 0)
        {
          var results = await _repository.GetAllAccountsAsync(model.CustomerId);
          return _mapper.Map<AccountModel[]>(results);
        }
        else if (model.AccountId[0] != 0)
        {
          // You can get only the first address back.
          var result = new Account[]{await _repository.GetAccountAsync(model.AccountId[0])};
          if (result == null) return BadRequest();
          return new JsonResult(_mapper.Map<AccountModel[]>(result));
        }
        
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }

      return BadRequest();
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

  }
}