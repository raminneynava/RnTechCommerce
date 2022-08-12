using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using _Framework.Infrastructure;

using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;

using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure.Efcore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;

        public CustomerDiscountRepository(DiscountContext context) : base(context)
        {
            _context = context;
        }

        public async Task<EditCustomerDiscount> GetById(long id)
        {
            var query= _context.CustomerDiscounts.Select(x => new EditCustomerDiscount{

                Id = id,
                DiscountRate = x.DiscountRate,
                StartDate=x.StartDate.ToString(),
                EndDate=x.EndDate.ToString(),
                CategoryId=x.CategoryId,
                ProductId=x.ProductId,
                Reason=x.Reason,

            }).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public Task<IEnumerable<CustomerDiscountViewModel>> Search(CustomerDiscountSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
