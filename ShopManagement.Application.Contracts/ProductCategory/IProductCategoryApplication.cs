using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        Task<OperationResult> Create(CreateProductCategory Command);
        Task<OperationResult> Edit(EditProductCategory Command);
        Task<IEnumerable<ProductCategoryViewModel>> Search(ProductCategorySearchViewModel searchModel);
        Task<EditProductCategory> GetById(long id);
    }
}
