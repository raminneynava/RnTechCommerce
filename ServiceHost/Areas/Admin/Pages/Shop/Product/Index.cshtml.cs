using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _product;
        private readonly IProductCategoryApplication _productCategory;

        public IndexModel(IProductApplication product, IProductCategoryApplication productCategory)
        {
            _product = product;
            _productCategory = productCategory;
        }

        public IEnumerable<ProductViewModel> product;
        public ProductSearchModel Search;
        public SelectList productCategory;
        public async Task OnGet(ProductSearchModel Search)
        {
            productCategory = new SelectList(await _productCategory.GetProductCategories(), "Id", "Name");
            product = await _product.Search(Search);
        }

        public async Task<IActionResult> OnGetCreate()
        {

            return Partial("./Create", new CreateProduct{

                Categories = (await _productCategory.GetProductCategories()).ToList()
            });
        }
        public async Task<JsonResult> OnPostCreate(CreateProduct create)
        {
            var result = await _product.Create(create);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetEdit(int id)
        {
            var model = await _product.GetById(id);
            model.Categories = (await _productCategory.GetProductCategories()).ToList();
            return Partial("./Edit", model);
        }
        public async Task<JsonResult> OnPostEdit(EditProduct Edit)
        {
            var result = await _product.Edit(Edit);
            return new JsonResult(result);
        }
        public async Task<JsonResult> OnGetNotInStock(long id)
        {
            var result = await _product.NotInstock(id);
            return new JsonResult(result);
        }
        public async Task<JsonResult> OnGetIsStock(long id)
        {
            var result = await _product.IsInstock(id);
            return new JsonResult(result);
        }
    }
}
