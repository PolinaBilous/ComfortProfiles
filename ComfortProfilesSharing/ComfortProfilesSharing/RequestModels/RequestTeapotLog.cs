using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.RequestModels
{
    public class RequestTeapotLog
    {
        public int Temperature { get; set; }
        public DateTime DateTime { get; set; }
        public int HowOftenId { get; set; }
    }
}
