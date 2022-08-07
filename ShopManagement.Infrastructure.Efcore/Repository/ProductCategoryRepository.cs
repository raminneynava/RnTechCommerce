using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using _Framework.Infrastructure;

using Microsoft.EntityFrameworkCore;

using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.Efcore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context):base (context)
        {
            _context = context;
        }
        public async Task<EditProductCategory> GetDetail(long id)
        {
         var query=  await _context.ProductCategories.Select(x => new EditProductCategory()
         {
           Id=x.Id,
           Description=x.Description,
           Name=x.Name,
           MetaDescript=x.MetaDescript,
           Keyword=x.Keyword,
           Picture=x.Picture,
           PictureAlt=x.PictureAlt,
           PictureTitle=x.PictureTitle,
           Slug=x.Slug
         }).FirstOrDefaultAsync(x => x.Id == id);
         return query;
        }

        public async Task<IEnumerable<ProductCategoryViewModel>> Search(ProductCategorySearchViewModel searchModel)
        {
            var query =  _context.ProductCategories.AsNoTrackingWithIdentityResolution().Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
            });
            if (!String.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            query = query.OrderByDescending(x => x.Id);

            return await query.ToListAsync();

        }
    }
}
