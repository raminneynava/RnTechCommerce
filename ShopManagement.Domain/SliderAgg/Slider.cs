using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Domain;

namespace ShopManagement.Domain.SliderAgg
{
    public class Slider : EntityBase
    {
        public string Name { get; private set; }
        public string TitleOne { get; private set; }
        public string TitleTwo { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public int Order { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsRemoved { get; private set; }
        public string Link { get; private set; }

        public Slider(string name, string titleOne, string titleTwo, string picture, string pictureAlt, string pictureTitle, int order, string link)
        {
            Name = name;
            TitleOne = titleOne;
            TitleTwo = titleTwo;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Order = order;
            IsActive = true;
            IsRemoved = false;
            Link = link;
        }


        public void Edit(string name, string titleOne, string titleTwo, string picture, string pictureAlt, string pictureTitle, int order, string link)
        {
            Name = name;
            TitleOne = titleOne;
            TitleTwo = titleTwo;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Order = order;
            Link = link;
        }

        public void Enable()
        {
            IsActive = true;
        }
        public void Desable()
        {
            IsActive = false;
        }
        public void Removed()
        {
            IsRemoved = true;
        }
    }
}
