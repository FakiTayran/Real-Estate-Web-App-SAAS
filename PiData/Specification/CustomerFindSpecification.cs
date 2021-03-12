using Ardalis.Specification;
using PiData.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Specification
{
    public class CustomerFindSpecification : Specification<Customer>
    {
        public CustomerFindSpecification(int customerId)
        {
            Query.Where(x => x.Id == customerId);
        }
    }
}
