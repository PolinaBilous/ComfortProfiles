using ComfortProfilesSharing.Data;
using ComfortProfilesSharing.Interfaces;
using ComfortProfilesSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Repositories
{
    public class StaticInfoRepository : IStaticInfoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StaticInfoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddStaticInfo(StaticInfo staticInfo)
        {
            if (_dbContext.StaticInfos.FirstOrDefault(st => st.AppUserId == staticInfo.AppUserId) != null)
            {

            }
            if (staticInfo.ChairTypeId == 0)
            {
                staticInfo.ChairTypeId = 4;
            }
            if (staticInfo.TableTypeId == 0)
            {
                staticInfo.TableTypeId = 4;
            }
            if (staticInfo.MattressTypeId == 0)
            {
                staticInfo.MattressTypeId = 4;
            }
            if (staticInfo.WaterTypeId == 0)
            {
                staticInfo.WaterTypeId = 4;
            }
            _dbContext.StaticInfos.Add(staticInfo);
            _dbContext.SaveChanges();
        }

        public List<ChairType> GetChairTypes()
        {
            return _dbContext.ChairTypes.ToList();
        }

        public List<MattressType> GetMattressTypes()
        {
            return _dbContext.MattressTypes.ToList();
        }

        public StaticInfo GetStaticInfoByUserId(string appUserId)
        {
            return _dbContext.StaticInfos.FirstOrDefault(si => si.AppUserId == appUserId);
        }

        public List<TableType> GetTableTypes()
        {
            return _dbContext.TableTypes.ToList();
        }

        public List<WaterType> GetWaterTypes()
        {
            return _dbContext.WaterTypes.ToList();
        }

        public void UpdateStaticInfo(StaticInfo staticInfo)
        {
            var si = _dbContext.StaticInfos.FirstOrDefault(item => item.AppUserId == staticInfo.AppUserId);

            if (si != null)
            {
                si.Allergens = staticInfo.Allergens;
                si.ChairTypeId = staticInfo.ChairTypeId;
                si.ClothingSize = staticInfo.ClothingSize;
                si.FruitPreferences = staticInfo.FruitPreferences;
                si.KindOfCoffee = staticInfo.KindOfCoffee;
                si.KindOfTea = staticInfo.KindOfTea;
                si.MattressTypeId = staticInfo.MattressTypeId;
                si.MusicalPreferences = staticInfo.MusicalPreferences;
                si.ShoeSize = staticInfo.ShoeSize;
                si.TableTypeId = staticInfo.TableTypeId;
                si.WaterTypeId = staticInfo.WaterTypeId;

                _dbContext.SaveChanges();
            }
        }


    }
}
