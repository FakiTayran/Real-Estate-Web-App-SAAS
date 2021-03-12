using Ardalis.Specification;
using PiData.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Specification
{
    public class EstateFindSpecification : Specification<Estate>
    {
        public EstateFindSpecification(int id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}
