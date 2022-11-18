using Clean.Architecture.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Domain.Contracts
{
    public interface ICustomerRepository
    {
        Task<CustomerOverView> GetCustomer(int id);
    }
}
