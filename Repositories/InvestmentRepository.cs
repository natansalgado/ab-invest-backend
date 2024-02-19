using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Context;
using AB_INVEST.Models;
using AB_INVEST.Repositories.Interfaces;

namespace AB_INVEST.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly ABInvestContext _context;

        public InvestmentRepository(ABInvestContext context)
        {
            _context = context;
        }

        public List<InvestmentModel> FindAll()
        {
            return _context.Investments.OrderBy(x => x.AnnualPercentage).ToList();
        }

        public InvestmentModel FindById(int id)
        {
            return _context.Investments.Find(id);
        }

        public InvestmentModel Create(InvestmentModel investment)
        {
            _context.Investments.Add(investment);
            _context.SaveChanges();

            return investment;
        }

        public InvestmentModel Update(int id, InvestmentModel investment)
        {
            InvestmentModel investmentById = FindById(id);

            if (investmentById == null)
                return null;

            if (investmentById.Name != null) investmentById.Name = investment.Name;
            if (investmentById.MinValue != 0) investmentById.MinValue = investment.MinValue;
            if (investmentById.MinMonths != 0) investmentById.MinMonths = investment.MinMonths;
            if (investmentById.AnnualPercentage != 0) investmentById.AnnualPercentage = investment.AnnualPercentage;

            _context.Investments.Update(investmentById);
            _context.SaveChanges();

            return investmentById;
        }

        public bool Delete(int id)
        {
            InvestmentModel investmentById = FindById(id);

            if (investmentById == null)
                return false;

            _context.Remove(investmentById);
            _context.SaveChanges();

            return true;
        }
    }
}