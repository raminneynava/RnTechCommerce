using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slider
{
    public class CreateSlider
    {
        public string Name { get;  set; }
        public string? TitleOne { get;  set; }
        public string? TitleTwo { get;  set; }
        public string? Picture { get;  set; }
        public string? PictureAlt { get;  set; }
        public string? PictureTitle { get;  set; }
        public int Order { get;  set; }
    }
}

