using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CommerceQuery.Contract.Slide
{
    public interface ISlideQuery
    {
       Task<List<SlideQueryModel>> GetSlides();
    }
}
