using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Infrastructure;

using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;

using Microsoft.EntityFrameworkCore;

using ShopManagement.Infrastructure.Efcore;

namespace InventoryManagement.Infrastructure.Efcore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {

        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopyContext;

        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopyContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            _shopyContext = shopyContext;
        }

        public async Task<Inventory> GetBy(long ProductId)
        {
            return await _inventoryContext.Inventory.FirstOrDefaultAsync(x => x.ProductId == ProductId);
        }

        public async Task<EditInventory> GetById(long id)
        {
            return await _inventoryContext.Inventory.Select(x => new EditInventory {
            
            Id=x.Id,
            ProductId=x.ProductId,
            UnitPrice=x.UnitPrice
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<InventoryViewModel>> Search(InventorySearchModel searchModel)
        {
            var products = await _shopyContext.Products.Select(x => new { x.Id, x.Name }).ToListAsync();
            var query =
                _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                InStock = x.InStock,
                ProductId = x.ProductId,
                CurrentCount=x.CalculateCurrentCount()

            });
            if(searchModel.ProductId>0)
                query= query.Where(x => x.ProductId==searchModel.ProductId);
            if (!searchModel.InStock)
                query = query.Where(x => x.InStock);

            var inventory =await query.OrderByDescending(x => x.Id).ToListAsync();
            inventory.ForEach(item =>
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            });
            return inventory;
        }
    }
}
