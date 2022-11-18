using Clean.Architecture.Domain.Contracts;
using Clean.ArchitectureDDD.Contracts.Dto;
using Clean.ArchitectureDDD.Contracts.UseCases;
using Clean.ArchitectureDDD.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.ArchitectureDDD.Application.UseCases
{
    [ScopedRegister]
    public class CustomerSearch : ICustomerSearch
    {
        public ICustomerRepository _customerRepository;
        
        public CustomerSearch(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public Task<CustomerOverViewDto> GetCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
