using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;

namespace AB_INVEST.Repositories.Interfaces
{
    public interface IInvestmentRepository
    {
        List<InvestmentModel> GetAll();
        InvestmentModel GetById(int id);
        InvestmentModel Create(InvestmentModel investment);
        InvestmentModel Update(InvestmentModel investmentById);
        bool Delete(int id);
    }
}