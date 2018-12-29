using System;
using System.Collections.Generic;
using System.Text;

namespace CPSMobile.Models
{
    public class PreferableRoomsIndicator
    {
        public string roomId { get; set; }
        public string name { get; set; }
        public int? preferableTemperature { get; set; }
        public int? preferableAirHumidity { get; set; }
        public int? preferableLightIntencity { get; set; }
    }

    public class FavoriteCoffeeType
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class PreferableCoffeeTime
    {
        public string coffeeTypeId { get; set; }
        public DateTime date { get; set; }
        public int howOftenId { get; set; }
    }

    public class PreferableTeaTime
    {
        public int temperature { get; set; }
        public DateTime date { get; set; }
        public int howOftenId { get; set; }
    }
}
