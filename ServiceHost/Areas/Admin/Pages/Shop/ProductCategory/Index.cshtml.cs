using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategory;

        public IndexModel(IProductCategoryApplication productCategory)
        {
            _productCategory = productCategory;
        }

        public IEnumerable<ProductCategoryViewModel> productCategories;
        public ProductCategorySearchViewModel Search;
        public async Task OnGet(ProductCategorySearchViewModel Search)
        {
            productCategories = await _productCategory.Search(Search);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }
        public async Task<JsonResult> OnPostCreate(CreateProductCategory create)
        {
            var result = await _productCategory.Create(create);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetEdit(int id)
        {
            var model = await _productCategory.GetById(id);
            return Partial("./Edit", model);
        }
        public async Task<JsonResult> OnPostEdit(EditProductCategory Edit)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(false);
            }
            var result = await _productCategory.Edit(Edit);
            return new JsonResult(result);
        }
    }
}
