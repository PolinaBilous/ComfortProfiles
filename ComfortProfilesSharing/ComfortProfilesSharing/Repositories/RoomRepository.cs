using ComfortProfilesSharing.Data;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
using ComfortProfilesSharing.RequestModels;
using Microsoft.EntityFrameworkCore;
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
            _dbContext.ClimatLogs.Add(climatLog);
            if (IsDateTimesEquals(climatLog.Date, DateTime.Now))
            {
                UpdateRoomClimatState(climatLog);
            }

            _dbContext.SaveChanges();
        }

        public void ChangeIllumination(IlluminationLog illuminationLog)
        {
            _dbContext.IlluminationLogs.Add(illuminationLog);
            if (IsDateTimesEquals(illuminationLog.Date, DateTime.Now))
            {
                UpdateRoomIlluminationState(illuminationLog);
            }

            _dbContext.SaveChanges();
        }

        public bool ChangeClimatIfNeeded(string appUserId, DateTime dateTime, Guid roomId)
        {
            Room room = _dbContext.Rooms.Where(rm => rm.Id == roomId)
                .Include(r => r.ClimatLogs)
                    .ThenInclude(cl => cl.HowOften)
                .FirstOrDefault(t => t.AppUserId == appUserId);

            ClimatLog climatLog = room.ClimatLogs.FirstOrDefault(cl => cl.IsRepeatable != true && IsDateTimesEquals(cl.Date, dateTime));

            if (climatLog != null)
            {
                ChangeClimat(climatLog);
                return true;
            }

            List<ClimatLog> climatLogs = room.ClimatLogs.Where(cl => cl.IsRepeatable == true).ToList();

            climatLog = CheckIfClimatChangesNeeded(climatLogs, dateTime);

            if (climatLog != null)
            {
                UpdateRoomClimatState(climatLog);
                return true;
            }

            _dbContext.SaveChanges();
            return false;
        }

        public bool ChangeIlluminationIfNeeded(string appUserId, DateTime dateTime, Guid roomId)
        {
            Room room = _dbContext.Rooms.Where(rm => rm.Id == roomId)
                .Include(r => r.IlluminationLogs)
                    .ThenInclude(il => il.HowOften)
                .FirstOrDefault(t => t.AppUserId == appUserId);

            IlluminationLog illuminationLog = room.IlluminationLogs.FirstOrDefault(cl => cl.IsRepeatable != true && IsDateTimesEquals(cl.Date, dateTime));

            if (illuminationLog != null)
            {
                ChangeIllumination(illuminationLog);
                return true;
            }

            List<IlluminationLog> illuminationLogs = room.IlluminationLogs.Where(cl => cl.IsRepeatable == true).ToList();

            illuminationLog = CheckIfIlluminationChangesNeeded(illuminationLogs, dateTime);

            if (illuminationLog != null)
            {
                UpdateRoomIlluminationState(illuminationLog);
                return true;
            }

            _dbContext.SaveChanges();
            return false;
        }

        public List<HowOften> GetHowOftens()
        {
            return _dbContext.HowOftens.ToList();
        }

        public Room GetRoomById(Guid roomId)
        {
            return _dbContext.Rooms.FirstOrDefault(r => r.Id == roomId);
        }

        public List<Room> GetUserRooms(string appUserId)
        {
            return _dbContext.Rooms.Where(r => r.AppUserId == appUserId).ToList();
        }

        public bool RefreshRoomState(Guid roomId, int temperature, int airHumidity, int lightIntensity)
        {
            Room room = _dbContext.Rooms.FirstOrDefault(r => r.Id == roomId);

            if (room != null)
            {
                room.CurrentTemperature = temperature;
                room.CurrentAirHumidity = airHumidity;
                room.CurrentIsLight = lightIntensity != 0 ? true : false;
                room.CurrentLightIntensity = lightIntensity;

                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public void UpdateRoomClimatState(ClimatLog climatLog)
        {
            Room room = _dbContext.Rooms.FirstOrDefault(r => r.Id == climatLog.RoomId);
            room.CurrentTemperature = climatLog.Temperature;
            room.CurrentAirHumidity = climatLog.AirHumidity;

            _dbContext.SaveChanges();
        }

        public void UpdateRoomIlluminationState(IlluminationLog illuminationLog)
        {
            Room room = _dbContext.Rooms.FirstOrDefault(r => r.Id == illuminationLog.RoomId);
            room.CurrentLightIntensity = illuminationLog.LightIntensity;
            room.CurrentIsLight = illuminationLog.IsLight;

            _dbContext.SaveChanges();
        }

        public List<PreferableRoomIndicators> GetPreferableRoomsIndicators(string appUserId)
        {
            List<PreferableRoomIndicators> result = new List<PreferableRoomIndicators>();

            if (_dbContext.Rooms.Where(r => r.AppUserId == appUserId) == null)
                return result;

            List<Room> rooms = _dbContext.Rooms.Where(r => r.AppUserId == appUserId)
                .Include(r => r.ClimatLogs)
                    .ThenInclude(cl => cl.HowOften)
                .Include(r => r.IlluminationLogs)
                    .ThenInclude(il => il.HowOften).ToList();

            foreach (Room room in rooms)
            {
                int? preferableRoomTemperature = null;
                int? preferableRoomAirHumidity = null;
                int? preferableLightIntencity = null;
                if (room.ClimatLogs.FirstOrDefault() != null)
                {
                    preferableRoomTemperature = room.ClimatLogs.OrderByDescending(cl => cl.Temperature).First().Temperature;
                    preferableRoomAirHumidity = room.ClimatLogs.OrderByDescending(cl => cl.AirHumidity).First().AirHumidity;

                }
                if (room.IlluminationLogs.FirstOrDefault() != null)
                {
                    preferableLightIntencity = room.IlluminationLogs.OrderByDescending(il => il.LightIntensity).First().LightIntensity;
                }

                result.Add(new PreferableRoomIndicators()
                {
                    RoomId = room.Id,
                    PreferableAirHumidity = preferableRoomAirHumidity,
                    PreferableLightIntencity = preferableLightIntencity,
                    PreferableTemperature = preferableRoomTemperature
                });
            }

            return result;
        }

        private ClimatLog CheckIfClimatChangesNeeded(List<ClimatLog> climatLogs, DateTime dateTime)
        {
            ClimatLog result = null;
            List<int> dayOfWeeksId = new List<int>() { 3, 4, 5, 6, 7, 8, 9 };

            foreach (ClimatLog climatLog in climatLogs)
            {
                if (IsDateTimesEquals(dateTime, climatLog.Date) && _dbContext.ClimatLogs.FirstOrDefault(tl => tl.RoomId == climatLog.RoomId && climatLog.Date == tl.Date) == null)
                {
                    result = climatLog;
                }
                if (climatLog.HowOften.Id == 2 && IsTimesEquals(dateTime, climatLog.Date))
                {
                    result = climatLog;
                }
                else if (climatLog.HowOften.Id == 10 && IsDayOfWeekWeekDay(dateTime) && IsTimesEquals(dateTime, climatLog.Date))
                {
                    result = climatLog;
                }
                else if (climatLog.HowOften.Id == 11 && !IsDayOfWeekWeekDay(dateTime) && IsTimesEquals(dateTime, climatLog.Date))
                {
                    result = climatLog;
                }
                else if (dayOfWeeksId.Contains(climatLog.HowOften.Id) && IsDayOfWeekAndTimeEquals(climatLog.Date, dateTime))
                {
                    result = climatLog;
                }
            }

            return result;
        }

        private IlluminationLog CheckIfIlluminationChangesNeeded(List<IlluminationLog> climatLogs, DateTime dateTime)
        {
            IlluminationLog result = null;
            List<int> dayOfWeeksId = new List<int>() { 3, 4, 5, 6, 7, 8, 9 };

            foreach (IlluminationLog illuminationLog in climatLogs)
            {
                if (IsDateTimesEquals(dateTime, illuminationLog.Date) && _dbContext.IlluminationLogs.FirstOrDefault(tl => tl.RoomId == illuminationLog.RoomId && illuminationLog.Date == tl.Date) == null)
                {
                    result = illuminationLog;
                }
                if (illuminationLog.HowOften.Id == 2 && IsTimesEquals(dateTime, illuminationLog.Date))
                {
                    result = illuminationLog;
                }
                else if (illuminationLog.HowOften.Id == 10 && IsDayOfWeekWeekDay(dateTime) && IsTimesEquals(dateTime, illuminationLog.Date))
                {
                    result = illuminationLog;
                }
                else if (illuminationLog.HowOften.Id == 11 && !IsDayOfWeekWeekDay(dateTime) && IsTimesEquals(dateTime, illuminationLog.Date))
                {
                    result = illuminationLog;
                }
                else if (dayOfWeeksId.Contains(illuminationLog.HowOften.Id) && IsDayOfWeekAndTimeEquals(illuminationLog.Date, dateTime))
                {
                    result = illuminationLog;
                }
            }

            return result;
        }

        private bool IsTimesEquals(DateTime t1, DateTime t2)
        {
            return t1.Hour == t2.Hour && t1.Minute == t2.Minute;
        }

        private bool IsDateTimesEquals(DateTime t1, DateTime t2)
        {
            return t1.Date == t2.Date && t1.Hour == t2.Hour && t1.Minute == t2.Minute;
        }

        private bool IsDayOfWeekAndTimeEquals(DateTime t1, DateTime t2)
        {
            return t1.DayOfWeek == t2.DayOfWeek && t1.Hour == t2.Hour && t1.Minute == t2.Minute;
        }

        private bool IsDayOfWeekWeekDay(DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Monday || dateTime.DayOfWeek == DayOfWeek.Tuesday
                || dateTime.DayOfWeek == DayOfWeek.Wednesday || dateTime.DayOfWeek == DayOfWeek.Thursday
                || dateTime.DayOfWeek == DayOfWeek.Friday)
            {
                return true;
            }

            return false;
        }
    }
}

