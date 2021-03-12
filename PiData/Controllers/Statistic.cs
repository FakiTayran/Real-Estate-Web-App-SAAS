using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PiData.Data;
using PiData.Data.Entities;
using PiData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Controllers
{
    [Authorize]
    public class Statistic : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public Statistic(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Property Owners", user.Customers.Where(x=>x.Estates.Count() != 0 ).Count()));
            dataPoints.Add(new DataPoint("Customers Looking for A Property ", user.Customers.Where(x => x.Estates.Count() == 0).Count()));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            List<DataPoint> dataPoints1 = new List<DataPoint>();
            dataPoints1.Add(new DataPoint("For Sale", user.Estates.Where(x => x.PropertyType == PropertyType.ForSale).Count()));
            dataPoints1.Add(new DataPoint("For Rent", user.Estates.Where(x => x.PropertyType == PropertyType.ForRent).Count()));
            dataPoints1.Add(new DataPoint("Daily Rent", user.Estates.Where(x => x.PropertyType == PropertyType.DailyRent).Count()));

            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);

            return View();
        }
    }
}
