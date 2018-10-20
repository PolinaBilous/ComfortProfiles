using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
using ComfortProfilesSharing.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Repositories
{
    public class ComfortProfileRepository : IComfortProfileRepository
    {
        private readonly IStaticInfoRepository _staticInfoRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly ITeapotRepository _teapotRepository;

        public ComfortProfileRepository(IStaticInfoRepository staticInfoRepository, 
            IRoomRepository roomRepository, 
            ICoffeeRepository coffeeRepository, 
            ITeapotRepository teapotRepository)
        {
            _staticInfoRepository = staticInfoRepository;
            _roomRepository = roomRepository;
            _coffeeRepository = coffeeRepository;
            _teapotRepository = teapotRepository;
        }

        public ComfortProfile GetComfortProfile(string appUserId)
        {
            StaticInfo staticInfo = _staticInfoRepository.GetStaticInfoByUserId(appUserId);
            Nullable<int> comfortTeapotTemperature = null;

            if (_teapotRepository.GetTeapotByUserId(appUserId) != null)
            {
                comfortTeapotTemperature = _teapotRepository.GetTeapotByUserId(appUserId).ComfortTemperature;
            }

            if (staticInfo != null)
            {
                return new ComfortProfile()
                {
                    UserId = appUserId,
                    ShoeSize = staticInfo.ShoeSize,
                    Allergens = staticInfo.Allergens,
                    ChairTypeId = staticInfo.ChairTypeId,
                    ClothingSize = staticInfo.ClothingSize,
                    FruitPreferences = staticInfo.FruitPreferences,
                    KindOfCoffee = staticInfo.KindOfCoffee,
                    KindOfTea = staticInfo.KindOfTea,
                    MattressTypeId = staticInfo.MattressTypeId,
                    MusicalPreferences = staticInfo.MusicalPreferences,
                    TableTypeId = staticInfo.TableTypeId,
                    WaterTypeId = staticInfo.WaterTypeId,
                    PreferableRoomsIndicators = _roomRepository.GetPreferableRoomsIndicators(appUserId),
                    FavoriteCoffeeTypes = _coffeeRepository.GetFavouriteCoffeeTypes(appUserId).Select(ct => ct.Id).ToList(),
                    ComfortTeapotTemperature = comfortTeapotTemperature,
                    PreferableCoffeeTimes = _coffeeRepository.GetPreferableCoffeeTimes(appUserId),
                    PreferableTeaTimes = _teapotRepository.GetPreferableTeaTimes(appUserId)
                };
            }
            else
            {
                return null;
            }
        }
    }
}
