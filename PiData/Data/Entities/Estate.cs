using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Data.Entities
{
    public class Estate : BaseEntity
    {
        [Required]
        [Display(Name = "Property Type")]

        public PropertyType PropertyType { get; set; }

        [Required]
        [Range(10,1000)]
        [Display(Name = "Square Meter")]

        public int SquareMeter { get; set; }
        [Required]
        [Range(1,10)]
        [Display(Name = "Number Of Rooms")]

        public int NumberOfRooms { get; set; }
        [Required]
        [Range(-4,46)]
        [Display(Name = "Floor Location")]

        public int FloorLocation { get; set; }
        [Required]
        [Range(1,50)]
        [Display(Name = "Building Floor")]

        public int BuildingFloor { get; set; }
        [Required]
        [Display(Name = "Warming Type")]
        public WarmingType WarmingType { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public virtual Customer Owner { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }

    public enum PropertyType 
    {
        [Display(Name = "For Sale")]
        ForSale = 0,
        [Display(Name ="For Rent")]
        ForRent = 1,
        [Display(Name ="Daily Rent")]
        DailyRent = 2
    }

    public enum WarmingType
    { 
        None = 0,
        Stove = 1,
        Heater = 2,
        Central = 3
    }
}
