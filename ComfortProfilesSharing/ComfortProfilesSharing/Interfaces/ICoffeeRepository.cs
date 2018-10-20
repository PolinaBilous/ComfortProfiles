using ComfortProfilesSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Interfaces
{
    public interface ICoffeeRepository
    {
        // check coffee device state
        // return coffee device state in controller
        bool AddCoffeeDevice(CoffeeDevice coffeeDevice);
        // update coffee device state
        // return coffee device state in controller
        void MakeCupOfCoffee(CoffeeLog coffeeLog);
        CoffeeDevice GetCoffeeDeviceByUserId(string appUserId);
        // check coffee device state
        // return coffee device state in controller
        bool MakeCupOfCoffeeIfNeeded(string appUserId, DateTime dateTime);
        List<HowOften> GetHowOftens();
        List<CoffeeType> GetCoffeeTypes();
        List<CoffeeType> GetFavouriteCoffeeTypes(string appUserId);
        List<CoffeeLog> GetPreferableCoffeeTimes(string appUserId);
    }
}
