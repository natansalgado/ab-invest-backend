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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<UserDto>> GetAll()
        {
            List<UserDto> users = _service.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<UserDto> GetById(int id)
        {
            UserDto user = _service.GetById(id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserDto> Create([FromBody] CreateUserDto user)
        {
            if (_service.EmailAlreadyInUse(user.Email))
                return Conflict("Email already in use");

            UserDto userCreated = _service.Create(user);

            return Ok(userCreated);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<UserDto> Update(int id, [FromBody] UserModel user)
        {
            UserDto userUpdated = _service.Update(id, user);

            if (userUpdated == null)
                return NotFound("User not found");

            return Ok(userUpdated);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<bool> Delete(int id)
        {
            bool deleted = _service.Delete(id); 

            if (!deleted)
                return NotFound("User not found");


            return Ok(deleted);
        }
    }
}