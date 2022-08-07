﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _FrameWork.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Name { get;  set; }
        public string? Description { get;  set; }
        public string? Picture { get;  set; }
        public string? PictureAlt { get;  set; }
        public string? PictureTitle { get;  set; }
        public string? Keyword { get;  set; }
        public string? MetaDescript { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }
    }
}
