using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Application;

using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _CustomerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _CustomerDiscountRepository = customerDiscountRepository;
        }

        public Task<OperationResult> Define(DefineCustomerDiscount Command)
        {
            var discount = new CustomerDiscount(
                Command.ProductId,
                Command.CategoryId,
                Command.DiscountRate,
                Command.StartDate,
                Command.EndDate,
                Command.Reason,
                );
        }

        public Task<OperationResult> Edit(EditCustomerDiscount Command)
        {
            throw new NotImplementedException();
        }

        public Task<EditCustomerDiscount> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDiscountViewModel>> Search(CustomerDiscountSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
