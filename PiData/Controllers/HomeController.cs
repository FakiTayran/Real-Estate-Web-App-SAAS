using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PiData.Data;
using PiData.Data.Entities;
using PiData.Models;
using PiData.Services;
using PiData.Specification;
using PiData.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeIndexViewModelService _homeIndexViewModelService;
        private readonly ICustomerService _customerService;
        private readonly IEstateService _estateService;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, IHomeIndexViewModelService homeIndexViewModelService, ICustomerService customerService, IEstateService estateService, ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _homeIndexViewModelService = homeIndexViewModelService;
            _customerService = customerService;
            _estateService = estateService;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(PropertyType? propertyType, int? squareMeter, int? numberOfRooms, int? floorLocation, int? buildingFloor, WarmingType? warmingType)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                return View(await _homeIndexViewModelService.GetHomeIndexViewModel(propertyType, squareMeter, numberOfRooms, floorLocation, buildingFloor, warmingType, user.Id));
            }
            else
            {
                return View(await _homeIndexViewModelService.GetHomeIndexViewModel(propertyType, squareMeter, numberOfRooms, floorLocation, buildingFloor, warmingType,null));
            }
        }

        public async Task<IActionResult> Add(int customerId)
        {
            var spec = new CustomerFindSpecification(customerId);
            var customer = await _customerService.FirstOrDefaultAsync(spec);
            ViewBag.customerNameSurname = customer.Name + " " + customer.Surname;
            ViewBag.customerId = customer.Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Estate estate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var spec = new CustomerFindSpecification(estate.OwnerId);
            var customer = await _customerService.FirstOrDefaultAsync(spec);
            estate.Owner = customer;
            estate.ApplicationUserId = user.Id;
            await _estateService.AddAsync(estate);
            customer.Estates.Add(estate);
            user.Estates.Add(estate);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            var spec = new EstateFindSpecification(id);
            var estate = await _estateService.FirstAsync(spec);
            return View(estate);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
