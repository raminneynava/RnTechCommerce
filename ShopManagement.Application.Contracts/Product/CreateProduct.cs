using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _FrameWork.Application;

using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get;  set; }
        public string Code { get;  set; }
        public string Description { get;  set; }
        public long ProductCategoryId { get;  set; }

        public string Picture { get;  set; }

        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Keyword { get;  set; }
        public string MetaDescript { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }
        public bool IsActive { get;  set; }
        public List<ProductCategoryViewModel> Categories { get; set; }
    }
}
