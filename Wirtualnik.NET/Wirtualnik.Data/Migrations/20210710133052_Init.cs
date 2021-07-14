using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace Wirtualnik.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EAN = table.Column<string>(type: "text", nullable: true),
                    ShortCode = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    ManufacturerCode = table.Column<string>(type: "text", nullable: true),
                    Series = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Warranty = table.Column<string>(type: "text", nullable: true),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    Archived = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Graphic_Chipset = table.Column<string>(type: "text", nullable: true),
                    SlotType = table.Column<string>(type: "text", nullable: true),
                    BaseCoreFreq = table.Column<string>(type: "text", nullable: true),
                    BoostCoreFreq = table.Column<string>(type: "text", nullable: true),
                    MemFreq = table.Column<string>(type: "text", nullable: true),
                    Graphic_MemAmount = table.Column<string>(type: "text", nullable: true),
                    MemType = table.Column<string>(type: "text", nullable: true),
                    SixPinPower = table.Column<string>(type: "text", nullable: true),
                    EightPinPower = table.Column<string>(type: "text", nullable: true),
                    Graphic_TDP = table.Column<string>(type: "text", nullable: true),
                    Lenght = table.Column<string>(type: "text", nullable: true),
                    Width = table.Column<string>(type: "text", nullable: true),
                    Graphic_RGB = table.Column<bool>(type: "boolean", nullable: true),
                    Capacity = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Heads = table.Column<string>(type: "text", nullable: true),
                    Platters = table.Column<string>(type: "text", nullable: true),
                    CacheAmount = table.Column<string>(type: "text", nullable: true),
                    Rpm = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<string>(type: "text", nullable: true),
                    Interface = table.Column<string>(type: "text", nullable: true),
                    ScoreOverall = table.Column<string>(type: "text", nullable: true),
                    Chipset = table.Column<string>(type: "text", nullable: true),
                    Mainboard_Socket = table.Column<string>(type: "text", nullable: true),
                    VrmRating = table.Column<string>(type: "text", nullable: true),
                    VrmPhases = table.Column<string>(type: "text", nullable: true),
                    VrmDetails = table.Column<string>(type: "text", nullable: true),
                    RamSlots = table.Column<string>(type: "text", nullable: true),
                    SataPorts = table.Column<string>(type: "text", nullable: true),
                    M2Ports = table.Column<string>(type: "text", nullable: true),
                    ArgbHeaders = table.Column<string>(type: "text", nullable: true),
                    FanHeaders = table.Column<string>(type: "text", nullable: true),
                    Format = table.Column<string>(type: "text", nullable: true),
                    RamMaxFreq = table.Column<string>(type: "text", nullable: true),
                    RamMaxAmount = table.Column<string>(type: "text", nullable: true),
                    Soundcard = table.Column<string>(type: "text", nullable: true),
                    EthernetSpeed = table.Column<string>(type: "text", nullable: true),
                    EthernetCard = table.Column<string>(type: "text", nullable: true),
                    DefaultGenSupport = table.Column<string>(type: "text", nullable: true),
                    UpdateGenSupport = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    ModuleHeight = table.Column<string>(type: "text", nullable: true),
                    Modules = table.Column<string>(type: "text", nullable: true),
                    MemPerModule = table.Column<string>(type: "text", nullable: true),
                    MemAmount = table.Column<string>(type: "text", nullable: true),
                    XmpFreq = table.Column<string>(type: "text", nullable: true),
                    XmpVoltage = table.Column<string>(type: "text", nullable: true),
                    XmpLatency = table.Column<string>(type: "text", nullable: true),
                    SpdFreq = table.Column<string>(type: "text", nullable: true),
                    SpdVoltage = table.Column<string>(type: "text", nullable: true),
                    Radiator = table.Column<bool>(type: "boolean", nullable: true),
                    RGB = table.Column<bool>(type: "boolean", nullable: true),
                    ScoreDesktopPerf = table.Column<string>(type: "text", nullable: true),
                    ScoreGamingPerf = table.Column<string>(type: "text", nullable: true),
                    ScoreProPerf = table.Column<string>(type: "text", nullable: true),
                    ScoreCinebenchSingle = table.Column<string>(type: "text", nullable: true),
                    ScoreCinebenchMulti = table.Column<string>(type: "text", nullable: true),
                    CacheL1 = table.Column<string>(type: "text", nullable: true),
                    CacheL2 = table.Column<string>(type: "text", nullable: true),
                    CacheL3 = table.Column<string>(type: "text", nullable: true),
                    RamFreq = table.Column<string>(type: "text", nullable: true),
                    TDP = table.Column<string>(type: "text", nullable: true),
                    Cores = table.Column<string>(type: "text", nullable: true),
                    Threads = table.Column<string>(type: "text", nullable: true),
                    BaseFrequency = table.Column<string>(type: "text", nullable: true),
                    BoostFrequency = table.Column<string>(type: "text", nullable: true),
                    Architecture = table.Column<string>(type: "text", nullable: true),
                    Lithography = table.Column<string>(type: "text", nullable: true),
                    Socket = table.Column<string>(type: "text", nullable: true),
                    SocketGen = table.Column<string>(type: "text", nullable: true),
                    Unlocked = table.Column<bool>(type: "boolean", nullable: true),
                    IGPU = table.Column<string>(type: "text", nullable: true),
                    Cooler = table.Column<string>(type: "text", nullable: true),
                    SolidStateDrive_Capacity = table.Column<string>(type: "text", nullable: true),
                    SolidStateDrive_Size = table.Column<string>(type: "text", nullable: true),
                    SolidStateDrive_Interface = table.Column<string>(type: "text", nullable: true),
                    Controller = table.Column<string>(type: "text", nullable: true),
                    MemoryType = table.Column<string>(type: "text", nullable: true),
                    SeqRead = table.Column<string>(type: "text", nullable: true),
                    SeqWrite = table.Column<string>(type: "text", nullable: true),
                    RandRead = table.Column<string>(type: "text", nullable: true),
                    RandWrite = table.Column<string>(type: "text", nullable: true),
                    SolidStateDrive_ScoreOverall = table.Column<string>(type: "text", nullable: true),
                    ScoreSustained = table.Column<string>(type: "text", nullable: true),
                    Tbw = table.Column<string>(type: "text", nullable: true),
                    SolidStateDrive_Radiator = table.Column<bool>(type: "boolean", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    ApiLink = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "ProductShop",
                columns: table => new
                {
                    ShopId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Available = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CleanLink = table.Column<string>(type: "text", nullable: true),
                    RefLink = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShop", x => new { x.ProductId, x.ShopId });
                    table.ForeignKey(
                        name: "FK_ProductShop_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShop_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_ShopId",
                table: "ProductShop",
                column: "ShopId");
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
                name: "ProductShop");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}