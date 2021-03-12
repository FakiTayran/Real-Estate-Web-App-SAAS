using PiData.Data.Entities;
using PiData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Services
{
    public interface ICustomerIndexViewModelService
    {
        Task<CustomerIndexViewModel> GetCustomerIndexViewModel(string userId);
    }
}
