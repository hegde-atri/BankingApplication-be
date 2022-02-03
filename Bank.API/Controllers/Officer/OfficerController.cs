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
    // Dummy class used for testing, serves no purpose
    // will be deleted later

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