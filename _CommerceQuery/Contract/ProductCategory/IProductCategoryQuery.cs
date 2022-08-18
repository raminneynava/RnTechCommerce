using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CommerceQuery.Contract.ProductCategory
{
    internal interface IProductCategoryQuery
    {
        ProductCategoryQueryModel GetProductCategoryWithProducstsBy(string slug);
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();
    }
}
