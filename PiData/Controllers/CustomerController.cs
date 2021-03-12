using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PiData.Data;
using PiData.Data.Entities;
using PiData.Services;
using PiData.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerIndexViewModelService _customerIndexViewModelService;
        private readonly ICustomerService _customerService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CustomerController(ICustomerIndexViewModelService customerIndexViewModelService,ICustomerService customerService,UserManager<ApplicationUser> userManager,ApplicationDbContext context)
        {
            _customerIndexViewModelService = customerIndexViewModelService;
            _customerService = customerService;
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var user = await GetUser();
            return View(await _customerIndexViewModelService.GetCustomerIndexViewModel(user.Id));
        }

        public  IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer customer) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _customerService.AddAsync(customer);
            var user = await GetUser();
            user.Customers.Add(customer);
            customer.ApplicationUserId = user.Id;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var spec = new CustomerFindSpecification(id);
            var customer = await _customerService.FirstOrDefaultAsync(spec);
            await _customerService.DeleteAsync(customer);
            TempData["CustomerDelete"] = "success";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var spec = new CustomerFindSpecification(id);
            var customer = await _customerService.FirstOrDefaultAsync(spec);
            var user = await GetUser();
            ViewBag.userId = user.Id;
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            await _customerService.UpdateAsync(customer);
            TempData["CustomerEdit"] = "success";
            return RedirectToAction("Index");
        }

        public async Task<ApplicationUser> GetUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return user;
        }

    }
}
