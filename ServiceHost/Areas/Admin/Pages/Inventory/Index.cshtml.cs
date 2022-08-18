using InventoryManagement.Application.Contract.Inventory;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Admin.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        private readonly IInventoryApplication _inventoryCategory;

        public IndexModel(IInventoryApplication inventoryCategory)
        {
            _inventoryCategory = inventoryCategory;
        }

        public IEnumerable<InventoryViewModel> Inventory;
        public InventorySearchModel Search;
        public async Task OnGet(InventorySearchModel Search)
        {
            Inventory = await _inventoryCategory.Search(Search);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateInventory());
        }
        public async Task<JsonResult> OnPostCreate(CreateInventory create)
        {
            var result = await _inventoryCategory.Create(create);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetEdit(long id)
        {
            var model = await _inventoryCategory.GetById(id);
            return Partial("./Edit", model);
        }
        public async Task<JsonResult> OnPostEdit(EditInventory Edit)
        {
            var result = await _inventoryCategory.Edit(Edit);
            return new JsonResult(result);
        }
        public IActionResult OnGetIncrease(long id)
        {
            var model = new IncreaseInventory()
            {
                InventoryId = id
            };
            return Partial("Increase", model);
        }
        public async Task<JsonResult> OnPostIncrease(IncreaseInventory command)
        {
            var result = await _inventoryCategory.Increase(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetReduce(long id)
        {
            var model = new ReduceInventory()
            {
                InventoryId = id
            };
            return Partial("Reduce", model);
        }    

        public async Task<JsonResult> OnPostReduce(ReduceInventory command)
        {
            var result = await _inventoryCategory.Reduse(command);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetOperationlog(long id)
        {
            var model = await _inventoryCategory.GetOperationLog(id);
            return Partial("OperationLog", model);
        }
    }
}
