using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Application;

using _FrameWork.Application;

using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public async Task<OperationResult> Create(CreateProduct Command)
        {
            try
            {
                var slug = Command.Slug.Slugify();
                if (await _productRepository.Exists(x => x.Slug == slug))
                    return new OperationResult().Failed(ApplicationMessages.DublicatedRecord);

                var product = new Product(
                    Command.Name,
                    Command.Code,
                    Command.Description,
                    Command.ProductCategoryId,
                    Command.Picture,
                    Command.PictureAlt,
                    Command.PictureTitle,
                    Command.Keyword,
                    Command.MetaDescript,
                    slug,
                    Command.IsActive
                    );
                await _productRepository.Create(product);
                await _productRepository.SaveChangesAsync();

                return new OperationResult().Succedded();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<OperationResult> Delete(long id)
        {
            var product = await _productRepository.Get(id);
            if (product == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            product.Deleted();
            await _productRepository.SaveChangesAsync();
            return new OperationResult().Succedded();
        }

        public async Task<OperationResult> Edit(EditProduct Command)
        {
            var product = await _productRepository.Get(Command.Id);
            if (product == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);

            var slug = Command.Slug.Slugify();

            if (await _productRepository.Exists(x => x.Slug == slug && x.Id != Command.Id))
                return new OperationResult().Failed(ApplicationMessages.DublicatedRecord);
            product.Edit(
                Command.Name,
                Command.Code,
                Command.Description,
                Command.ProductCategoryId,
                Command.Picture,
                Command.PictureAlt,
                Command.PictureTitle,
                Command.Keyword,
                Command.MetaDescript,
                slug,
                Command.IsActive
                );
            await _productRepository.SaveChangesAsync();

            return new OperationResult().Succedded();
        }

        public async Task<EditProduct> GetById(long id)
        {
            return await _productRepository.GetDetail(id);
        }

        public async Task<IEnumerable<ProductViewModel>> Search(ProductSearchModel searchModel)
        {
            return await _productRepository.Search(searchModel);
        }
    }
}
