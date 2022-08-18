using _CommerceQuery.Contract.Slide;

using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SliderViewComponent: ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SliderViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }

        public  IViewComponentResult Invoke()
        {
            var slide = _slideQuery.GetSlides().Result;
            return View(slide);
        }
    }
}
