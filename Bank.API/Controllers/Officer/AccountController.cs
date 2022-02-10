using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Controllers.Teller;
using Bank.API.Models;
using Bank.API.Utilities;
using Bank.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers.Officer
{
  [ApiController]
  [Route("api/officer/[controller]")]
  public class AccountController : ControllerBase
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
        // return _mapper.Map<AccountModel[]>(results);
        var mapped = _mapper.Map<AccountModel[]>(results);
        // we are going to sort the array, sorts in ascending order
        // using a recursive merge sort
        mapped = MergeSort.MergeSortAccountModels(mapped);
        // now we turn this sorted array into a stack by pushing all the values
        // and then popping the stack so we get the accounts in descending order
        // in terms of amount;
        mapped = reverseList(mapped);
        return mapped;

      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }
    }

    // converts given 
    public AccountModel[] reverseList(AccountModel[] toReverse)
    {
      // passing in toReverse automatically loops through the 
      // array and creates a stack for us.
      var reversed = new AccountModel[toReverse.Length];
      var stack = new Stack<AccountModel>(toReverse);
      for (int i = 0; i < toReverse.Length; i++)
      {
        if (stack.Peek() != null)
        {
          reversed[i] = stack.Pop();
        }
      }

      return reversed;
    }

  }
}
// Here we are
  
