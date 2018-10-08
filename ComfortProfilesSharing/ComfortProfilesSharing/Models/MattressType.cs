using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Models
{
    public class MattressType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public List<StaticInfo> StaticInfos { get; set; }
    }
}
