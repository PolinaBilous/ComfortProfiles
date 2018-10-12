using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComfortProfilesSharing.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
            return new JsonResult(_roomRepository.GetHowOftens());
        }

        [HttpPost]
        public JsonResult AddRoom(string name)
        {
            Random random = new Random();
            Room room = new Room()
            {
                Id = Guid.NewGuid(),
                AppUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier),
                Name = name, CurrentAirHumidity = random.Next(0, 100),
                CurrentTemperature = random.Next(20, 30),
                CurrentIsLight = random.Next(0, 1) == 0 ? false : true

            };

            if (room.CurrentIsLight)
            {
                room.CurrentLightIntensity = random.Next(20, 100);
            }
            _roomRepository.AddRoom(room);
            return new JsonResult(new { message = "ok" });
        }

        [HttpGet]
        public JsonResult GetUserRooms()
        {
            List<Room> rooms = _roomRepository.GetUserRooms(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return new JsonResult(rooms.Select(r => new { r.Id, r.Name, r.CurrentAirHumidity, r.CurrentIsLight, r.CurrentLightIntensity, r.CurrentTemperature }));
        }
    }
}