using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        public int DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }//text For discount Reason    
    }
}
