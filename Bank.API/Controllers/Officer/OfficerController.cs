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
  [Authorize]
  [ApiController]
  [Route("/api/officer")]
  public class OfficerController: ControllerBase
  {
    // Dummy class used for testing, serves no purpose

    public OfficerController()
    {
      
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
      // Testing method
      return new JsonResult("METHOD REACHED");
    }
  }
}