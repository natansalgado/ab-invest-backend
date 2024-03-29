using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AB_INVEST.Context.Maps
{
    public class WithdrawMap : IEntityTypeConfiguration<WithdrawModel>
    {
        public void Configure(EntityTypeBuilder<WithdrawModel> builder)
        {
            builder.HasIndex(x => x.Id);

            builder.Property(x => x.InitialValue).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Balance).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.WithdrewValue).IsRequired();
            builder.Property(x => x.AccountId).IsRequired();
            builder.Property(x => x.InvestmentId).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.WithdrawDate).IsRequired();

            builder.HasOne(x => x.Account).WithMany().HasForeignKey(x => x.AccountId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Investment).WithMany().HasForeignKey(x => x.InvestmentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}