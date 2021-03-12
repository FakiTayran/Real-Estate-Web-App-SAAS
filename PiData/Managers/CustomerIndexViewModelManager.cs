using PiData.Data.Entities;
using PiData.Services;
using PiData.Specification;
using PiData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Managers
{
    public class CustomerIndexViewModelManager : ICustomerIndexViewModelService
    {
        private readonly ICustomerService _customerService;

        public CustomerIndexViewModelManager(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerIndexViewModel> GetCustomerIndexViewModel(string userId)
        {
            var spec = new CustomerListFilterSpecification(userId);
            var customers = await _customerService.ListAsync(spec);

            return new CustomerIndexViewModel()
            {
                Customers = customers
            };
        }


    }
}
