using Ardalis.Specification;
using PiData.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Specification
{
    public class EstateFilterSpecification : Specification<Estate>
    {
        public EstateFilterSpecification(PropertyType? propertyType, int? squareMeter, int? numberOfRooms, int? floorLocation, int? buildingFloor, WarmingType? warmingType,string userId) : base()
        {
            Query.Where(x => (!propertyType.HasValue || x.PropertyType == propertyType) &&
            (!squareMeter.HasValue || x.SquareMeter >= squareMeter) &&
            (!numberOfRooms.HasValue || x.NumberOfRooms == numberOfRooms) &&
            (!floorLocation.HasValue || x.FloorLocation >= floorLocation) &&
            (!buildingFloor.HasValue || x.BuildingFloor >= buildingFloor) &&
            (!warmingType.HasValue || x.WarmingType == warmingType.Value) && (x.ApplicationUserId==userId)) ;

        }
    }
}
