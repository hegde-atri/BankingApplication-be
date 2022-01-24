using System;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Models;
using Bank.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers.Teller
{
  [ApiController]
  [Route("api/teller/[controller]")]
  public class TransactionController: ControllerBase
  {
    private readonly ITellerRepository _repository;
    private readonly IMapper _mapper;

    // Can do two things, withdraw and deposit.
    public TransactionController(ITellerRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<TransactionModel>> Post(TransactionModel model)
    {
      try
      {
        if (model?.AccountId < 1) return BadRequest();
        
        model.TransDateTime = DateTime.Now;
        
        var transaction = _mapper.Map<Transaction>(model);
        _repository.Add(transaction);

        if (await _repository.SaveChangesAsync())
        {
          return Created("", _mapper.Map<TransactionModel>(transaction));
        }

      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);

      }

      return BadRequest();
    }

  }
}