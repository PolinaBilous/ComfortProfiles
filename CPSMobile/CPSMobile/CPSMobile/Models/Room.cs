using System;
using System.Collections.Generic;
using System.Text;

namespace CPSMobile.Models
{
    public class Room
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int CurrentAirHumidity { get; set; }
        public bool currentIsLight { get; set; }
        public int currentLightIntensity { get; set; }
        public int currentTemperature { get; set; }
    }
}
