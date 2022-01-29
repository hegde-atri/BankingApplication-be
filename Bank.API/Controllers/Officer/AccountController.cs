using System;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Controllers.Teller;
using Bank.API.Models;
using Bank.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers.Officer
{
  [ApiController]
  [Route("api/officer/[controller]")]
  public class AccountController: ControllerBase
  {
    private readonly IOfficerRepository _repository;
    private readonly IMapper _mapper;

    public AccountController(IOfficerRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<AccountModel>> Post(AccountModel model)
    {
      try
      {
        if (model?.CustomerId < 1) return BadRequest();
        var account = _mapper.Map<Account>(model);
        _repository.Add(account);
        if (await _repository.SaveChangesAsync())
        {
          return Created("", _mapper.Map<AccountModel>(account));
        }
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }

      return BadRequest();
    }

    // The officer must be able to view all the accounts, but he must also be able to see if a certain account number
    // is already in use when creating account Objects for a new customer.
    [HttpGet("all/{selector}")]
    public async Task<ActionResult<AccountModel[]>> Get(string selector)
    {
      try
      {
        if (selector == "0")
        {
          // If selector is 0, return all accounts
          var results = await _repository.GetAllAccountsAsync();
          return _mapper.Map<AccountModel[]>(results);
        }
        else if (selector.Length == 16)
        {
          var result = new Account[]{await _repository.GetAccountAsync(selector)};
          if (result == null) return Ok();
          return StatusCode(StatusCodes.Status409Conflict);
        }
        // If selector is something else, then return bad request
        return BadRequest();

      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }
    }

  }
}