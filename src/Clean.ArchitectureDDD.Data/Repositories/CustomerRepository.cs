using Clean.Architecture.Domain.Aggregates;
using Clean.Architecture.Domain.Contracts;
using Clean.ArchitectureDDD.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.ArchitectureDDD.Data.Repositories
{
    [ScopedRegister]
    public class CustomerRepository : ICustomerRepository
    {
        public Task<CustomerOverView> GetCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
