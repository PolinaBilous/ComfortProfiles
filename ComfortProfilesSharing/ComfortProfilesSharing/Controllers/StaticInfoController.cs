using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComfortProfilesSharing.Data;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
using ComfortProfilesSharing.Repositories;
using ComfortProfilesSharing.RequestModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComfortProfilesSharing.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class StaticInfoController : ControllerBase
    {
        private readonly IStaticInfoRepository _staticInfoRepository;

        public StaticInfoController(IStaticInfoRepository staticInfoRepository)
        {
            _staticInfoRepository = staticInfoRepository;
        }

        [HttpPost]
        public void AddStaticInfo(RequestStaticInfo requestStaticInfo)
        {
            _staticInfoRepository.AddStaticInfo(ConvertToStaticInfo(requestStaticInfo));
        }

        [HttpPost]
        public void UpdateStaticInfo(RequestStaticInfo requestStaticInfo)
        {
            _staticInfoRepository.UpdateStaticInfo(ConvertToStaticInfo(requestStaticInfo));
        }

        [HttpGet]
        public JsonResult GetStaticInfoForCurrentUser(string userId)
        {
            StaticInfo staticInfo = _staticInfoRepository.GetStaticInfoByUserId(userId);
            return new JsonResult(ConvertToRequestStaticInfo(staticInfo));
        }

        [HttpGet]
        public JsonResult GetChairTypes()
        {
            return new JsonResult(_staticInfoRepository.GetChairTypes().Select(item => new { item.Id, item.Name}));
        }

        [HttpGet]
        public JsonResult GetTableTypes()
        {
            return new JsonResult(_staticInfoRepository.GetTableTypes().Select(item => new { item.Id, item.Name }));
        }

        [HttpGet]
        public JsonResult GetMattressTypes()
        {
            return new JsonResult(_staticInfoRepository.GetMattressTypes().Select(item => new { item.Id, item.Name }));
        }

        [HttpGet]
        public JsonResult GetWaterTypes()
        {
            return new JsonResult(_staticInfoRepository.GetWaterTypes().Select(item => new { item.Id, item.Name }));
        }

        private StaticInfo ConvertToStaticInfo(RequestStaticInfo requestStaticInfo)
        {
            return new StaticInfo()
            {
                Id = Guid.NewGuid(),
                AppUserId = requestStaticInfo.UserId,
                Allergens = requestStaticInfo.Allergens,
                ChairTypeId = requestStaticInfo.ChairTypeId,
                ClothingSize = requestStaticInfo.ClothingSize,
                FruitPreferences = requestStaticInfo.FruitPreferences,
                KindOfCoffee = requestStaticInfo.KindOfCoffee,
                KindOfTea = requestStaticInfo.KindOfTea,
                MattressTypeId = requestStaticInfo.MattressTypeId,
                MusicalPreferences = requestStaticInfo.MusicalPreferences,
                ShoeSize = requestStaticInfo.ShoeSize,
                TableTypeId = requestStaticInfo.TableTypeId,
                WaterTypeId = requestStaticInfo.WaterTypeId
            };
        }

        private RequestStaticInfo ConvertToRequestStaticInfo(StaticInfo staticInfo)
        {
            return new RequestStaticInfo()
            {
                UserId = staticInfo.AppUserId,
                Allergens = staticInfo.Allergens,
                ChairTypeId = staticInfo.ChairTypeId,
                ClothingSize = staticInfo.ClothingSize,
                FruitPreferences = staticInfo.FruitPreferences,
                KindOfCoffee = staticInfo.KindOfCoffee,
                KindOfTea = staticInfo.KindOfTea,
                MattressTypeId = staticInfo.MattressTypeId,
                MusicalPreferences = staticInfo.MusicalPreferences,
                ShoeSize = staticInfo.ShoeSize,
                TableTypeId = staticInfo.TableTypeId,
                WaterTypeId = staticInfo.WaterTypeId
            };
        }
    }
}