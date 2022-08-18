using _Framework.Application;

using _FrameWork.Application;

using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _repository;

        public InventoryApplication(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Create(CreateInventory command)
        {
            if (await _repository.Exists(x => x.ProductId  == command.ProductId))
                return new OperationResult().Failed(ApplicationMessages.DublicatedRecord);

            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            await _repository.Create(inventory);
            await _repository.SaveChangesAsync();

            return new OperationResult().Succedded();
        }

        public async Task<OperationResult> Edit(EditInventory command)
        {
            var inventory = await _repository.Get(command.Id);
            if (inventory == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);

      

            if (await _repository.Exists(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return new OperationResult().Failed(ApplicationMessages.DublicatedRecord);
            inventory.Edit(command.ProductId, command.UnitPrice);
            await _repository.SaveChangesAsync();

            return new OperationResult().Succedded();
        }

        public async Task<EditInventory> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        public Task<IEnumerable<InventoryOperationViewModel>> GetOperationLog(long inventoryId)
        {
           return _repository.GetOperationLog(inventoryId);
        }

        public async Task<OperationResult> Increase(IncreaseInventory command)
        {
            var inventory = await _repository.Get(command.InventoryId);
            if (inventory == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            const string operatorid ="1";
            inventory.Increase(command.Count, operatorid, command.Description);
            await _repository.SaveChangesAsync();
            return new OperationResult().Succedded();
        }

        public async Task<OperationResult> Reduse(List<ReduceInventory> command)
        {
            const string operatorid = "1";
            foreach (var item in command)
            {
                var inventory = await _repository.GetBy(item.ProductId);
                inventory.Reduce(item.Count, operatorid, item.Description, item.OrderId);
            }
            await _repository.SaveChangesAsync();
            return new OperationResult().Succedded();
        }

        public async Task<OperationResult> Reduse(ReduceInventory command)
        {
            var inventory = await _repository.Get(command.InventoryId);
            if (inventory == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            const string operatorid = "1";
            inventory.Reduce(command.Count,operatorid, command.Description, 0);
            await _repository.SaveChangesAsync();
            return new OperationResult().Succedded();
        }

        public Task<IEnumerable<InventoryViewModel>> Search(InventorySearchModel searchModel)
        {
          return _repository.Search(searchModel);
        }
    }
}