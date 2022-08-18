using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPrictureAqq;
using ShopManagement.Domain.SliderAgg;
using ShopManagement.Infrastructure.Efcore.Mapping;

namespace ShopManagement.Infrastructure.Efcore
{
    public class ShopContext:DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options):base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            var assembly= typeof(ProductCategoryMapping).Assembly;
            modelbuilder.ApplyConfigurationsFromAssembly(assembly);

            modelbuilder.Entity<Product>().HasQueryFilter(x => x.IsDeleted==false);

            base.OnModelCreating(modelbuilder);
        }
    }
}
