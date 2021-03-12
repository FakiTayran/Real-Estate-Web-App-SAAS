using Ardalis.Specification;
using PiData.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Specification
{
    public class CustomerListFilterSpecification : Specification<Customer>
    {
        public CustomerListFilterSpecification(string userId) : base()
        {
            Query.Where(x => x.ApplicationUserId == userId);
        }
    }
}
