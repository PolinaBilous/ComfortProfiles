using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
using ComfortProfilesSharing.RequestModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComfortProfilesSharing.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public JsonResult Register(string email, string password, string name)
        {
            AppUser appUser = new AppUser() { Id = Guid.NewGuid().ToString(), Email = email, Name = name, Password = password };

            AppUser resultAppUser = _userRepository.RegisterUser(appUser);

            if (resultAppUser != null)
            {
                return new JsonResult(new { message = "ok", appUser = ConvertToRequestUser(resultAppUser) });
            }
            else
            {
                return new JsonResult(new { message = "error", appUser = resultAppUser != null ? ConvertToRequestUser(resultAppUser) : null});
            }
        }

        [HttpPost]
        public JsonResult Login(string email, string password)
        {
            AppUser appUser = new AppUser() { Email = email, Password = password };

            AppUser resultAppUser = _userRepository.Login(appUser);

            if (resultAppUser != null)
            {
                return new JsonResult(new { message = "ok", appUser = ConvertToRequestUser(resultAppUser) });
            }
            else
            {
                return new JsonResult(new { message = "error", appUser = resultAppUser != null ? ConvertToRequestUser(resultAppUser) : null });
            }
        }

        RequestUser ConvertToRequestUser(AppUser appUser)
        {
            return new RequestUser()
            {
                Id = appUser.Id,
                Email = appUser.Email,
                Name = appUser.Name
            };
        }
    }
}