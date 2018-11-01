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
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public JsonResult GetHowOftens()
        {
            return new JsonResult(_roomRepository.GetHowOftens().Select(ho => new { ho.Id, ho.Explanation}));
        }

        [HttpPost]
        public JsonResult AddRoom(string name, string appUserId)
        {
            Random random = new Random();
            Room room = new Room()
            {
                Id = Guid.NewGuid(),
                AppUserId = appUserId,
                Name = name, CurrentAirHumidity = random.Next(0, 100),
                CurrentTemperature = random.Next(20, 30),
                CurrentIsLight = random.Next(0, 1) == 0 ? false : true

            };

            if (room.CurrentIsLight)
            {
                room.CurrentLightIntensity = random.Next(20, 100);
            }
            _roomRepository.AddRoom(room);
            return new JsonResult(new { message = "ok" , roomState = RoomToRoomState(room)});
        }

        [HttpGet]
        public JsonResult GetUserRooms(string appUserId)
        {
            List<Room> rooms = _roomRepository.GetUserRooms(appUserId);
            return new JsonResult(rooms.Select(r => new { r.Id, r.Name, r.CurrentAirHumidity, r.CurrentIsLight, r.CurrentLightIntensity, r.CurrentTemperature }));
        }

        [HttpPost]
        public JsonResult RefreshRoomState(Guid roomId, int temperature, int airHumidity, int lightIntensity)
        {
            bool isRefreshed = _roomRepository.RefreshRoomState(roomId, temperature, airHumidity, lightIntensity);
            object roomState = RoomStateById(roomId);
            if (isRefreshed)
            {
                return new JsonResult(new { message = "ok", roomState = roomState });
            }
            else
            {
                return new JsonResult(new { message = "error", roomState = roomState });
            }
        }

        [HttpPost]
        public JsonResult ChangeClimat(RequestClimatLog requestClimatLog)
        {
            Room room = _roomRepository.GetRoomById(requestClimatLog.RoomId);
            if (room != null)
            {
                ClimatLog climatLog = RequestClimatLogToClimatLog(requestClimatLog);
                _roomRepository.ChangeClimat(climatLog);
                return new JsonResult(new { message = "ok", coffeDeviceState = RoomStateById(requestClimatLog.RoomId) });
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
        public JsonResult ChangeIllumination(RequestIlluminationLog requestIlluminationLog)
        {
            Room room = _roomRepository.GetRoomById(requestIlluminationLog.RoomId);
            if (room != null)
            {
                IlluminationLog climatLog = RequestIlluminationLogToIlluminationLog(requestIlluminationLog);
                _roomRepository.ChangeIllumination(climatLog);
                return new JsonResult(new { message = "ok", coffeDeviceState = RoomStateById(requestIlluminationLog.RoomId) });
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
        public JsonResult ChangeClimatIfNeeded(Guid roomId)
        {
            Room room = _roomRepository.GetRoomById(roomId);
            if (room != null)
            {
                bool isClimatChangesNeeded = _roomRepository.ChangeClimatIfNeeded(room.AppUserId, DateTime.Now, roomId);
                if (isClimatChangesNeeded)
                {
                    return new JsonResult(new { message = "ok", roomDeviceState = RoomStateById(roomId) });
                }
                else
                {
                    return new JsonResult(new { message = "isn't needed", roomDeviceState = RoomStateById(roomId) });
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

        [HttpPost]
        public JsonResult ChangeIlluminationIfNeeded(Guid roomId)
        {
            Room room = _roomRepository.GetRoomById(roomId);
            if (room != null)
            {
                bool isClimatChangesNeeded = _roomRepository.ChangeClimatIfNeeded(room.AppUserId, DateTime.Now, roomId);
                if (isClimatChangesNeeded)
                {
                    return new JsonResult(new { message = "ok", roomDeviceState = RoomStateById(roomId) });
                }
                else
                {
                    return new JsonResult(new { message = "isn't needed", roomDeviceState = RoomStateById(roomId) });
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

        [HttpGet]
        public JsonResult GetCurrentDateTime()
        {
            return new JsonResult(DateTime.Now);
        }

        private object RoomToRoomState(Room room)
        {
            return new { room.Id, room.Name, room.CurrentAirHumidity, room.CurrentIsLight, room.CurrentLightIntensity, room.CurrentTemperature };
        }

        private object RoomStateById(Guid roomId)
        {
            return RoomToRoomState(_roomRepository.GetRoomById(roomId));
        }

        private ClimatLog RequestClimatLogToClimatLog(RequestClimatLog requestClimatLog)
        {
            return new ClimatLog()
            {
                Id = Guid.NewGuid(),
                Date = requestClimatLog.Date.AddHours(3),
                AirHumidity = requestClimatLog.AirHumidity,
                HowOftenId = requestClimatLog.HowOftenId,
                IsRepeatable = requestClimatLog.HowOftenId == 1 ? false : true,
                RoomId = requestClimatLog.RoomId,
                Temperature = requestClimatLog.Temperature
            };
        }

        private IlluminationLog RequestIlluminationLogToIlluminationLog(RequestIlluminationLog requestIlluminationLog)
        {
            return new IlluminationLog()
            {
                Id = Guid.NewGuid(),
                Date = requestIlluminationLog.Date.AddHours(3),
                HowOftenId = requestIlluminationLog.HowOftenId,
                IsRepeatable = requestIlluminationLog.HowOftenId == 1 ? false : true,
                RoomId = requestIlluminationLog.RoomId,
                LightIntensity = requestIlluminationLog.LightIntensity,
                IsLight = requestIlluminationLog.LightIntensity == 0 ? false : true
            };
        }
    }
}