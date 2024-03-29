using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Exceptions;
using AB_INVEST.Models;
using AB_INVEST.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AB_INVEST.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserInvestmentController : ControllerBase
    {
        private readonly IUserInvestmentService _service;

        public UserInvestmentController(IUserInvestmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<UserInvestmentModel>> GetAll()
        {
            List<UserInvestmentModel> userInvestments = _service.GetAll();
            return Ok(userInvestments);
        }

        [HttpGet("{id}")]
        public ActionResult<List<UserInvestmentModel>> GetById(int id)
        {
            UserInvestmentModel userInvestment = _service.GetById(id);

            if (userInvestment == null)
                return NotFound("Investimento do usuário não encontrado");

            return Ok(userInvestment);
        }

        [HttpGet("Account/{id}")]
        public ActionResult<List<UserInvestmentModel>> GetByAccountId(int id)
        {
            List<UserInvestmentModel> accountInvestments = _service.GetByAccountId(id);

            if (accountInvestments == null)
                return NotFound("Conta não encontrada");

            return Ok(accountInvestments);
        }

        [HttpPost]
        public ActionResult<UserInvestmentModel> Create([FromBody] UserInvestmentDto userInvestmentdto)
        {
            try
            {
                UserInvestmentModel userInvestmentCreated = _service.Create(userInvestmentdto);

                return Ok(userInvestmentCreated);
            }
            catch (ABException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }   
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AddBalance/{id}/{value}")]
        public ActionResult<UserInvestmentModel> AddBalance(int id, decimal value)
        {
            try
            {
                UserInvestmentModel userInvestment = _service.AddBalance(id, value);
                return Ok(userInvestment);
            }
            catch (ABException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Withdraw/{id}/{value}")]
        public ActionResult<WithdrawModel> WithdrawValue(int id, decimal value)
        {
            try
            {
                WithdrawModel withdraw = _service.WithDraw(id, value);
                return Ok(withdraw);
            }
            catch (ABException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}