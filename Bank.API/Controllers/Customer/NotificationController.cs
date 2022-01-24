using System;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Models;
using Bank.Data.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Controllers.Customer
{
  [EnableCors("_myAllowSpecificOrigins")]
  [ApiController]
  [Route("api/customer/[controller]")]
  public class NotificationController: ControllerBase
  {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;
    private readonly LinkGenerator _linkGenerator;

    public NotificationController(ICustomerRepository repository, IMapper mapper, LinkGenerator linkGenerator)
    {
      _repository = repository;
      _mapper = mapper;
      _linkGenerator = linkGenerator;
    }

    [HttpGet("{customerId}/{notificationId}")]
    public async Task<ActionResult<NotificationModel[]>> Get(int customerId, int notificationId)
    {
      try
      {
        if (customerId != 0)
        {
          var results = await _repository.GetAllNotificationsAsync(customerId);
          return _mapper.Map<NotificationModel[]>(results);
        }else if (notificationId != 0)
        {
          var result = new Notification[]{await _repository.GetNotificationAsync(notificationId)};
          if (result == null) return BadRequest();
          return _mapper.Map<NotificationModel[]>(result);
        }

        return BadRequest();
        
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }
    }


    [HttpPost]
    public async Task<ActionResult<NotificationModel>> Post(NotificationModel model)
    {
      try
      {
        // var location = _linkGenerator.GetPathByAction("Get", "Notification",
        //   "0/"+new {model.NotificationId});
        if (model?.CustomerId < 1) return BadRequest();
        var notification = _mapper.Map<Notification>(model);
        _repository.Add(notification);

        if (await _repository.SaveChangesAsync())
        {
          return Created("" ,_mapper.Map<NotificationModel>(notification));
        }
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }

      return BadRequest();
    }

    [HttpPut("{notificationId}")]
    public async Task<ActionResult<NotificationModel>> Put(int notificationId, NotificationModel model)
    {
      try
      {
        var old = await _repository.GetNotificationAsync(notificationId);
        if (old == null) return BadRequest("notification not found!");

        _mapper.Map(model, old);
        old.NotificationId = notificationId;
        if (await _repository.SaveChangesAsync()) return _mapper.Map<NotificationModel>(old);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }

      return BadRequest();
    }

    [HttpDelete("{notificationId}")]
    public async Task<IActionResult> Delete(int notificationId)
    {
      try
      {
        var old = await _repository.GetNotificationAsync(notificationId);
        if (old == null) return NotFound();
        
        _repository.Delete(old);
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