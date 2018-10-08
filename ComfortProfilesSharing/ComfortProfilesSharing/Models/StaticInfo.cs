using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Models
{
    public class StaticInfo
    {
        public Guid Id { get; set; }

        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }

        public int ShoeSize { get; set; }
        public int ClothingSize { get; set; }
        public string Allergens { get; set; }
        public string KindOfTea { get; set; }
        public string KindOfCoffee { get; set; }
        public string MusicalPreferences { get; set; }
        public string FruitPreferences { get; set; }

        public int ChairTypeId { get; set; }
        public ChairType ChairType { get; set; }
        public int TableTypeId { get; set; }
        public TableType TableType { get; set; }
        public int MattressTypeId { get; set; }
        public MattressType MattressType { get; set; }
        public int WaterTypeId { get; set; }
        public WaterType WaterType { get; set; }
    }
}
