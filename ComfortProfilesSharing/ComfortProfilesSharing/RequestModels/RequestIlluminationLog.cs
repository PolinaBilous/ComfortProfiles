using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.RequestModels
{
    public class RequestIlluminationLog
    {
        public Guid RoomId { get; set; }

        public bool IsLight { get; set; }
        public int LightIntensity { get; set; }

        public DateTime Date { get; set; }
        
        public int HowOftenId { get; set; }
    }
}
