using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using _Framework.Domain;

using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPrictureAqq;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product: EntityBase
    {
        public string Name { get; private set; }
        public string? Code { get; private set; }
        public string? Description { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }//mojoodi anbar
        public long ProductCategoryId { get; private set; }
        public string? Picture { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public string? Keyword { get; private set; }
        public string? MetaDescript { get; private set; }
        public string Slug { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }
        public ProductCategory ProductCategory { get; private set; }
        public ICollection<ProductPicture> ProductPictures { get; private set; }

        public Product(string name,string code, string description, double unitPrice, long productCategoryId, string? picture, string? pictureAlt, string? pictureTitle, string? keyword, string? metaDescript, string slug, bool isActive)
        {
            Name = name;
            Code = code;
            Description = description;
            UnitPrice = unitPrice;
            ProductCategoryId = productCategoryId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keyword = keyword;
            MetaDescript = metaDescript;
            Slug = slug;
            IsActive = isActive;
            IsDeleted = false;
            this.IsInStock = true;

        }
        public void Edit(string name, string code, string description, double unitPrice, long productCategoryId, string? picture, string? pictureAlt, string? pictureTitle, string? keyword, string? metaDescript, string slug, bool isActive)
{
            Name = name;
            Code = code;
            Description = description;
            UnitPrice = unitPrice;
            ProductCategoryId = productCategoryId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keyword = keyword;
            MetaDescript = metaDescript;
            Slug = slug;
            IsActive = isActive;
        }

        public void IsStock()
        {
            this.IsInStock = true;
        }
        public void NotInStock()
        {
            this.IsInStock = false;
        }
        public void Deleted()
        {
            this.IsDeleted = true;
        }
    }
}   
