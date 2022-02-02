using System;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Bank.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Bank.API.Controllers.Customer
{
  [ApiController]
  [Route("api/customer/[controller]")]
  public class TransferController: ControllerBase
  {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;
    private readonly LinkGenerator _linkGenerator;

    public TransferController(ICustomerRepository repository, IMapper mapper,
      LinkGenerator linkGenerator)
    {
      _repository = repository;
      _mapper = mapper;
      _linkGenerator = linkGenerator;
    }

    [HttpPost]
    public async Task<ActionResult<TransferModel>> Post(TransferModel model)
    {
      try
      {
        // TODO figure out how to do these transactions that are interdependent on each other.
        // A transfer created 2 transactions that take place, but we need to make sure that both of the transactions
        // must be successful!
        TransactionModel transactionModel1 = new TransactionModel
        {
          Amount = model.Amount,
          AccountId = 1,
          AccountNumber = model.AccountNumber1,
          Type = model.Type1,
          Description = model.Description1,
          TransDateTime = DateTime.UtcNow,
          CreatedBy = "User",
          CreatedDate = DateTime.Today
        };
        
        
        TransactionModel transactionModel2 = new TransactionModel
        {
          Amount = model.Amount,
          AccountId = 2,
          AccountNumber = model.AccountNumber2,
          Type = model.Type2,
          Description = model.Description2,
          TransDateTime = DateTime.UtcNow,
          CreatedBy = "User",
          CreatedDate = DateTime.Today
        };
        
        
        // lets make the required transaction statements
        var transaction1 = _mapper.Map<Transaction>(transactionModel1);
        var transaction2 = _mapper.Map<Transaction>(transactionModel2);
        // now lets update the corresponding account balances
        var account1 = await _repository.GetAccountByNumberAsync(model.AccountNumber1);
        var account2 = await _repository.GetAccountByNumberAsync(model.AccountNumber2);
        
        _repository.Add(transaction1);
        _repository.Add(transaction2);
        

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