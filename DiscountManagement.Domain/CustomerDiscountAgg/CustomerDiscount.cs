using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Domain;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public class CustomerDiscount:EntityBase
    {
        public long ProductId { get; private set; }
        public long CategoryId { get; private set; }
        public int DiscountRate { get; private set; }
        public bool IsRemoved { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Reason { get; private set; }//text For discount Reason    

        public CustomerDiscount(long productId, long categoryId, int discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProductId = productId;
            CategoryId = categoryId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
            IsRemoved=false;
        }

        public void Edit(long productId, long categoryId, int discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProductId = productId;
            CategoryId = categoryId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
    }
}
