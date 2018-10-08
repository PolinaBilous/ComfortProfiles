using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.RequestModels
{
    public class CoffeeDeviceState
    {
        public int CurrentWaterAmount { get; set; }
        public int CurrentMilkAmount { get; set; }
        public int CurrentCoffeeAmount { get; set; }
    }
}
