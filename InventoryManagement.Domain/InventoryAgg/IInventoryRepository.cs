using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Domain;

using InventoryManagement.Application.Contract.Inventory;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository: IRepository<long,Inventory>
    {
        Task<EditInventory> GetById(long id);
        Task<IEnumerable<InventoryViewModel>> Search(InventorySearchModel searchModel);
        Task<Inventory> GetBy(long ProductId);
        Task<IEnumerable<InventoryOperationViewModel>> GetOperationLog(long inventoryId);
    }
}
