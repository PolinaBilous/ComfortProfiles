using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.RequestModels
{
    public class RequestTeapotLog
    {
        public int Temperature { get; set; }
        public bool? IsRepeatable { get; set; }

        public Guid HowOftenId { get; set; }
    }
}
