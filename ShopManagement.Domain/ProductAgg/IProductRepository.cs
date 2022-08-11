using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Domain;

using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository: IRepository<long, Product>
    {
        Task<IEnumerable<ProductViewModel>> Search(ProductSearchModel searchModel);
        Task<EditProduct> GetDetail(long id);

    }
}
