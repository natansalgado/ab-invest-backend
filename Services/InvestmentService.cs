using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;
using AB_INVEST.Repositories.Interfaces;
using AB_INVEST.Services.Interfaces;

namespace AB_INVEST.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _repository;

        public InvestmentService(IInvestmentRepository repository)
        {
            _repository = repository;
        }

        public List<InvestmentModel> FindAll()
        {
            return _repository.FindAll();
        }

        public InvestmentModel FindById(int id)
        {
            return _repository.FindById(id);
        }

        public InvestmentModel Create(InvestmentModel investment)
        {
            return _repository.Create(investment);
        }

        public InvestmentModel Update(int id, InvestmentModel investment)
        {
            return _repository.Update(id, investment);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}