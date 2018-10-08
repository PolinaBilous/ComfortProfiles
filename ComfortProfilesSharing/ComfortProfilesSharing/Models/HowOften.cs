using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Models
{
    public class HowOften
    {
        public int Id { get; set; }
        public string Explanation { get; set; }

        public List<CoffeeLog> CoffeeLogs { get; set; }
        public List<TeapotLog> TeapotLogs { get; set; }
        public List<ClimatLog> ClimatLogs { get; set; }
        public List<IlluminationLog> IlluminationLogs { get; set; }
    }
}
