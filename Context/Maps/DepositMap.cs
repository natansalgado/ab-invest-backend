using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AB_INVEST.Context.Maps
{
    public class DepositMap : IEntityTypeConfiguration<DepositModel>
    {
        public void Configure(EntityTypeBuilder<DepositModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.Date).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.PaymentMethod).IsRequired();
            builder.Property(x => x.AccountId).IsRequired();

            builder.HasOne(x => x.Account).WithMany().HasForeignKey(x => x.AccountId).OnDelete(DeleteBehavior.NoAction);;
        }
    }
}