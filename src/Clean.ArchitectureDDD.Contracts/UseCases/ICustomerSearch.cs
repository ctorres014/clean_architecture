using Clean.ArchitectureDDD.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.ArchitectureDDD.Contracts.UseCases
{
    public interface ICustomerSearch
    {
        Task<CustomerOverViewDto> GetCustomer(int id);
    }
}
