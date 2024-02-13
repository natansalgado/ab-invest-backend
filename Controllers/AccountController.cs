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
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPut("{id}/{key}")]
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

        [HttpGet("userid/{userId}")]
        public ActionResult<AccountModel> GetByUserId(int userId)
        {
            AccountModel account = _service.FindByUserId(userId);

            if (account == null)
                return NotFound("Conta não encontrada");

            return Ok(account);
        }
    }
}