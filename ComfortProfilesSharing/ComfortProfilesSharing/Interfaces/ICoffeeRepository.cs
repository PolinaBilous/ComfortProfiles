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
        void AddCoffeeDevice(CoffeeDevice coffeeDevice);
        // update coffee device state
        void MakeCupOfCoffee(CoffeeLog coffeeLog);
        CoffeeDevice GetCoffeeDeviceByUserId(string appUserId);
        // check coffee device state
        bool IsCupOfCoffeeNeeded(string appUserId, DateTime dateTime);
    }
}
