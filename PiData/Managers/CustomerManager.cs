using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PiData.Data;
using PiData.Data.Entities;
using PiData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Managers
{
    public class CustomerManager : ICustomerService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerManager(ApplicationDbContext _applicationDbContext)
        {
            this._applicationDbContext = _applicationDbContext;
        }
        public async Task<Customer> AddAsync(Customer customer)
        {
            await _applicationDbContext.Set<Customer>().AddAsync(customer);
            await _applicationDbContext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteAsync(Customer customer)
        {
            _applicationDbContext.Set<Customer>().Remove(customer);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Customer> FirstOrDefaultAsync(ISpecification<Customer> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<List<Customer>> ListAllAsync()
        {
            return await _applicationDbContext.Set<Customer>().ToListAsync();
        }

        public async Task<List<Customer>> ListAsync(ISpecification<Customer> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _applicationDbContext.Entry(customer).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }

        private IQueryable<Customer> ApplySpecification(ISpecification<Customer> spec)
        {
            var evaluator = new SpecificationEvaluator<Customer>();
            return evaluator.GetQuery(_applicationDbContext.Set<Customer>().AsQueryable(), spec);
        }
    }
}
