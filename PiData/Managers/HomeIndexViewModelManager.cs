using PiData.Data.Entities;
using PiData.Services;
using PiData.Specification;
using PiData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Managers
{
    public class HomeIndexViewModelManager : IHomeIndexViewModelService
    {
        private readonly IEstateService _estateService;

        public HomeIndexViewModelManager(IEstateService estateService)
        {
            _estateService = estateService;
        }
        public async Task<HomeIndexViewModel> GetHomeIndexViewModel(PropertyType? propertyType, int? squareMeter, int? numberOfRooms, int? floorLocation, int? buildingFloor, WarmingType? warmingType,string userId)
        {
            var spec = new EstateFilterSpecification(propertyType, squareMeter, numberOfRooms, floorLocation, buildingFloor, warmingType,userId);

            var estates = await _estateService.ListAsync(spec);

            return new HomeIndexViewModel()
            {
                Estates = estates
            };
        }
    }
}
