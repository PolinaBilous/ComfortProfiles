using ComfortProfilesSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Interfaces
{
    public interface IRoomRepository
    {
        void AddRoom(Room room);
        void ChangeClimat(ClimatLog climatLog);
        void ChangeIllumination(IlluminationLog illuminationLog);
        bool ChangeClimatIfNeeded(string appUserId, DateTime dateTime, Guid roomId);
        bool ChangeIlluminationIfNeeded(string appUserId, DateTime dateTime, Guid roomId);
        List<HowOften> GetHowOftens();
        List<Room> GetUserRooms(string appUserId); 
    }
}
