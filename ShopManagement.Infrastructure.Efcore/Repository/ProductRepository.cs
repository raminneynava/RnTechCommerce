using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Infrastructure;

using Microsoft.EntityFrameworkCore;

using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.Efcore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }
        public async Task<EditProduct> GetDetail(long id)
        {
            var query = await _context.Products.Select(x => new EditProduct()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                MetaDescript = x.MetaDescript,
                Keyword = x.Keyword,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                ProductCategoryId = x.ProductCategoryId,
                Code=x.Code,
                IsActive=x.IsActive,
                UnitPrice=x.UnitPrice
            }).FirstOrDefaultAsync(x => x.Id == id);
            return query;
        }

        public async Task<IEnumerable<ProductViewModel>> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products.AsNoTrackingWithIdentityResolution().Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                IsInStock = x.IsInStock,
                Code = x.Code,
                Category = x.ProductCategory.Name,
                ProductCategoryId = x.ProductCategoryId,
            });
            if (!String.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!String.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.ProductCategoryId != 0)
                query = query.Where(x => x.ProductCategoryId == searchModel.ProductCategoryId);

            return await query.OrderByDescending(x => x.Id).ToListAsync();
        }
    }
}
