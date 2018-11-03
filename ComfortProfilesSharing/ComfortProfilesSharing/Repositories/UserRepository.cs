using ComfortProfilesSharing.Data;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AppUser GetUserById(string userId)
        {
            return _dbContext.AppUsers.FirstOrDefault(u => u.Id == userId);
        }

        public AppUser Login(AppUser appUser)
        {
            if (_dbContext.AppUsers.FirstOrDefault(u => u.Email == appUser.Email) != null)
            {
                return _dbContext.AppUsers.FirstOrDefault(u => u.Email == appUser.Email);
            }
            else
            {
                return null;
            }
        }

        public AppUser RegisterUser(AppUser appUser)
        {
            if (_dbContext.AppUsers.FirstOrDefault(u => u.Email == appUser.Email) == null)
            {
                _dbContext.AppUsers.Add(appUser);
                _dbContext.SaveChanges();

                return _dbContext.AppUsers.FirstOrDefault(u => u.Email == appUser.Email);
            }
            else
            {
                return null;
            }
        }
    }
}
