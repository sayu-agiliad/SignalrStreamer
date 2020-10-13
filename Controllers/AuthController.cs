using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveStreamer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiveStreamer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticateService _authService;

        public AuthController(IAuthenticateService authservice)
        {
            this._authService = authservice;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] User user)
        {
            var validUser = _authService.Authenticate(user);
            if (validUser == null)
                return BadRequest();
            return Ok(validUser);
        }
    }
}
