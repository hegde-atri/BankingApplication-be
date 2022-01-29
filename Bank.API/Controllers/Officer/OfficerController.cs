using System;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Models;
using Bank.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;


namespace Bank.API.Controllers.Officer
{
  [ApiController]
  [Route("/api/officer")]
  public class OfficerController: ControllerBase
  {
    // The officer should be able to create a customer, view customer transactions and approve customer address/notification changes.

    public OfficerController()
    {
      
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
      // return StatusCode(StatusCodes.Status200OK, "method reached");
      return new JsonResult("METHOD REACHED");
    }
  }
}