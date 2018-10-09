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

        [HttpPost]
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

            bool isAdded =_coffeeRepository.AddCoffeeDevice(coffeeDevice);

            if (isAdded)
            {
                return new JsonResult(new { message = "ok", coffeDeviceState = GetCurrentUserCoffeeDeviceState() });
            }
            else
            {
                return new JsonResult(new { message = "error" });
            }
        }

        [HttpGet]
        public JsonResult GetCoffeeDeviceState()
        {
            return new JsonResult(GetCurrentUserCoffeeDeviceState());
        }

        [HttpPost]
        public JsonResult MakeCupOfCoffee(RequestCoffeeLog requestCoffeeLog)
        {
            CoffeeDeviceState coffeeDeviceState = GetCurrentUserCoffeeDeviceState();
            if (coffeeDeviceState != null)
            {
                if (IsResourcesAmountEnough(coffeeDeviceState))
                {
                    CoffeeLog coffeeLog = RequestCoffeeLogToCoffeeLog(requestCoffeeLog);
                    _coffeeRepository.MakeCupOfCoffee(coffeeLog);
                    return new JsonResult(new { message = "ok", coffeDeviceState = GetCurrentUserCoffeeDeviceState() });
                }
                else
                {
                    return new JsonResult(new { message = "error", coffeDeviceState = GetCurrentUserCoffeeDeviceState() });
                }
            }
            else
            {
                return new JsonResult(new
                {
                    message = "error",
                });
            }
        }

        [HttpPost]
        public JsonResult MakeCupOfCoffeeIfNeeded()
        {
            CoffeeDeviceState coffeeDeviceState = GetCurrentUserCoffeeDeviceState();
            if (coffeeDeviceState != null)
            {
                if (IsResourcesAmountEnough(coffeeDeviceState))
                {
                    bool isCoffeeDone = _coffeeRepository.MakeCupOfCoffeeIfNeeded(this.User.FindFirstValue(ClaimTypes.NameIdentifier), DateTime.Now);
                    if (isCoffeeDone)
                    {
                        return new JsonResult(new { message = "ok", coffeDeviceState = GetCurrentUserCoffeeDeviceState() });
                    }
                    else
                    {
                        return new JsonResult(new { message = "isn't needed", coffeDeviceState = GetCurrentUserCoffeeDeviceState() });
                    }
                }
                else
                {
                    return new JsonResult(new { message = "error", coffeDeviceState = GetCurrentUserCoffeeDeviceState() });
                }
            }
            else
            {
                return new JsonResult(new
                {
                    message = "error"
                });
            }
        }

        private CoffeeDeviceState GetCurrentUserCoffeeDeviceState()
        {
            CoffeeDevice coffeeDevice = _coffeeRepository.GetCoffeeDeviceByUserId(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (coffeeDevice != null)
            {
                return CoffeDeviceToCoffeeSeviceState(coffeeDevice);
            }
            else
            {
                return null;
            }
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

        private CoffeeLog RequestCoffeeLogToCoffeeLog(RequestCoffeeLog requestCoffeeLog)
        {
            return new CoffeeLog()
            {
                Id = Guid.NewGuid(),
                CoffeeDeviceId = _coffeeRepository.GetCoffeeDeviceByUserId(this.User.FindFirstValue(ClaimTypes.NameIdentifier)).Id,
                CoffeeTypeId = requestCoffeeLog.CoffeeTypeId,
                Date = DateTime.Now,
                HowOftenId = requestCoffeeLog.HowOftenId,
                IsRepeatable = requestCoffeeLog.HowOftenId == 1 ? false : true
            };
        }

        private bool IsResourcesAmountEnough(CoffeeDeviceState coffeeDeviceState)
        {
            return coffeeDeviceState.CurrentWaterAmount > 10 && coffeeDeviceState.CurrentMilkAmount > 10 && coffeeDeviceState.CurrentCoffeeAmount > 5; 
        }
    }
}