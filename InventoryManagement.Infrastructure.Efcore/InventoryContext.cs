using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InventoryManagement.Domain.InventoryAgg;

using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Efcore
{
    public class InventoryContext:DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            var assembly = typeof(Inventory).Assembly;
            modelbuilder.ApplyConfigurationsFromAssembly(assembly);

           // modelbuilder.Entity<Inventory>().HasQueryFilter(x => x.IsRemoved == false);

            base.OnModelCreating(modelbuilder);
        }
    }
}
