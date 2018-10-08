using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Models
{
    public class Teapot
    {
        public Guid Id { get; set; }

        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }

        public int CurrentTemperature { get; set; }
        public int CurrentWaterAmount { get; set; }

        public List<TeapotLog> TeapotLogs { get; set; }
    }
}
