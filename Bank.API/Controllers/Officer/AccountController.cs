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
    
    [HttpGet]
    public async Task<ActionResult<AccountModel[]>> Get()
    {
      try
      {
        var results = await _repository.GetAllAccountsAsync();
        return _mapper.Map<AccountModel[]>(results);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }
    }

  }
}