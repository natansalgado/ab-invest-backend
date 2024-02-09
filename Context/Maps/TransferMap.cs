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
    public class TransferMap : IEntityTypeConfiguration<TransferModel>
    {
        public void Configure(EntityTypeBuilder<TransferModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Value).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.SenderAccountId).IsRequired();
            builder.Property(x => x.ReceiverAccountId).IsRequired();

            builder.HasOne(x => x.SenderAccount).WithMany().HasForeignKey(x => x.SenderAccountId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ReceiverAccount).WithMany().HasForeignKey(x => x.ReceiverAccountId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}