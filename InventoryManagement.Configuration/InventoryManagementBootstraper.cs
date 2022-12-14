using InventoryManagement.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.Efcore;
using InventoryManagement.Infrastructure.Efcore.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Configuration
{
    public class InventoryManagementBootstraper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IInventoryApplication, InventoryApplication>();
            service.AddTransient<IInventoryRepository, InventoryRepository>();
            service.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));
        }
    }
}