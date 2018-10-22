using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortProfilesSharing.Models
{
    public class AppUser
    {
        public string Id { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public List<Room> Rooms { get; set; }
        public CoffeeDevice CoffeDevice { get; set; }
        public Teapot Teapot { get; set; }
        public StaticInfo StaticInfo { get; set; }
    }
}
