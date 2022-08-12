using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Domain;

using DiscountManagement.Application.Contract.CustomerDiscount;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository: IRepository<long, CustomerDiscount>
    {
        Task<IEnumerable<CustomerDiscountViewModel>> Search(CustomerDiscountSearchModel searchModel);
        Task<EditCustomerDiscount> GetById(long id);
    }
}
