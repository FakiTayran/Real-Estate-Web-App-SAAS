using Ardalis.Specification;
using PiData.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Services
{
    public interface IEstateService
    {
        Task<Estate> AddAsync(Estate estate);
        Task<List<Estate>> ListAllAsync();
        Task<List<Estate>> ListAsync(ISpecification<Estate> spec);
        Task<Estate> FirstAsync(ISpecification<Estate> spec);

    }
}
