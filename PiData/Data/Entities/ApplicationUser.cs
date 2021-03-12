using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50,ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100,ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string ContactNameSurname { get; set; }

        [Required]
        [StringLength(200,ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 15)]
        public string CompanyAddress { get; set; }

        [StringLength(20,ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Fax { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Estate> Estates { get; set; }

    }
}
