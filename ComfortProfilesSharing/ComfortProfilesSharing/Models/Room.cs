using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Models
{
    public class Room
    {
        public Guid Id { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string Name {get; set; }
        public string URL { get; set; }

        public int CurrentTemperature { get; set; }
        public int CurrentAirHumidity { get; set; }
        public bool CurrentIsLight { get; set; }
        public int CurrentLightIntensity { get; set; }

        public List<ClimatLog> ClimatLogs { get; set; }
        public List<IlluminationLog> IlluminationLogs { get; set; }
    }
}
