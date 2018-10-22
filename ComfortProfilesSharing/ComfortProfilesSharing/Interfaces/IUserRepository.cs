using ComfortProfilesSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Interfaces
{
    public interface IUserRepository
    {
        AppUser RegisterUser(AppUser appUser);
        AppUser Login(AppUser appUser);
    }
}
