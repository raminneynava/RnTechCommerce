using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Domain;

using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Domain.ProductPrictureAqq
{
    public interface IProductPictureRepository: IRepository<long, ProductPicture>
    {
        Task<EditProductPicture> GetById(long id);
        Task<IEnumerable<ProductPictureViewModel>> Search(ProductPictureSearchModel searchModel);
    }
}
