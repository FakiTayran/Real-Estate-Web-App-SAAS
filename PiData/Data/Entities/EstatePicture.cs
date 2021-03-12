using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Data.Entities
{
    public class EstatePicture : BaseEntity
    {
        public string ImageUrl { get; set; }

        [ForeignKey("Estate")]
        public int EstateId { get; set; }
        public  virtual Estate Estate { get; set; }
    }
}
