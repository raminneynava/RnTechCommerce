using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _CommerceQuery.Contract.Slide;

using Microsoft.EntityFrameworkCore;

using ShopManagement.Infrastructure.Efcore;

namespace _CommerceQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<List<SlideQueryModel>> GetSlides()
        {

                var query = await _shopContext.Sliders
                    .Where(x => x.IsRemoved == false)
                    .Select(x => new SlideQueryModel
                    {
                        Picture = x.Picture,
                        PictureAlt = x.PictureAlt,
                        PictureTitle = x.PictureTitle,
                        Name = x.Name,
                        Link = x.Link,
                        TitleOne = x.TitleOne,
                        TitleTwo = x.TitleTwo,
                    }).ToListAsync();

                return query;
            }
       
        }
    }
