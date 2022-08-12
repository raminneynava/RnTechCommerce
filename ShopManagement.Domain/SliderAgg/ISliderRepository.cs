using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using _Framework.Application;
using _Framework.Domain;

using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slider;
using ShopManagement.Domain.ProductPrictureAqq;

namespace ShopManagement.Domain.SliderAgg
{
    public interface ISliderRepository : IRepository<long, Slider>
    {
        Task<EditSlider> GetById(long id);
        Task<IEnumerable<SliderViewModel>> GetList();
    }
}
