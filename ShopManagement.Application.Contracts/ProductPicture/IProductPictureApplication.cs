using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public interface IProductPictureApplication
    {
        Task<OperationResult> Create(CreateProductPicture Command);
        Task<OperationResult> Edit(EditProductPicture Command);
        Task<OperationResult> Remove(long id);
        Task<OperationResult> Restore(long id);
        Task<EditProductPicture> GetById(long id);
        Task<IEnumerable<ProductPictureViewModel>> Search(ProductPictureSearchModel searchModel);
    }
}
