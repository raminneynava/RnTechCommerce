using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<long, ProductCategory>
    {
        Task<IEnumerable<ProductCategoryViewModel>> Search(ProductCategorySearchViewModel searchModel);
        Task<EditProductCategory> GetDetail(long id);
        Task<IEnumerable<ProductCategoryViewModel>> GetProductCategories();
    }
}
