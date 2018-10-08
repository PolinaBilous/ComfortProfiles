using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }

        public List<Room> Rooms { get; set; }
        public CoffeeDevice CoffeDevice { get; set; }
        public Teapot Teapot { get; set; }
        public StaticInfo StaticInfo { get; set; }
    }
}
