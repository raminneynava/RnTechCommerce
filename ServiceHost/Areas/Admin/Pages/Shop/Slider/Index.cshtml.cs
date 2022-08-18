using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.Slider;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Slider
{
    public class IndexModel : PageModel
    {
        private readonly ISliderApplication _slider;

        public IndexModel(ISliderApplication slider)
        {
            _slider = slider;
        }
        public IEnumerable<SliderViewModel> Slider;

        public async Task OnGet()
        {
            Slider = await _slider.GetList();
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateSlider());
        }

        public async Task<JsonResult> OnPostCreate(CreateSlider create)
        {
            var result = await _slider.Create(create);
            return new JsonResult(result);
        }
        public async Task<IActionResult> OnGetEdit(int id)
        {
            var model = await _slider.GetById(id);
            return Partial("./Edit", model);
        }
        public async Task<JsonResult> OnPostEdit(EditSlider Edit)
        {
            var result = await _slider.Edit(Edit);
            return new JsonResult(result);
        }
        public async Task<JsonResult> OnGetEnable(long id)
        {
            var result = await _slider.Enable(id);
            return new JsonResult(result);
        }
        public async Task<JsonResult> OnGetDisable(long id)
        {
            var result = await _slider.Disable(id);
            return new JsonResult(result);
        }
        public async Task<JsonResult> OnGetRemove(long id)
        {
            var result = await _slider.Remove(id);
            return new JsonResult(result);
        }
    }
}
