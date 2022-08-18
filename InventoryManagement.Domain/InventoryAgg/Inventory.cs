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
        public List<InventoryOperation> Operations { get; private set; } = new List<InventoryOperation>();

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
            if (Operations != null)
            {
                var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
                var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
                return plus - minus;
            }
            return 0;
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


}
