using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AB_INVEST.Context.Maps
{
    public class AccountMap : IEntityTypeConfiguration<AccountModel>
    {
        public void Configure(EntityTypeBuilder<AccountModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Balance).HasColumnType("decimal(18,2)").HasDefaultValue(0.00);
            builder.Property(x => x.AccountKey);
            builder.Property(x => x.UserId).IsRequired();

            builder.HasIndex(x => x.AccountKey).IsUnique();

            builder.HasOne(x => x.User).WithOne(u => u.Account).HasForeignKey<AccountModel>(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}