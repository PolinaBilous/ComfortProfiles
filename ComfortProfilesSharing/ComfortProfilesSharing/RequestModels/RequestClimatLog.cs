using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.RequestModels
{
    public class RequestClimatLog
    {
        public Guid RoomId { get; set; }

        public int Temperature { get; set; }
        public int AirHumidity { get; set; }

        public DateTime Date { get; set; }
       
        public int HowOftenId { get; set; }
    }
}
