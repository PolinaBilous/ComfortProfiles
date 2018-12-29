using System;
using System.Collections.Generic;
using System.Text;

namespace CPSMobile.Models
{
    public class ComfortProfile
    {
        public string userId { get; set; }
        public int shoeSize { get; set; }
        public int clothingSize { get; set; }
        public string allergens { get; set; }
        public string kindOfTea { get; set; }
        public string kindOfCoffee { get; set; }
        public string musicalPreferences { get; set; }
        public string fruitPreferences { get; set; }
        public int chairTypeId { get; set; }
        public int tableTypeId { get; set; }
        public int mattressTypeId { get; set; }
        public int waterTypeId { get; set; }

        public List<PreferableRoomsIndicator> preferableRoomsIndicators { get; set; }
        public List<FavoriteCoffeeType> favoriteCoffeeTypes { get; set; }
        public List<PreferableCoffeeTime> preferableCoffeeTimes { get; set; }
        public int comfortTeapotTemperature { get; set; }
        public List<PreferableTeaTime> preferableTeaTimes { get; set; }
    }
}
