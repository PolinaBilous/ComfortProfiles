using ComfortProfilesSharing.Data;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Repositories
{
    public class TeapotRepository : ITeapotRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TeapotRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddTeapot(Teapot teapot)
        {
            if (_dbContext.Teapots.FirstOrDefault(t => t.AppUserId == teapot.AppUserId) == null)
            {
                // in controller set water amount and temperature to random number
                _dbContext.Teapots.Add(teapot);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
        
        public Teapot GetTeapotByUserId(string appUserId)
        {
            return _dbContext.Teapots.FirstOrDefault(t => t.AppUserId == appUserId);
        }

        public List<HowOften> GetHowOftens()
        {
            return _dbContext.HowOftens.ToList();
        }

        public void BoilWater(TeapotLog teapotLog)
        {
            _dbContext.TeapotLogs.Add(teapotLog);
            Teapot teapot = _dbContext.Teapots.FirstOrDefault(t => t.Id == teapotLog.TeapotId);
            teapot = UpdateTeapotWhenBoil(teapot, teapotLog);
            _dbContext.SaveChanges();
        }

        public bool IsBoilWaterNeeded(string appUserId, DateTime dateTime)
        {
            Teapot teapot = _dbContext.Teapots
                .Include(t => t.TeapotLogs)
                    .ThenInclude(tl => tl.HowOften)
                .FirstOrDefault(t => t.AppUserId == appUserId);

            List<TeapotLog> repeatableTeapotLogs = _dbContext.TeapotLogs.Where(tl => tl.IsRepeatable == true).ToList();

            TeapotLog currentTeapotLog = IsBoilWaterNeeded(repeatableTeapotLogs, dateTime);

            if (currentTeapotLog != null)
            {
                teapot = UpdateTeapotWhenBoil(teapot, currentTeapotLog);
                return true;
            }

            _dbContext.SaveChanges();
            return false;
        }

        private Teapot UpdateTeapotWhenBoil(Teapot teapot, TeapotLog teapotLog)
        {
            teapot.CurrentTemperature = teapotLog.Temperature;
            return teapot;
        }

        private TeapotLog IsBoilWaterNeeded(List<TeapotLog> teapotLogs, DateTime dateTime)
        {
            TeapotLog result = null;
            List<int> dayOfWeeksId = new List<int>() { 3, 4, 5, 6, 7, 8, 9 };

            foreach (TeapotLog teapotLog in teapotLogs)
            {
                if (teapotLog.HowOften.Id == 2 && IsTimesEquals(dateTime, teapotLog.Date))
                {
                    result = teapotLog;
                }
                else if (teapotLog.HowOften.Id == 10 && IsDayOfWeekWeekDay(dateTime) && IsTimesEquals(dateTime, teapotLog.Date))
                {
                    result = teapotLog;
                }
                else if (teapotLog.HowOften.Id == 11 && !IsDayOfWeekWeekDay(dateTime) && IsTimesEquals(dateTime, teapotLog.Date))
                {
                    result = teapotLog;
                }
                else if (dayOfWeeksId.Contains(teapotLog.HowOften.Id) && IsDayOfWeekAndTimeEquals(teapotLog.Date, dateTime))
                {
                    result = teapotLog;
                }
            }

            return result;
        }

        private bool IsTimesEquals(DateTime t1, DateTime t2)
        {
            return t1.Hour == t2.Hour && t1.Minute == t2.Minute;
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
