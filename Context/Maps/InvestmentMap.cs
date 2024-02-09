using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AB_INVEST.Context.Maps
{
    public class InvestmentMap : IEntityTypeConfiguration<InvestmentModel>
    {
        public void Configure(EntityTypeBuilder<InvestmentModel> builder)
        {
            builder.HasIndex(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MinValue).IsRequired();
            builder.Property(x => x.MinMonths).IsRequired();
            builder.Property(x => x.AnnualPercentage).IsRequired();
        }
    }
}