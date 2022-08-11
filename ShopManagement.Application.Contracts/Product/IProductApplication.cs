using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        Task<OperationResult> Create(CreateProduct Command);
        Task<OperationResult> IsInstock(long id);
        Task<OperationResult> NotInstock(long id);
        Task<OperationResult> Delete(long id);
        Task<OperationResult> Edit(EditProduct Command);
        Task<IEnumerable<ProductViewModel>> Search(ProductSearchModel searchModel);
        Task<EditProduct> GetById(long id);
    }
}
