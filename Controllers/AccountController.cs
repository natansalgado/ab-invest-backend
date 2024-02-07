using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;
using AB_INVEST.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AB_INVEST.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPut("{id}/{key}")]
        [Authorize]
        public ActionResult<bool> UpdateAccountKey(int id, string key)
        {
            AccountModel keyAlreadyInUse = _service.FindByKey(key);

            if (keyAlreadyInUse != null)
                return Conflict(false);

            bool updated = _service.UpdateAccountKey(id, key);

            if (!updated)
                return NotFound(false);

            return Ok(true);
        }
    }
}