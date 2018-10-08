using ComfortProfilesSharing.Data;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Repositories
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CoffeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // in controller set water, milk, coffee amount to random number
        public void AddCoffeeDevice(CoffeeDevice coffeeDevice)
        {
            _dbContext.CoffeDevices.Add(coffeeDevice);
            _dbContext.SaveChanges();
        }

        public CoffeeDevice GetCoffeeDeviceByUserId(string appUserId)
        {
            return _dbContext.CoffeDevices.FirstOrDefault(cd => cd.AppUserId == appUserId);
        }

        public bool IsCupOfCoffeeNeeded(string appUserId, DateTime dateTime)
        {
            CoffeeDevice coffeeDevice = _dbContext.CoffeDevices
                .Include(cd => cd.CoffeeLogs)
                    .ThenInclude(cl => cl.CoffeeType)
                .Include(cd => cd.CoffeeLogs)
                    .ThenInclude(cl => cl.HowOften)
                .FirstOrDefault(cd => cd.AppUserId == appUserId);

            //logic TODO
            // if needed check type of coffee and minus appropriate amount of coffee, milk and water

            return false;
        }

        public void MakeCupOfCoffee(CoffeeLog coffeeLog)
        {
            _dbContext.CoffeeLogs.Add(coffeeLog);
            CoffeeDevice coffeeDevice = _dbContext.CoffeDevices.FirstOrDefault(cd => cd.Id == coffeeLog.CoffeeDeviceId);
            // check type of coffee and minus appropriate amount of coffee, milk and water
            _dbContext.SaveChanges();
        }
    }
}
