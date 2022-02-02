using System;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers.Manager
{
  [ApiController]
  [Route("api/manager/[controller]")]
  public class CustomerController: ControllerBase
  {
    private readonly IManagerRepository _repository;
    private readonly IMapper _mapper;

    public CustomerController(IManagerRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<Data.Entities.Customer[]>> Get()
    {
      try
      {
        var results = await _repository.GetAllCustomersAsync();
        return new JsonResult(_mapper.Map<CustomerModel[]>(results));
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }
    }
    
  }
}