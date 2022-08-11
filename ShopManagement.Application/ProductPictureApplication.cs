using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Application;

using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPrictureAqq;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
{
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository repository)
        {
            _productPictureRepository = repository;
        }

        public async Task<OperationResult> Create(CreateProductPicture Command)
        {
            var productPicture = new ProductPicture(
                Command.ProductId,
                Command.Pricture,
                Command.PrictureAlt,
                Command.PrictureTitle
                );

            await _productPictureRepository.Create(productPicture);
            await _productPictureRepository.SaveChangesAsync();

            return new OperationResult().Succedded();
        }

        public async Task<OperationResult> Edit(EditProductPicture Command)
        {
            var productPicture = await _productPictureRepository.Get(Command.Id);

            productPicture.Edit(
                Command.ProductId,
                Command.Pricture,
                Command.PrictureAlt,
                Command.PrictureTitle
                );

            await _productPictureRepository.SaveChangesAsync();

            return new OperationResult().Succedded();
        }

        public async Task<EditProductPicture> GetById(long id)
        {
            return await _productPictureRepository.GetById(id);
        }

        public async Task<OperationResult> Remove(long id)
        {
            var productPicture = await _productPictureRepository.Get(id);
            productPicture.Removed();
            await _productPictureRepository.SaveChangesAsync();
            return new OperationResult().Succedded();
        }

        public async Task<OperationResult> Restore(long id)
        {
            var productPicture = await _productPictureRepository.Get(id);
            productPicture.Restore();
            await _productPictureRepository.SaveChangesAsync();
            return new OperationResult().Succedded();
        }

        public async Task<IEnumerable<ProductPictureViewModel>> Search(ProductPictureSearchModel searchModel)
        {
            return await _productPictureRepository.Search(searchModel);
        }
    }
}
