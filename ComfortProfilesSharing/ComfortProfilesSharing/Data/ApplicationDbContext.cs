using System;
using System.Collections.Generic;
using System.Text;
using ComfortProfilesSharing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ComfortProfilesSharing.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<CoffeeDevice> CoffeDevices { get; set; }
        public DbSet<CoffeeType> CoffeeTypes { get; set; }
        public DbSet<CoffeeLog> CoffeeLogs { get; set; }
        public DbSet<HowOften> HowOftens { get; set; }
        public DbSet<Teapot> Teapots { get; set; }
        public DbSet<TeapotLog> TeapotLogs { get; set; }
        public DbSet<ClimatLog> ClimatLogs { get; set; }
        public DbSet<IlluminationLog> IlluminationLogs { get; set; }
        public DbSet<StaticInfo> StaticInfos { get; set; }
        public DbSet<ChairType> ChairTypes { get; set; }
        public DbSet<TableType> TableTypes { get; set; }
        public DbSet<MattressType> MattressTypes { get; set; }
        public DbSet<WaterType> WaterTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().HasMany(u => u.Rooms).WithOne(r => r.AppUser);
            builder.Entity<AppUser>().HasOne(u => u.CoffeDevice).WithOne(cd => cd.AppUser);
            builder.Entity<CoffeeDevice>().HasMany(cd => cd.CoffeeLogs).WithOne(cl => cl.CoffeeDevice);
            builder.Entity<CoffeeLog>().HasOne(cl => cl.CoffeeType).WithMany(ct => ct.CoffeLogs);
            builder.Entity<CoffeeDevice>().HasMany(cd => cd.CoffeeLogs).WithOne(pcl => pcl.CoffeeDevice);
            builder.Entity<CoffeeLog>().HasOne(pcl => pcl.HowOften).WithMany(ho => ho.CoffeeLogs);
            builder.Entity<Teapot>().HasOne(t => t.AppUser).WithOne(u => u.Teapot);
            builder.Entity<Teapot>().HasMany(t => t.TeapotLogs).WithOne(tl => tl.Teapot);
            builder.Entity<Teapot>().HasMany(t => t.TeapotLogs).WithOne(ptl => ptl.Teapot);
            builder.Entity<TeapotLog>().HasOne(ptl => ptl.HowOften).WithMany(ho => ho.TeapotLogs);
            builder.Entity<ClimatLog>().HasOne(cl => cl.Room).WithMany(r => r.ClimatLogs);
            builder.Entity<ClimatLog>().HasOne(cl => cl.HowOften).WithMany(ho => ho.ClimatLogs);
            builder.Entity<IlluminationLog>().HasOne(il => il.Room).WithMany(r => r.IlluminationLogs);
            builder.Entity<IlluminationLog>().HasOne(il => il.HowOften).WithMany(ho => ho.IlluminationLogs);
            builder.Entity<StaticInfo>().HasOne(si => si.AppUser).WithOne(u => u.StaticInfo);
            builder.Entity<StaticInfo>().HasOne(si => si.ChairType).WithMany(ct => ct.StaticInfos);
            builder.Entity<StaticInfo>().HasOne(si => si.TableType).WithMany(tt => tt.StaticInfos);
            builder.Entity<StaticInfo>().HasOne(si => si.MattressType).WithMany(mt => mt.StaticInfos);
            builder.Entity<StaticInfo>().HasOne(si => si.WaterType).WithMany(wt => wt.StaticInfos);

            builder.Entity<CoffeeType>().HasData(
                    new CoffeeType() { Id = Guid.NewGuid(), Name = "Americano" },
                    new CoffeeType() { Id = Guid.NewGuid(), Name = "Latte" },
                    new CoffeeType() { Id = Guid.NewGuid(), Name = "Cappuccino" },
                    new CoffeeType() { Id = Guid.NewGuid(), Name = "Espresso" },
                    new CoffeeType() { Id = Guid.NewGuid(), Name = "Macchiato" },
                    new CoffeeType() { Id = Guid.NewGuid(), Name = "Mochaccino" },
                    new CoffeeType() { Id = Guid.NewGuid(), Name = "Flat White" },
                    new CoffeeType() { Id = Guid.NewGuid(), Name = "Vienna" }
                );
            builder.Entity<HowOften>().HasData(
                    new HowOften() { Id = 1, Explanation = "Never"},
                    new HowOften() { Id = 2, Explanation = "Every Day"},
                    new HowOften() { Id = 3, Explanation = "Every Monday"},
                    new HowOften() { Id = 4, Explanation = "Every Tuesday" },
                    new HowOften() { Id = 5, Explanation = "Every Wednesday" },
                    new HowOften() { Id = 6, Explanation = "Every Thursday" },
                    new HowOften() { Id = 7, Explanation = "Every Friday" },
                    new HowOften() { Id = 8, Explanation = "Every Saturday" },
                    new HowOften() { Id = 9, Explanation = "Every Sunday" },
                    new HowOften() { Id = 10, Explanation = "Every Weekday" },
                    new HowOften() { Id = 11, Explanation = "Every Weekend" }
                );
            builder.Entity<ChairType>().HasData(
                    new ChairType() { Id = 1, Name = "Type1" },
                    new ChairType() { Id = 2, Name = "Type2" },
                    new ChairType() { Id = 3, Name = "Type3" },
                    new ChairType() { Id = 4, Name = "Not Selected"}
                );
            builder.Entity<TableType>().HasData(
                    new TableType() { Id = 1, Name = "Type1" },
                    new TableType() { Id = 2, Name = "Type2" },
                    new TableType() { Id = 3, Name = "Type3" },
                    new TableType() { Id = 4, Name = "Not Selected" }
                );
            builder.Entity<WaterType>().HasData(
                    new WaterType() { Id = 1, Name = "Carbonated"},
                    new WaterType() { Id = 2, Name = "Not carbonated" },
                    new WaterType() { Id = 4, Name = "Not Selected" }
                );
            builder.Entity<MattressType>().HasData(
                    new MattressType() { Id = 1, Name = "Type1" },
                    new MattressType() { Id = 2, Name = "Type2" },
                    new MattressType() { Id = 3, Name = "Type3" },
                    new MattressType() { Id = 4, Name = "Not Selected" }
                );
        }
    }
}
