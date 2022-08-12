using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiscountManagement.Domain.CustomerDiscountAgg;    
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.Efcore.Mapping
{
    public class CustomerDiscountMapping : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
           // builder.ToTable("CustomerDiscount");
            builder.HasKey(x => x.Id);
           // builder.Property(x => x.Name).HasMaxLength(1000).IsRequired();
        }
    }
}
