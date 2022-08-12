using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ShopManagement.Application.Contracts.Slider
{
    public interface ISliderApplication
    {
        Task<OperationResult> Create(CreateSlider Command);
        Task<OperationResult> Edit(EditSlider Command);
        Task<OperationResult> Remove(long id);
        Task<OperationResult> Enable(long id);
        Task<OperationResult> Disable(long id);
        Task<EditSlider> GetById(long id);
        Task<IEnumerable<SliderViewModel>> GetList();
    }
}
