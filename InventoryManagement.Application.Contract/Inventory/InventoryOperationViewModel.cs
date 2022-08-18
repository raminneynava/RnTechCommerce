using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class InventoryOperationViewModel
    {
        public long Id { get;  set; }
        public bool Operation { get;  set; }
        public long Count { get;  set; }
        public string OperatorId { get;  set; }
        public string Operator { get;  set; }
        public DateTime OperationDate { get;  set; }
        public long CurrentCount { get;  set; }
        public string? Description { get;  set; }
        public long OrderId { get;  set; }
        public long InventoryId { get;  set; }
    }
}
