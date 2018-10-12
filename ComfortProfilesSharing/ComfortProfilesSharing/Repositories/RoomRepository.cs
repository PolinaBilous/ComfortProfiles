using ComfortProfilesSharing.Data;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoomRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddRoom(Room room)
        {
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();
        }

        public void ChangeClimat(ClimatLog climatLog)
        {
            throw new NotImplementedException();
        }

        public bool ChangeClimatIfNeeded(string appUserId, DateTime dateTime, Guid roomId)
        {
            throw new NotImplementedException();
        }

        public void ChangeIllumination(IlluminationLog illuminationLog)
        {
            throw new NotImplementedException();
        }

        public bool ChangeIlluminationIfNeeded(string appUserId, DateTime dateTime, Guid roomId)
        {
            throw new NotImplementedException();
        }

        public List<HowOften> GetHowOftens()
        {
            return _dbContext.HowOftens.ToList();
        }

        public List<Room> GetUserRooms(string appUserId)
        {
            return _dbContext.Rooms.Where(r => r.AppUserId == appUserId).ToList();
        }
    }
}
