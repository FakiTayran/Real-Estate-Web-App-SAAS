using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Data.Entities
{
    public class BaseEntity
    {
        [Required]
        public int Id { get; set; }
    }
}
