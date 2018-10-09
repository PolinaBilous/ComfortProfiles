using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComfortProfilesSharing.Migrations
{
    public partial class first : Migration
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
                    CurrentWaterAmount = table.Column<int>(nullable: false),
                    ComfortTemperature = table.Column<int>(nullable: false)
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
                    CoffeeDeviceId = table.Column<Guid>(nullable: false),
                    CoffeeTypeId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsRepeatable = table.Column<bool>(nullable: true),
                    HowOftenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoffeeLogs_CoffeDevices_CoffeeDeviceId",
                        column: x => x.CoffeeDeviceId,
                        principalTable: "CoffeDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeLogs_CoffeeTypes_CoffeeTypeId",
                        column: x => x.CoffeeTypeId,
                        principalTable: "CoffeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeLogs_HowOftens_HowOftenId",
                        column: x => x.HowOftenId,
                        principalTable: "HowOftens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    TeapotId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Temperature = table.Column<int>(nullable: false),
                    IsRepeatable = table.Column<bool>(nullable: true),
                    HowOftenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeapotLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeapotLogs_HowOftens_HowOftenId",
                        column: x => x.HowOftenId,
                        principalTable: "HowOftens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeapotLogs_Teapots_TeapotId",
                        column: x => x.TeapotId,
                        principalTable: "Teapots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("2079ba33-eeeb-4fef-abab-da81154076cf"), "Americano" },
                    { new Guid("afe1bff2-7390-4f05-9279-b8283b6ca530"), "Latte" },
                    { new Guid("fba08b33-808c-4f56-97c4-f4552c6ab7c9"), "Cappuccino" },
                    { new Guid("0af416be-452b-43b8-a6b1-c49badeb1fd5"), "Espresso" },
                    { new Guid("142564a2-0315-40a0-ac04-0a8e55069f06"), "Macchiato" },
                    { new Guid("426d4e64-84a1-4fd2-bb7a-a4e466e57582"), "Mochaccino" },
                    { new Guid("f5f9bfa0-1aa9-4f28-80ea-f810520970b4"), "Flat White" },
                    { new Guid("e32e46fd-ce70-4bd2-bee7-c261afdc8eee"), "Vienna" }
                });

            migrationBuilder.InsertData(
                table: "HowOftens",
                columns: new[] { "Id", "Explanation" },
                values: new object[,]
                {
                    { 11, "Every Weekend" },
                    { 10, "Every Weekday" },
                    { 9, "Every Sunday" },
                    { 8, "Every Saturday" },
                    { 7, "Every Friday" },
                    { 4, "Every Tuesday" },
                    { 5, "Every Wednesday" },
                    { 3, "Every Monday" },
                    { 2, "Every Day" },
                    { 1, "Never" },
                    { 6, "Every Thursday" }
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
                name: "IX_TeapotLogs_HowOftenId",
                table: "TeapotLogs",
                column: "HowOftenId");

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
