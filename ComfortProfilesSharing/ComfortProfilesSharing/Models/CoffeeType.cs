using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Models
{
    public class CoffeeType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<CoffeeLog> CoffeLogs { get; set; }
    }
}
