using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Context.Maps;
using AB_INVEST.Models;
using Microsoft.EntityFrameworkCore;

namespace AB_INVEST.Context
{
    public class ABInvestContext : DbContext
    {
        public ABInvestContext(DbContextOptions<ABInvestContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<TransferModel> Transfers { get; set; }
        public DbSet<InvestmentModel> Investments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new TransferMap());
            modelBuilder.ApplyConfiguration(new InvestmentMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}