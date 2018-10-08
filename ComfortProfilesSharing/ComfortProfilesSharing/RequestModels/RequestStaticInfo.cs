﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.RequestModels
{
    public class RequestStaticInfo
    {
        public int ShoeSize { get; set; }
        public int ClothingSize { get; set; }
        public string Allergens { get; set; }
        public string KindOfTea { get; set; }
        public string KindOfCoffee { get; set; }
        public string MusicalPreferences { get; set; }
        public string FruitPreferences { get; set; }

        public int ChairTypeId { get; set; }
        public int TableTypeId { get; set; }
        public int MattressTypeId { get; set; }
        public int WaterTypeId { get; set; }
    }
}
