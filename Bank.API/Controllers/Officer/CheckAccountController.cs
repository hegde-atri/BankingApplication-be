using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers.Officer
{
    // Since the officer will also be creating new accounts for new customer,
    // this class ensures that the new account number doesn't conflict with any 
    // already existing account numbers.
    [ApiController]
    [Route("api/officer/[controller]")]
    public class CheckAccountController: ControllerBase
    {
        private readonly IOfficerRepository _repository;

        public CheckAccountController(IOfficerRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet("{accountNo}")]
        public async Task<ActionResult<bool>> Get(string accountNo)
        {
            try
            {
                if (accountNo == null) return BadRequest();
                if (accountNo.Length != 16) return BadRequest();

                var result = await _repository.GetAccountAsync(accountNo);
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