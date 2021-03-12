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
    public class EstateManager : IEstateService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EstateManager(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Estate> AddAsync(Estate estate)
        {
            _applicationDbContext.Entry(estate).State = EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return estate;
        }

        public async Task<Estate> FirstAsync(ISpecification<Estate> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<List<Estate>> ListAllAsync()
        {
            return await _applicationDbContext.Set<Estate>().ToListAsync();
        }

        public async Task<List<Estate>> ListAsync(ISpecification<Estate> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<Estate> ApplySpecification(ISpecification<Estate> spec)
        {
            var evaluator = new SpecificationEvaluator<Estate>();
            return evaluator.GetQuery(_applicationDbContext.Set<Estate>().AsQueryable(), spec);
        }
    }
}
