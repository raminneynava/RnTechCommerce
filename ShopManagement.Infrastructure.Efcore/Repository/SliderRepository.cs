using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Infrastructure;

using Microsoft.EntityFrameworkCore;

using ShopManagement.Application.Contracts.Slider;
using ShopManagement.Domain.SliderAgg;

namespace ShopManagement.Infrastructure.Efcore.Repository
{
    public class SliderRepository : RepositoryBase<long, Slider>, ISliderRepository
    {
        private readonly ShopContext _context;

        public SliderRepository(ShopContext context) : base(context)
        {
            _context = context;
        }
        public async Task<EditSlider> GetById(long id)
        {
            var query= await _context.Sliders.Select(x => new EditSlider
            {
                Name = x.Name,
                TitleOne = x.TitleOne,
                TitleTwo = x.TitleTwo,  
                Order=x.Order,
                Picture= x.Picture,
                PictureAlt= x.PictureAlt,
                PictureTitle= x.PictureTitle,
                Id=x.Id
            }).FirstOrDefaultAsync(x => x.Id == id);

            return query;
        }

        public async Task<IEnumerable<SliderViewModel>> GetList()
        {
            var query = await _context.Sliders.AsNoTrackingWithIdentityResolution().Select(x => new SliderViewModel
            {
                Name = x.Name,
                Order = x.Order,
                Id = x.Id,
                IsActive=x.IsActive,

            }).OrderByDescending(x => x.Id).ToListAsync();
            return query;
        }
    }
}
