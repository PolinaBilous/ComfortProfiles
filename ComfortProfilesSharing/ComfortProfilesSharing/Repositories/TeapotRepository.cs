using ComfortProfilesSharing.Data;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
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

        public void AddTeapot(Teapot teapot)
        {
            // in controller set water amount and temperature to random number
            _dbContext.Teapots.Add(teapot);
            _dbContext.SaveChanges();
        }

        public void BoilWater(TeapotLog teapotLog)
        {
            _dbContext.TeapotLogs.Add(teapotLog);
            Teapot teapot = _dbContext.Teapots.FirstOrDefault(t => t.Id == teapotLog.TeapotId);
            // update Teapot water amount and temperature, think how to decrease this temperature to preferable on front
            _dbContext.SaveChanges();
        }

        public Teapot GetTeapotByUserId(string appUserId)
        {
            return _dbContext.Teapots.FirstOrDefault(t => t.AppUserId == appUserId);
        }

        public bool IsBoilWaterNeeded(string appUserId, DateTime dateTime)
        {
            //create all logic

            return false;
        }
    }
}
