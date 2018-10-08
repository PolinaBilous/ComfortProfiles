using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Models
{
    public class WaterType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<StaticInfo> StaticInfos { get; set; }
    }
}
