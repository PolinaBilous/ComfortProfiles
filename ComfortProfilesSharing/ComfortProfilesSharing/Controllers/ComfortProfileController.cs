using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.RequestModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComfortProfilesSharing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class ComfortProfileController : ControllerBase
    {
        private readonly IComfortProfileRepository _comfortProfileRepository;

        public ComfortProfileController(IComfortProfileRepository comfortProfileRepository)
        {
            _comfortProfileRepository = comfortProfileRepository;
        }

        [HttpGet]
        public JsonResult GetComfortProfile()
        {
            ComfortProfile comfortProfile = _comfortProfileRepository.GetComfortProfile(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            if (comfortProfile != null)
            {
                return new JsonResult(new { message = "ok", comfortProfile });
            }
            else
            {
                return new JsonResult(new { message = "error"});
            }
        }
    }
}