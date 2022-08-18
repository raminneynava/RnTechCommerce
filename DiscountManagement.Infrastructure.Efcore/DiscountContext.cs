using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.Efcore.Mapping;

using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure.Efcore
{
    public class DiscountContext : DbContext
    {
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
        
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            var assembly = typeof(CustomerDiscountMapping).Assembly;
            modelbuilder.ApplyConfigurationsFromAssembly(assembly);

            modelbuilder.Entity<CustomerDiscount>().HasQueryFilter(x => x.IsRemoved == false);

            base.OnModelCreating(modelbuilder);
        }
    }
}
