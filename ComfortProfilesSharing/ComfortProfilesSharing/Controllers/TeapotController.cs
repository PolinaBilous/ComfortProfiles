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
    public class TeapotController : ControllerBase
    {
        private readonly ITeapotRepository _teapotRepository;

        public TeapotController(ITeapotRepository teapotRepository)
        {
            _teapotRepository = teapotRepository;
        }

        [HttpGet]
        public JsonResult GetHowOftens()
        {
            return new JsonResult(_teapotRepository.GetHowOftens().Select(ho => new { ho.Id, ho.Explanation }));
        }

        [HttpPost]
        public JsonResult AddTeapot(int comfortTemperature)
        {
            Random random = new Random();
            Teapot teapot = new Teapot()
            {
                Id = Guid.NewGuid(),
                AppUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier),
                ComfortTemperature = comfortTemperature,
                CurrentTemperature = comfortTemperature,
                CurrentWaterAmount = random.Next(0, 100)
            };

            bool isAdded = _teapotRepository.AddTeapot(teapot);

            if (isAdded)
            {
                return new JsonResult(new { message = "ok", coffeDeviceState = GetCurrentUserTeapotState() });
            }
            else
            {
                return new JsonResult(new { message = "error" });
            }
        }

        [HttpGet]
        public JsonResult GetTeapotState()
        {
            return new JsonResult(GetCurrentUserTeapotState());
        }

        [HttpPost]
        public JsonResult BoilWater(RequestTeapotLog requestTeapotLog)
        {
            object teapotState = GetCurrentUserTeapotState();
            if (teapotState != null)
            {
                TeapotLog teapotLog = RequestTeapotLogToTeapotLog(requestTeapotLog);
                _teapotRepository.BoilWater(teapotLog);
                return new JsonResult(new { message = "ok", coffeDeviceState = GetCurrentUserTeapotState() });
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
        public JsonResult BoilWaterIfNeeded()
        {
            object teapotState = GetCurrentUserTeapotState();
            if (teapotState != null)
            {
                bool IsWaterBoiled = _teapotRepository.IsBoilWaterNeeded(this.User.FindFirstValue(ClaimTypes.NameIdentifier), DateTime.Now);
                if (IsWaterBoiled)
                {
                    return new JsonResult(new { message = "ok", coffeDeviceState = GetCurrentUserTeapotState() });
                }
                else
                {
                    return new JsonResult(new { message = "isn't needed", coffeDeviceState = GetCurrentUserTeapotState() });
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

        private object GetCurrentUserTeapotState()
        {
            Teapot teapot = _teapotRepository.GetTeapotByUserId(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (teapot != null)
            {
                return TeapotToTeapotState(teapot);
            }
            else
            {
                return null;
            }
        }

        private object TeapotToTeapotState(Teapot teapot)
        {
            Random random = new Random();
            // TODO: check teapot log for last 5 minutes: if there is boil water, set to teapot log temperature, if no - comfort temperature
            return new { currentTemperature = teapot.CurrentTemperature, currentWaterAmount = random.Next(0, 100) };
        } 

        private TeapotLog RequestTeapotLogToTeapotLog(RequestTeapotLog requestTeapotLog)
        {
            return new TeapotLog()
            {
                Id = Guid.NewGuid(),
                HowOftenId = requestTeapotLog.HowOftenId,
                IsRepeatable = requestTeapotLog.HowOftenId == 1 ? false : true,
                Date = requestTeapotLog.DateTime,
                TeapotId = _teapotRepository.GetTeapotByUserId(this.User.FindFirstValue(ClaimTypes.NameIdentifier)).Id,
                Temperature = requestTeapotLog.Temperature
            };
        }
    }
}