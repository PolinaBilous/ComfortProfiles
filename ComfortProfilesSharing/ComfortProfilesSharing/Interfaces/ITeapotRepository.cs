using ComfortProfilesSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Interfaces
{
    public interface ITeapotRepository
    {
        // check teapot state
        bool AddTeapot(Teapot teapot);
        // update teapot state after some time (think how to do with front)
        void BoilWater(TeapotLog teapotLog);
        Teapot GetTeapotByUserId(string appUserId);
        // check teapot state
        bool IsBoilWaterNeeded(string appUserId, DateTime dateTime);
        List<HowOften> GetHowOftens();
        List<TeapotLog> GetPreferableTeaTimes(string appUserId);
    }
}
