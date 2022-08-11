using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        public long ProductId { get;  set; }
        public string Pricture { get;  set; }
        public string? PrictureAlt { get;  set; }
        public string? PrictureTitle { get;  set; }
    }
}
