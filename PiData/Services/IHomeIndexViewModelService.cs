using PiData.Data.Entities;
using PiData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Services
{
    public interface IHomeIndexViewModelService
    {
        Task<HomeIndexViewModel> GetHomeIndexViewModel(PropertyType? propertyType, int? squareMeter, int? numberOfRooms,int? floorLocation,int? buildingFloor,WarmingType? warmingType,string userId);
    }
}
