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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpPost("CheckAccountToTransfer")]
        public ActionResult<TransferConfirmDto> CheckAccountToTransfer([FromBody] TransferDto transferDto)
        {
            try
            {
                return _service.CheckAccountToTransfer(transferDto);
            }
            catch (ABException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Transfer")]
        public ActionResult<TransferDoneDto> Transfer([FromBody] TransferDto transferDto)
        {
            try
            {
                TransferDoneDto transfer = _service.Transfer(transferDto);
                return Ok(transfer);
            }
            catch (ABException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Deposit")]
        public ActionResult<DepositModel> Deposit([FromBody] DepositDto depositDto)
        {
            DepositModel deposit = _service.Deposit(depositDto);

            if (deposit == null) return NotFound("Conta não encontrada");

            return Ok(deposit);
        }
    }
}