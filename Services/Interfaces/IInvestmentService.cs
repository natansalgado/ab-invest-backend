using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;

namespace AB_INVEST.Services.Interfaces
{
    public interface IInvestmentService
    {
        List<InvestmentModel> FindAll();
        InvestmentModel FindById(int id);
        InvestmentModel Create(InvestmentModel investment);
        InvestmentModel Update(int id, InvestmentModel investment);
        bool Delete(int id);
    }
}