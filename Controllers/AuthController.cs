using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Models;
using AB_INVEST.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AB_INVEST.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<string> GetUser([FromBody] AuthLoginDto login)
        {
            UserModel user = _service.GetByCredentials(login);

            if (user == null)
                return NotFound("Email or Password do not correspond");

            string token = _service.GenerateToken(user);

            return Ok(new { token });
        }
    }
}