
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace online_shop_backend.Api.Endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        
        [HttpGet("start")]
        [HttpGet("ignition")]
        [HttpGet("/start-car")]
        public IEnumerable<string> ListCars()
        {
            return new string[]
                { "Nissan Micra", "FordFocus" };
        }
        
    }
    
}