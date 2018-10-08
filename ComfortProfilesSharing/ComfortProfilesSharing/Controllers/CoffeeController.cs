using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
using ComfortProfilesSharing.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComfortProfilesSharing.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepository;

        public CoffeeController(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        [HttpGet]
        public JsonResult GetHowOftens()
        {
            return new JsonResult(_coffeeRepository.GetHowOftens().Select(ho => new { ho.Id, ho.Explanation}));
        }

        [HttpGet]
        public JsonResult GetCoffeeTypes()
        {
            return new JsonResult(_coffeeRepository.GetCoffeeTypes().Select(ct => new { ct.Id, ct.Name}));
        }

        [HttpGet]
        public JsonResult AddCoffeeDevice()
        {
            Random random = new Random();
            CoffeeDevice coffeeDevice = new CoffeeDevice()
            {
                Id = Guid.NewGuid(),
                AppUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier),
                CurrentCoffeeAmount = random.Next(0, 100),
                CurrentMilkAmount = random.Next(0, 100),
                CurrentWaterAmount = random.Next(0, 100)
            };

            return new JsonResult(_coffeeRepository.AddCoffeeDevice(coffeeDevice));
        }

        private CoffeeDeviceState CoffeDeviceToCoffeeSeviceState(CoffeeDevice coffeeDevice)
        {
            return new CoffeeDeviceState()
            {
                CurrentCoffeeAmount = coffeeDevice.CurrentCoffeeAmount,
                CurrentMilkAmount = coffeeDevice.CurrentMilkAmount,
                CurrentWaterAmount = coffeeDevice.CurrentWaterAmount
            };
        }
    }
}