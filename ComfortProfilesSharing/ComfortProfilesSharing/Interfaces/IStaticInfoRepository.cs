using ComfortProfilesSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Interfaces
{
    public interface IStaticInfoRepository
    {
        void AddStaticInfo(StaticInfo staticInfo);
        void UpdateStaticInfo(StaticInfo staticInfo);
        StaticInfo GetStaticInfoByUserId(string appUserId);
        List<MattressType> GetMattressTypes();
        List<ChairType> GetChairTypes();
        List<TableType> GetTableTypes();
        List<WaterType> GetWaterTypes();
    }
}
