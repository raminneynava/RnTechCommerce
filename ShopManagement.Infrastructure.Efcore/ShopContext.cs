using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.Efcore
{
    public class ShopContext:DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options):base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            var assembly= typeof(ProductCategory).Assembly;
            modelbuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelbuilder);
        }
    }
}
