using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Models
{
    public class CoffeeLog
    {
        public Guid Id { get; set; }

        public Guid CoffeeDeviceId { get; set; }
        public CoffeeDevice CoffeeDevice { get; set; }
        public Guid CoffeeTypeId { get; set; }
        public CoffeeType CoffeeType { get; set; }

        public DateTime Date { get; set; }

        public bool? IsRepeatable { get; set; }
        public int HowOftenId { get; set; }
        public HowOften HowOften { get; set; }
    }
}
