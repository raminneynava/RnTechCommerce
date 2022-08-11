using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Infrastructure;

using Microsoft.EntityFrameworkCore;

using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPrictureAqq;

namespace ShopManagement.Infrastructure.Efcore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }
        public async Task<EditProductPicture> GetById(long id)
        {
            var query = await _context.ProductPictures.Select(x => new EditProductPicture()
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Pricture = x.Picture,
                PrictureAlt = x.PictureAlt,
                PrictureTitle = x.PictureTitle,
            }).FirstOrDefaultAsync(x => x.Id == id);
            return query;
        }

        public async Task<IEnumerable<ProductPictureViewModel>> Search(ProductPictureSearchModel searchModel)
        {
            var query = _context.ProductPictures.Include(x=>x.product).AsNoTrackingWithIdentityResolution().Select(x => new ProductPictureViewModel()
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToString(),
                Picture = x.Picture,
                Product=x.product.Name,
                ProductId=x.ProductId
            });

            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            return await query.OrderByDescending(x => x.Id).ToListAsync();
        }
    }
}
