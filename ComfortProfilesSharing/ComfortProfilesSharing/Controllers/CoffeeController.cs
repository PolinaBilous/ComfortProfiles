using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
using ComfortProfilesSharing.RequestModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComfortProfilesSharing.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
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
        public JsonResult AddCoffeeDevice(string appUserId)
        {
            Random random = new Random();
            CoffeeDevice coffeeDevice = new CoffeeDevice()
            {
                Id = Guid.NewGuid(),
                AppUserId = appUserId,
                CurrentCoffeeAmount = random.Next(0, 100),
                CurrentMilkAmount = random.Next(0, 100),
                CurrentWaterAmount = random.Next(0, 100)
            };

            bool isAdded =_coffeeRepository.AddCoffeeDevice(coffeeDevice);

            if (isAdded)
            {
                return new JsonResult(new { message = "ok", coffeDeviceState = GetCurrentUserCoffeeDeviceState(appUserId) });
            }
            else
            {
                return new JsonResult(new { message = "error", coffeDeviceState = GetCurrentUserCoffeeDeviceState(appUserId) });
            }
        }

        [HttpGet]
        public JsonResult GetCoffeeDeviceState(string appUserId)
        {
            return new JsonResult(GetCurrentUserCoffeeDeviceState(appUserId));
        }

        [HttpPost]
        public JsonResult MakeCupOfCoffee(RequestCoffeeLog requestCoffeeLog)
        {            
            CoffeeDeviceState coffeeDeviceState = GetCurrentUserCoffeeDeviceState(requestCoffeeLog.AppUserId);
            if (coffeeDeviceState != null)
            {
                if (IsResourcesAmountEnough(coffeeDeviceState))
                {
                    CoffeeLog coffeeLog = RequestCoffeeLogToCoffeeLog(requestCoffeeLog);
                    _coffeeRepository.MakeCupOfCoffee(coffeeLog);
                    return new JsonResult(new { message = "ok", coffeDeviceState = GetCurrentUserCoffeeDeviceState(requestCoffeeLog.AppUserId) });
                }
                else
                {
                    _coffeeRepository.UpdateCoffeSeviceState(requestCoffeeLog.AppUserId);
                    return new JsonResult(new { message = "error", coffeDeviceState = GetCurrentUserCoffeeDeviceState(requestCoffeeLog.AppUserId) });
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
        public JsonResult MakeCupOfCoffeeIfNeeded(string appUserId)
        {
            CoffeeDeviceState coffeeDeviceState = GetCurrentUserCoffeeDeviceState(appUserId);
            if (coffeeDeviceState != null)
            {
                if (IsResourcesAmountEnough(coffeeDeviceState))
                {
                    bool isCoffeeDone = _coffeeRepository.MakeCupOfCoffeeIfNeeded(appUserId, DateTime.Now);
                    if (isCoffeeDone)
                    {
                        return new JsonResult(new { message = "ok", coffeDeviceState = GetCurrentUserCoffeeDeviceState(appUserId) });
                    }
                    else
                    {
                        return new JsonResult(new { message = "isn't needed", coffeDeviceState = GetCurrentUserCoffeeDeviceState(appUserId) });
                    }
                }
                else
                {
                    _coffeeRepository.UpdateCoffeSeviceState(appUserId);
                    return new JsonResult(new { message = "error", coffeDeviceState = GetCurrentUserCoffeeDeviceState(appUserId) });
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

        private CoffeeDeviceState GetCurrentUserCoffeeDeviceState(string appUserId)
        {
            CoffeeDevice coffeeDevice = _coffeeRepository.GetCoffeeDeviceByUserId(appUserId);
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
                CoffeeDeviceId = _coffeeRepository.GetCoffeeDeviceByUserId(requestCoffeeLog.AppUserId).Id,
                CoffeeTypeId = requestCoffeeLog.CoffeeTypeId,
                Date = requestCoffeeLog.DateTime.AddHours(3),
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