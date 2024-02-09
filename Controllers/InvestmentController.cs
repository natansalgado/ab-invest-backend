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
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _service;

        public InvestmentController(IInvestmentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<InvestmentModel>> FindAll()
        {
            List<InvestmentModel> investments = _service.FindAll();
            return Ok(investments);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<InvestmentModel> FindById(int id)
        {
            InvestmentModel investment = _service.FindById(id);

            if (investment == null)
                return NotFound("Investimento não encontrado");

            return Ok(investment);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<InvestmentModel> Create([FromBody] InvestmentModel investment)
        {
            InvestmentModel investmentCreated = _service.Create(investment);
            return Ok(investmentCreated);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<InvestmentModel> Update(int id, [FromBody] InvestmentModel investment)
        {
            InvestmentModel investmentUpdated = _service.Update(id, investment);

            if (investmentUpdated == null)
                return NotFound("Investimento não encontrado");

            return Ok(investmentUpdated);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<bool> Delete(int id)
        {
            bool deleted = _service.Delete(id);

            if (!deleted)
                return NotFound("Investimento não encontrado");

            return Ok(deleted);
        }
    }
}