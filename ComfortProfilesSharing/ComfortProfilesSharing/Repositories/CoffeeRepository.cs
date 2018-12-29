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
        public bool AddCoffeeDevice(CoffeeDevice coffeeDevice)
        {
            if (_dbContext.CoffeDevices.FirstOrDefault(cd => cd.AppUserId == coffeeDevice.AppUserId) == null)
            {
                _dbContext.CoffeDevices.Add(coffeeDevice);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public CoffeeDevice GetCoffeeDeviceByUserId(string appUserId)
        {
            return _dbContext.CoffeDevices.FirstOrDefault(cd => cd.AppUserId == appUserId);
        }

        public List<HowOften> GetHowOftens()
        {
            return _dbContext.HowOftens.ToList();
        }

        public List<CoffeeType> GetCoffeeTypes()
        {
            return _dbContext.CoffeeTypes.ToList();
        }

        public bool MakeCupOfCoffeeIfNeeded(string appUserId, DateTime dateTime)
        {
            CoffeeDevice coffeeDevice = _dbContext.CoffeDevices
                .Include(cd => cd.CoffeeLogs)
                    .ThenInclude(cl => cl.CoffeeType)
                .Include(cd => cd.CoffeeLogs)
                    .ThenInclude(cl => cl.HowOften)
                .FirstOrDefault(cd => cd.AppUserId == appUserId);

            CoffeeLog currentCoffeeLog = coffeeDevice.CoffeeLogs.FirstOrDefault(cl => cl.IsRepeatable != true && IsDateTimesEquals(cl.Date ,dateTime));

            if (currentCoffeeLog != null)
            {
                MinusCoffeeCosts(coffeeDevice, currentCoffeeLog);
                return true;
            }

            List<CoffeeLog> repeatableCoffeLogs = coffeeDevice.CoffeeLogs.Where(cl => cl.IsRepeatable == true).ToList();

            currentCoffeeLog = IsCupOfCoffeeNeeded(repeatableCoffeLogs, dateTime);

            if (currentCoffeeLog != null)
            {
                coffeeDevice = MinusCoffeeCosts(coffeeDevice, currentCoffeeLog);
                return true;
            }

            _dbContext.SaveChanges();
            return false;
        }

        public void MakeCupOfCoffee(CoffeeLog coffeeLog)
        {
            _dbContext.CoffeeLogs.Add(coffeeLog);
            if (IsDateTimesEquals(DateTime.Now, coffeeLog.Date))
            {
                CoffeeDevice coffeeDevice = _dbContext.CoffeDevices.FirstOrDefault(cd => cd.Id == coffeeLog.CoffeeDeviceId);
                coffeeDevice = MinusCoffeeCosts(coffeeDevice, coffeeLog);
            }
            _dbContext.SaveChanges();
        }

        private CoffeeDevice MinusCoffeeCosts(CoffeeDevice coffeeDevice, CoffeeLog coffeeLog)
        {
            coffeeDevice.CurrentWaterAmount -= 10;
            coffeeDevice.CurrentCoffeeAmount -= 5;
            List<string> coffeeTypesWithMilk = new List<string>() { "Latte", "Cappuccino", "Mochaccino", "Macchiato", "Flat White" };
            if (coffeeTypesWithMilk.Contains(_dbContext.CoffeeTypes.FirstOrDefault(ct => ct.Id == coffeeLog.CoffeeTypeId).Name))
            {
                coffeeDevice.CurrentMilkAmount -= 10;
            }

            return coffeeDevice;
        }

        public CoffeeDevice UpdateCoffeSeviceState(string appUserId)
        {
            CoffeeDevice coffeeDevice = GetCoffeeDeviceByUserId(appUserId);
            coffeeDevice.CurrentCoffeeAmount = 100;
            coffeeDevice.CurrentMilkAmount = 100;
            coffeeDevice.CurrentWaterAmount = 100;

            _dbContext.SaveChanges();

            return coffeeDevice;
        }

        private CoffeeLog IsCupOfCoffeeNeeded(List<CoffeeLog> coffeeLogs, DateTime dateTime)
        {
            CoffeeLog result = null;
            List<int> dayOfWeeksId = new List<int>() { 3, 4, 5, 6, 7, 8, 9};

            foreach(CoffeeLog coffeeLog in coffeeLogs)
            {
                if(IsDateTimesEquals(dateTime, coffeeLog.Date) && _dbContext.CoffeeLogs.FirstOrDefault(cl => cl.CoffeeDeviceId == coffeeLog.CoffeeTypeId && coffeeLog.Date == cl.Date) == null)
                {
                    result = coffeeLog;
                }
                if (coffeeLog.HowOften.Id == 2 && IsTimesEquals(dateTime, coffeeLog.Date))
                {
                    result = coffeeLog;
                }
                else if (coffeeLog.HowOften.Id == 10 && IsDayOfWeekWeekDay(dateTime) && IsTimesEquals(dateTime, coffeeLog.Date))
                {
                    result = coffeeLog;
                }
                else if (coffeeLog.HowOften.Id == 11 && !IsDayOfWeekWeekDay(dateTime) && IsTimesEquals(dateTime, coffeeLog.Date)) { 
                    result = coffeeLog;
                }
                else if (dayOfWeeksId.Contains(coffeeLog.HowOften.Id) && IsDayOfWeekAndTimeEquals(coffeeLog.Date, dateTime))
                {
                    result = coffeeLog;
                }
            }

            return result;
        }


        public List<CoffeeType> GetFavouriteCoffeeTypes(string appUserId)
        {
            List<CoffeeType> coffeeTypes = new List<CoffeeType>();

            CoffeeDevice coffeeDevice = _dbContext.CoffeDevices
                .Include(cd => cd.CoffeeLogs)
                    .ThenInclude(cl => cl.CoffeeType)
                .FirstOrDefault(cd => cd.AppUserId == appUserId);

            if (coffeeDevice != null && coffeeDevice.CoffeeLogs != null)
            {
                coffeeTypes.Add(coffeeDevice.CoffeeLogs.GroupBy(cl => cl.CoffeeType).OrderByDescending(cl => cl.Count()).FirstOrDefault().Key);
                coffeeTypes.Add(coffeeDevice.CoffeeLogs.GroupBy(cl => cl.CoffeeType).OrderByDescending(cl => cl.Count()).Skip(1).Take(1).FirstOrDefault().Key);
                coffeeTypes.Add(coffeeDevice.CoffeeLogs.GroupBy(cl => cl.CoffeeType).OrderByDescending(cl => cl.Count()).Skip(2).Take(1).FirstOrDefault().Key);
            }

            return coffeeTypes;
        }

        public List<CoffeeLog> GetPreferableCoffeeTimes(string appUserId)
        {
            List<CoffeeLog> result = new List<CoffeeLog>();

            CoffeeDevice coffeeDevice = _dbContext.CoffeDevices.FirstOrDefault(cd => cd.AppUserId == appUserId);

            if (coffeeDevice != null && _dbContext.CoffeeLogs.Where(cl => cl.CoffeeDeviceId == coffeeDevice.Id && cl.IsRepeatable == true).FirstOrDefault() != null)
                result = _dbContext.CoffeeLogs.Where(cl => cl.CoffeeDeviceId == coffeeDevice.Id && cl.IsRepeatable == true).ToList();

            else if (coffeeDevice != null)
                result = null;
            
            return result;
        }

        private bool IsTimesEquals(DateTime t1, DateTime t2)
        {
            return t1.Hour == t2.Hour && t1.Minute == t2.Minute;
        }

        private bool IsDateTimesEquals(DateTime t1, DateTime t2)
        {
            return t1.Date == t2.Date && t1.Hour == t2.Hour && t1.Minute == t2.Minute;
        }

        private bool IsDayOfWeekAndTimeEquals(DateTime t1, DateTime t2)
        {
            return t1.DayOfWeek == t2.DayOfWeek && t1.Hour == t2.Hour && t1.Minute == t2.Minute;
        }

        private bool IsDayOfWeekWeekDay(DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Monday || dateTime.DayOfWeek == DayOfWeek.Tuesday 
                || dateTime.DayOfWeek == DayOfWeek.Wednesday || dateTime.DayOfWeek == DayOfWeek.Thursday 
                || dateTime.DayOfWeek == DayOfWeek.Friday)
            {
                return true;
            }

            return false;
        }
    }
}
