using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Domain;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public ICollection<InventoryOperation> Operations { get; private set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }
        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }
        public long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }
        public void Increase(long Count, string OperatorId, string Description)
        {
            var currentcount = CalculateCurrentCount() + Count;
            var operation = new InventoryOperation(true, Count, OperatorId, currentcount, Description, 0, Id);
            this.Operations.Add(operation);
            InStock = currentcount > 0;
        }
        public void Reduce(long Count, string OperatorId, string Description,long OrderId)
        {
            var currentcount = CalculateCurrentCount() - Count;
            var operation = new InventoryOperation(false, Count, OperatorId, currentcount, Description, OrderId, Id);
            this.Operations.Add(operation);
            InStock = currentcount > 0;
        }
    }

    public class InventoryOperation
    {
        public long Id { get; private set; }
        public bool Operation { get; private set; }
        public long Count { get; private set; }
        public string OperatorId { get; private set; } = String.Empty;
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string? Description { get; private set; }
        public long OrderId { get; private set; }
        public long InventoryId { get; private set; }
        public Inventory Inventory { get; private set; }
        protected InventoryOperation()
        {

        }
        public InventoryOperation(bool operation, long count, string operatorId, long currentCount, string? description, long orderId, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
            InventoryId = inventoryId;
        }
    }


}
