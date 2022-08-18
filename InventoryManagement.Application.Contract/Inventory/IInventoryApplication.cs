﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Application;

namespace InventoryManagement.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        Task<OperationResult> Create(CreateInventory command);
        Task<OperationResult> Edit(EditInventory command);
        Task<OperationResult> Increase(IncreaseInventory command);
        Task<OperationResult> Reduse(List<ReduseInventory> command);
        Task<OperationResult> Reduse(ReduseInventory command);
        Task<EditInventory> GetById(long id);
        Task<IEnumerable<InventoryViewModel>> Search(InventorySearchModel searchModel);
    }
}
