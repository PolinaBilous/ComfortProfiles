﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComfortProfilesSharing.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChairTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChairTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HowOftens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Explanation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HowOftens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MattressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MattressTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoffeDevices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    CurrentWaterAmount = table.Column<int>(nullable: false),
                    CurrentMilkAmount = table.Column<int>(nullable: false),
                    CurrentCoffeeAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoffeDevices_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teapots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    CurrentTemperature = table.Column<int>(nullable: false),
                    CurrentWaterAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teapots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teapots_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaticInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    ShoeSize = table.Column<int>(nullable: false),
                    ClothingSize = table.Column<int>(nullable: false),
                    Allergens = table.Column<string>(nullable: true),
                    KindOfTea = table.Column<string>(nullable: true),
                    KindOfCoffee = table.Column<string>(nullable: true),
                    MusicalPreferences = table.Column<string>(nullable: true),
                    FruitPreferences = table.Column<string>(nullable: true),
                    ChairTypeId = table.Column<int>(nullable: false),
                    TableTypeId = table.Column<int>(nullable: false),
                    MattressTypeId = table.Column<int>(nullable: false),
                    WaterTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticInfos_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaticInfos_ChairTypes_ChairTypeId",
                        column: x => x.ChairTypeId,
                        principalTable: "ChairTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticInfos_MattressTypes_MattressTypeId",
                        column: x => x.MattressTypeId,
                        principalTable: "MattressTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticInfos_TableTypes_TableTypeId",
                        column: x => x.TableTypeId,
                        principalTable: "TableTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticInfos_WaterTypes_WaterTypeId",
                        column: x => x.WaterTypeId,
                        principalTable: "WaterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CoffeeDeviceId = table.Column<Guid>(nullable: true),
                    CoffeeTypeId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsRepeatable = table.Column<bool>(nullable: true),
                    HowOftenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoffeeLogs_CoffeDevices_CoffeeDeviceId",
                        column: x => x.CoffeeDeviceId,
                        principalTable: "CoffeDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoffeeLogs_CoffeeTypes_CoffeeTypeId",
                        column: x => x.CoffeeTypeId,
                        principalTable: "CoffeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoffeeLogs_HowOftens_HowOftenId",
                        column: x => x.HowOftenId,
                        principalTable: "HowOftens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClimatLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: true),
                    Temperature = table.Column<int>(nullable: false),
                    AirHumidity = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsRepeatable = table.Column<bool>(nullable: true),
                    HowOftenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimatLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClimatLogs_HowOftens_HowOftenId",
                        column: x => x.HowOftenId,
                        principalTable: "HowOftens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClimatLogs_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IlluminationLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: true),
                    IsLight = table.Column<bool>(nullable: false),
                    LightIntensity = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsRepeatable = table.Column<bool>(nullable: true),
                    HowOftenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IlluminationLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IlluminationLogs_HowOftens_HowOftenId",
                        column: x => x.HowOftenId,
                        principalTable: "HowOftens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IlluminationLogs_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeapotLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TeapotId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Temperature = table.Column<int>(nullable: false),
                    IsRepeatable = table.Column<bool>(nullable: true),
                    HowOftenId = table.Column<Guid>(nullable: false),
                    HowOftenId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeapotLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeapotLogs_HowOftens_HowOftenId1",
                        column: x => x.HowOftenId1,
                        principalTable: "HowOftens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeapotLogs_Teapots_TeapotId",
                        column: x => x.TeapotId,
                        principalTable: "Teapots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ChairTypes",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Type1", null },
                    { 2, "Type2", null },
                    { 3, "Type3", null }
                });

            migrationBuilder.InsertData(
                table: "CoffeeTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("09a223f8-7cc2-43cf-b004-83cbc1f79668"), "Americano" },
                    { new Guid("5dbf3b8f-bc7d-48f6-8844-54ac0b36f153"), "Latte" },
                    { new Guid("90759e7e-50c8-4a4a-9a98-c9a7723236f7"), "Cappuccino" },
                    { new Guid("6337dcba-3cb1-45c6-93b4-e424811b95d4"), "Espresso" },
                    { new Guid("47100ce9-2204-458d-83d2-d303027b1d5f"), "Macchiato" },
                    { new Guid("2fc3daab-d1ff-4ca2-b0e8-391bf27edb55"), "Mochaccino" },
                    { new Guid("f336a11f-86ca-40e2-8fa2-cd8807710e89"), "Flat White" },
                    { new Guid("9f70ebef-e2e2-4354-bd70-a721238c3e42"), "Vienna" }
                });

            migrationBuilder.InsertData(
                table: "HowOftens",
                columns: new[] { "Id", "Explanation" },
                values: new object[,]
                {
                    { 9, "Every Sunday" },
                    { 8, "Every Saturday" },
                    { 7, "Every Friday" },
                    { 6, "Every Thursday" },
                    { 3, "Every Monday" },
                    { 4, "Every Tuesday" },
                    { 2, "Every Day" },
                    { 1, "Never" },
                    { 5, "Every Wednesday" }
                });

            migrationBuilder.InsertData(
                table: "MattressTypes",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Type1", null },
                    { 2, "Type2", null },
                    { 3, "Type3", null }
                });

            migrationBuilder.InsertData(
                table: "TableTypes",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Type1", null },
                    { 2, "Type2", null },
                    { 3, "Type3", null }
                });

            migrationBuilder.InsertData(
                table: "WaterTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Carbonated" },
                    { 2, "Not carbonated" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClimatLogs_HowOftenId",
                table: "ClimatLogs",
                column: "HowOftenId");

            migrationBuilder.CreateIndex(
                name: "IX_ClimatLogs_RoomId",
                table: "ClimatLogs",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeDevices_AppUserId",
                table: "CoffeDevices",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeLogs_CoffeeDeviceId",
                table: "CoffeeLogs",
                column: "CoffeeDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeLogs_CoffeeTypeId",
                table: "CoffeeLogs",
                column: "CoffeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeLogs_HowOftenId",
                table: "CoffeeLogs",
                column: "HowOftenId");

            migrationBuilder.CreateIndex(
                name: "IX_IlluminationLogs_HowOftenId",
                table: "IlluminationLogs",
                column: "HowOftenId");

            migrationBuilder.CreateIndex(
                name: "IX_IlluminationLogs_RoomId",
                table: "IlluminationLogs",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AppUserId",
                table: "Rooms",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticInfos_AppUserId",
                table: "StaticInfos",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StaticInfos_ChairTypeId",
                table: "StaticInfos",
                column: "ChairTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticInfos_MattressTypeId",
                table: "StaticInfos",
                column: "MattressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticInfos_TableTypeId",
                table: "StaticInfos",
                column: "TableTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticInfos_WaterTypeId",
                table: "StaticInfos",
                column: "WaterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeapotLogs_HowOftenId1",
                table: "TeapotLogs",
                column: "HowOftenId1");

            migrationBuilder.CreateIndex(
                name: "IX_TeapotLogs_TeapotId",
                table: "TeapotLogs",
                column: "TeapotId");

            migrationBuilder.CreateIndex(
                name: "IX_Teapots_AppUserId",
                table: "Teapots",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClimatLogs");

            migrationBuilder.DropTable(
                name: "CoffeeLogs");

            migrationBuilder.DropTable(
                name: "IlluminationLogs");

            migrationBuilder.DropTable(
                name: "StaticInfos");

            migrationBuilder.DropTable(
                name: "TeapotLogs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CoffeDevices");

            migrationBuilder.DropTable(
                name: "CoffeeTypes");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "ChairTypes");

            migrationBuilder.DropTable(
                name: "MattressTypes");

            migrationBuilder.DropTable(
                name: "TableTypes");

            migrationBuilder.DropTable(
                name: "WaterTypes");

            migrationBuilder.DropTable(
                name: "HowOftens");

            migrationBuilder.DropTable(
                name: "Teapots");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
