using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.RequestModels
{
    public class PreferableRoomIndicators
    {
        public Guid RoomId { get; set; }
        public int? PreferableTemperature { get; set; }
        public int? PreferableAirHumidity { get; set; }
        public int? PreferableLightIntencity { get; set; }
    }
}
