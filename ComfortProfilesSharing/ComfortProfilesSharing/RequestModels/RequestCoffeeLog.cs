using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.RequestModels
{
    public class RequestCoffeeLog
    {
        public Guid CoffeeTypeId { get; set; }
        public int HowOftenId { get; set; }
    }
}
