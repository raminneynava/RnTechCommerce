using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.Efcore;
using ShopManagement.Infrastructure.Efcore.Repository;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstraper
    {
        public static void Configure(IServiceCollection service,string connectionString)
        {
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            service.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
