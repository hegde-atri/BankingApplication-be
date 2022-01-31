using System;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Models;
using Bank.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers.Officer
{
  [ApiController]
  [Route("api/officer/[controller]")]
  public class NotificationController: ControllerBase
  {
    
    private readonly IOfficerRepository _repository;
    private readonly IMapper _mapper;

    public NotificationController(IOfficerRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
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

    [HttpPost]
    public async Task<ActionResult<NotificationModel>> Post(NotificationModel model)
        {
          try
          {
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