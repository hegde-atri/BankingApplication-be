using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers.Officer
{
    //Although creating a new controller just for a single get method
    //seems overkill and unnecessary, it help keeps the front end logic simple
    [ApiController]
    [Route("api/officer/[controller]")]
    public class CheckCustomerController: ControllerBase
    {
        private readonly IOfficerRepository _repository;
        private readonly IMapper _mapper;

        public CheckCustomerController(IOfficerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{customerEmail}")]
        public async Task<ActionResult<bool>> Get(string customerEmail)
        {
            try
            {
                var result = await _repository.GetCustomerByEmailAsync(customerEmail);
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