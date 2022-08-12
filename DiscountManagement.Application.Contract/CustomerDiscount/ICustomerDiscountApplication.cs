using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Application;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        Task<OperationResult> Define(DefineCustomerDiscount Command);
        Task<OperationResult> Edit(EditCustomerDiscount Command);
        Task<OperationResult> Remove(long id);
        Task<IEnumerable<CustomerDiscountViewModel>> Search(CustomerDiscountSearchModel searchModel);
        Task<EditCustomerDiscount> GetById(long id);
    }
}
