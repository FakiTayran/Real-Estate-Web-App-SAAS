using Ardalis.Specification;
using PiData.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Services
{
    public interface ICustomerService
    {
        Task<Customer> AddAsync(Customer customer);

        Task UpdateAsync(Customer customer);

        Task DeleteAsync(Customer customer);

        Task<List<Customer>> ListAllAsync();

        Task<List<Customer>> ListAsync(ISpecification<Customer> spec);

        Task<Customer> FirstOrDefaultAsync(ISpecification<Customer> spec);


    }
}
