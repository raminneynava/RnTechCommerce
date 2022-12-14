using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Application;

using _FrameWork.Application;

using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public async Task<OperationResult> Create(CreateProductCategory Command)
        {
            try
            {
                var slug = Command.Slug.Slugify();
                var filename = _fileUploader.Upload(Command.Picture, "");
                if (await _productCategoryRepository.Exists(x => x.Slug == slug))
                    return new OperationResult().Failed("آدرس تکراری است");

                var productCategory = new ProductCategory(
                    Command.Name,
                    Command.Description,
                    filename,
                    Command.PictureAlt,
                    Command.PictureTitle,
                    Command.Keyword,
                    Command.MetaDescript,
                    slug
                    );
                await _productCategoryRepository.Create(productCategory);
                await _productCategoryRepository.SaveChangesAsync();

                return new OperationResult().Succedded();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<OperationResult> Edit(EditProductCategory Command)
        {

            var productcategoru = await _productCategoryRepository.Get(Command.Id);
            if (productcategoru == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);

            var slug = Command.Slug.Slugify();
            var filename = _fileUploader.Upload(Command.Picture, "");
            if (await _productCategoryRepository.Exists(x => x.Slug == slug && x.Id != Command.Id))
                return new OperationResult().Failed(ApplicationMessages.DublicatedRecord);
            productcategoru.Edit(
                Command.Name,
                Command.Description,
                filename,
                Command.PictureAlt,
                Command.PictureTitle,
                Command.Keyword,
                Command.MetaDescript,
                slug
                );
            await _productCategoryRepository.SaveChangesAsync();

            return new OperationResult().Succedded();
        }

        public async Task<EditProductCategory> GetById(long id)
        {
            return await _productCategoryRepository.GetDetail(id);
        }

        public async Task<IEnumerable<ProductCategoryViewModel>> GetProductCategories()
        {
            return await _productCategoryRepository.GetProductCategories();
        }

        public async Task<IEnumerable<ProductCategoryViewModel>> Search(ProductCategorySearchViewModel searchModel)
        {
            return await _productCategoryRepository.Search(searchModel);
        }
    }
}
