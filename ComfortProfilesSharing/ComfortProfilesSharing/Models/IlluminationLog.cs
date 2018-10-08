using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Models
{
    public class IlluminationLog
    {
        public Guid Id { get; set; }

        public Room Room { get; set; }

        public bool IsLight { get; set; }
        public int LightIntensity { get; set; }

        public DateTime Date { get; set; }

        public bool? IsRepeatable { get; set; }
        public HowOften HowOften { get; set; }
    }
}
