using ComfortProfilesSharing.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Interfaces
{
    public interface IComfortProfileRepository
    {
        ComfortProfile GetComfortProfile(string appUserId);        
    }
}
