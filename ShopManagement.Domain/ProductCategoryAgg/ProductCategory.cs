using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Domain;

using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keyword { get; private set; }
        public string MetaDescript { get; private set; }
        public string Slug { get; private set; }
        public List<Product> Products { get; private set; }

        public ProductCategory()
        {
            Products = new List<Product>();
        }
        public ProductCategory(string name, string description, string picture, string pictureAlt, string pictureTitle, string keyword, string metaDescript, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keyword = keyword;
            MetaDescript = metaDescript;
            Slug = slug;
        }

        public void Edit(string name, string description, string picture, string pictureAlt, string pictureTitle, string keyword, string metaDescript, string slug)
        {
            Name = name;
            Description = description;
            if (!String.IsNullOrEmpty(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keyword = keyword;
            MetaDescript = metaDescript;
            Slug = slug;
        }
    }
}
