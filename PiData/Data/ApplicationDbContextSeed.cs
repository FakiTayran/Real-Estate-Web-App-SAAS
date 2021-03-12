using PiData.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace PiData.Data
{
    public static class ApplicationDbContextSeed
    {

        public async static Task<IHost> SeedAsync(this IHost host)
        {
            var scope = host.Services.CreateScope();
            var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //if (!await applicationDbContext.Customers.AnyAsync())
            //{
            //    await applicationDbContext.Customers.AddAsync(new Customer() { Name = "Tayran", Surname = "Arıduru", Email = "aridurufakitayran@gmail.com", Phone = "5449576553" });
            //    await applicationDbContext.Customers.AddAsync(new Customer() { Name = "Ali", Surname = "Yılmaz", Email = "aliyilmaz@gmail.com", Phone = "1234567890" });
            //    await applicationDbContext.SaveChangesAsync();
            //}
            //if (!await applicationDbContext.Estates.AnyAsync())
            //{
            //    await applicationDbContext.Estates.AddAsync(new Estate { PropertyType = PropertyType.ForRent, BuildingFloor = 7, FloorLocation = 3, SquareMeter = 300, NumberOfRooms = 4, WarmingType = WarmingType.Heater, OwnerId = 1 });
            //    await applicationDbContext.SaveChangesAsync();
            //}


            return host;
        }
    }
}
