using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Exceptions;
using AB_INVEST.Models;
using AB_INVEST.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AB_INVEST.Controllers
{
    [Route("api/[controller]")]
    public class UserInvestmentController : ControllerBase
    {
        private readonly IUserInvestmentService _service;

        public UserInvestmentController(IUserInvestmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<UserInvestmentModel>> FindAll()
        {
            List<UserInvestmentModel> userInvestments = _service.FindAll();
            return Ok(userInvestments);
        }

        [HttpGet("{id}")]
        public ActionResult<List<UserInvestmentModel>> FindById(int id)
        {
            UserInvestmentModel userInvestment = _service.FindById(id);

            if (userInvestment == null)
                return NotFound("Investimento do usuário não encontrado");

            return Ok(userInvestment);
        }

        [HttpGet("Account/{id}")]
        public ActionResult<List<UserInvestmentModel>> FindByAccountId(int id)
        {
            List<UserInvestmentModel> accountInvestments = _service.FindByAccountId(id);

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

        [HttpDelete("{id}")]
        public ActionResult<WithdrawModel> Withdraw(int id)
        {
            try
            {
                WithdrawModel withdraw = _service.WithDraw(id);
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