using Clean.ArchitectureDDD.Contracts.Dto;
using Clean.ArchitectureDDD.Contracts.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.ArchitectureDDD.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerSearch _customerSearch;

        public CustomerController(ICustomerSearch customerSearch)
        {
            _customerSearch = customerSearch;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerOverViewDto>> Customer(int customerID)
        {
            return await _customerSearch.GetCustomer(customerID);
        }
    }
}
