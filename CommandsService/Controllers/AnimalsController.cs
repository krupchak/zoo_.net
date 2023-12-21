using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace ZooOwners.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        public AnimalsController()
        {
            
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Zoo Owners");

            return Ok("Inbound test of from Animals Controller");
        }
    }    
}