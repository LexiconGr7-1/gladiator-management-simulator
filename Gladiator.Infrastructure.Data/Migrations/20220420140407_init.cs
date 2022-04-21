using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gladiator.Infrastructure.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arena",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arena", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArenaPlayer",
                columns: table => new
                {
                    OwnedArenasId = table.Column<int>(type: "int", nullable: false),
                    OwnersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaPlayer", x => new { x.OwnedArenasId, x.OwnersId });
                    table.ForeignKey(
                        name: "FK_ArenaPlayer_Arena_OwnedArenasId",
                        column: x => x.OwnedArenasId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArenaPlayer_Player_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ArenaId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                    table.ForeignKey(
                        name: "FK_School_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gladiator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    StatsId = table.Column<int>(type: "int", nullable: false),
                    StatUpdatesId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gladiator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gladiator_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gladiator_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Gladiator_Stats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "Stats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gladiator_Stats_StatUpdatesId",
                        column: x => x.StatUpdatesId,
                        principalTable: "Stats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BattleLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Log = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GladiatorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleLog_Gladiator_GladiatorId",
                        column: x => x.GladiatorId,
                        principalTable: "Gladiator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Armor = table.Column<int>(type: "int", nullable: false),
                    Durability = table.Column<int>(type: "int", nullable: false),
                    Slots = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    StatModifiersPointsId = table.Column<int>(type: "int", nullable: false),
                    StatModifiersPercentId = table.Column<int>(type: "int", nullable: false),
                    GladiatorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gear_Gladiator_GladiatorId",
                        column: x => x.GladiatorId,
                        principalTable: "Gladiator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gear_Stats_StatModifiersPercentId",
                        column: x => x.StatModifiersPercentId,
                        principalTable: "Stats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gear_Stats_StatModifiersPointsId",
                        column: x => x.StatModifiersPointsId,
                        principalTable: "Stats",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Arena",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7361), "Arena 1", new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7362) },
                    { 2, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7364), "Arena 2", new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7364) }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7051), "Player 1", new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7055) },
                    { 2, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7057), "Player 2", new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7057) },
                    { 3, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7058), "Player 3", new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7058) },
                    { 4, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7059), "Player 4", new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7060) }
                });

            migrationBuilder.InsertData(
                table: "Stats",
                columns: new[] { "Id", "Agility", "Constitution", "CreatedAt", "Dexterity", "Intelligence", "Strength", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7468), 1, 1, 1, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7469) },
                    { 2, 2, 2, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7473), 2, 2, 2, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7474) },
                    { 3, 3, 3, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7474), 3, 3, 3, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7475) },
                    { 4, 4, 4, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7475), 4, 4, 4, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7476) },
                    { 5, 5, 5, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7476), 5, 5, 5, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7476) },
                    { 6, 6, 6, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7478), 6, 6, 6, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7478) },
                    { 7, 7, 7, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7479), 7, 7, 7, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7480) },
                    { 8, 8, 8, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7480), 8, 8, 8, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7480) },
                    { 9, 9, 9, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7481), 9, 9, 9, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7481) },
                    { 10, 10, 10, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7483), 10, 10, 10, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7483) },
                    { 11, 11, 11, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7484), 11, 11, 11, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7484) },
                    { 12, 12, 12, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7484), 12, 12, 12, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7485) },
                    { 13, 13, 13, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7485), 13, 13, 13, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7486) },
                    { 14, 14, 14, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7533), 14, 14, 14, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7534) },
                    { 15, 15, 15, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7535), 15, 15, 15, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7535) },
                    { 16, 16, 16, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7536), 16, 16, 16, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7536) },
                    { 17, 17, 17, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7536), 17, 17, 17, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7537) },
                    { 18, 18, 18, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7539), 18, 18, 18, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7539) },
                    { 19, 19, 19, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7540), 19, 19, 19, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7540) },
                    { 20, 20, 20, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7541), 20, 20, 20, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7541) },
                    { 21, 21, 21, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7541), 21, 21, 21, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7542) },
                    { 22, 22, 22, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7542), 22, 22, 22, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7542) },
                    { 23, 23, 23, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7543), 23, 23, 23, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7543) },
                    { 24, 24, 24, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7544), 24, 24, 24, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7544) },
                    { 25, 25, 25, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7545), 25, 25, 25, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7545) },
                    { 26, 26, 26, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7545), 26, 26, 26, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7546) },
                    { 27, 27, 27, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7546), 27, 27, 27, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7546) },
                    { 28, 28, 28, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7547), 28, 28, 28, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7547) },
                    { 29, 29, 29, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7548), 29, 29, 29, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7548) },
                    { 30, 30, 30, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7549), 30, 30, 30, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7549) },
                    { 31, 31, 31, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7549), 31, 31, 31, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7550) },
                    { 32, 32, 32, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7550), 32, 32, 32, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7550) },
                    { 33, 33, 33, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7551), 33, 33, 33, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7551) },
                    { 34, 34, 34, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7553), 34, 34, 34, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7553) },
                    { 35, 35, 35, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7554), 35, 35, 35, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7554) },
                    { 36, 36, 36, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7555), 36, 36, 36, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7555) }
                });

            migrationBuilder.InsertData(
                table: "Stats",
                columns: new[] { "Id", "Agility", "Constitution", "CreatedAt", "Dexterity", "Intelligence", "Strength", "UpdatedAt" },
                values: new object[,]
                {
                    { 37, 37, 37, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7555), 37, 37, 37, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7556) },
                    { 38, 38, 38, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7556), 38, 38, 38, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7556) },
                    { 39, 39, 39, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7557), 39, 39, 39, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7557) },
                    { 40, 40, 40, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7558), 40, 40, 40, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7558) },
                    { 41, 41, 41, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7559), 41, 41, 41, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7559) },
                    { 42, 42, 42, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7559), 42, 42, 42, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7560) },
                    { 43, 43, 43, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7560), 43, 43, 43, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7560) },
                    { 44, 44, 44, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7561), 44, 44, 44, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7561) },
                    { 45, 45, 45, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7562), 45, 45, 45, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7562) },
                    { 46, 46, 46, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7562), 46, 46, 46, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7563) },
                    { 47, 47, 47, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7563), 47, 47, 47, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7564) },
                    { 48, 48, 48, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7564), 48, 48, 48, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7564) }
                });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "ArenaId", "CreatedAt", "Name", "PlayerId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7387), "School 1", 1, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7387) },
                    { 2, 1, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7388), "School 2", 2, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7389) },
                    { 3, 2, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7390), "School 3", 3, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7390) },
                    { 4, 2, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7391), "School 4", 4, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7392) }
                });

            migrationBuilder.InsertData(
                table: "Gladiator",
                columns: new[] { "Id", "CreatedAt", "Experience", "Health", "Name", "PlayerId", "SchoolId", "StatUpdatesId", "StatsId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7300), 1, 1, "Gladiator 1", 1, 1, 2, 1, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7301) },
                    { 2, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7303), 2, 2, "Gladiator 2", 1, 1, 4, 3, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7304) },
                    { 3, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7305), 3, 3, "Gladiator 3", 1, 1, 6, 5, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7305) },
                    { 4, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7307), 4, 4, "Gladiator 4", 2, 2, 8, 7, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7307) },
                    { 5, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7309), 5, 5, "Gladiator 5", 2, 2, 10, 9, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7309) },
                    { 6, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7310), 6, 6, "Gladiator 6", 2, 2, 12, 11, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7311) },
                    { 7, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7312), 7, 7, "Gladiator 7", 3, 3, 14, 13, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7312) },
                    { 8, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7314), 8, 8, "Gladiator 8", 3, 3, 16, 15, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7314) },
                    { 9, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7315), 9, 9, "Gladiator 9", 3, 3, 18, 17, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7316) },
                    { 10, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7317), 10, 10, "Gladiator 10", 4, 4, 20, 19, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7317) },
                    { 11, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7319), 11, 11, "Gladiator 11", 4, 4, 22, 21, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7319) },
                    { 12, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7321), 12, 12, "Gladiator 12", 4, 4, 24, 23, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7322) }
                });

            migrationBuilder.InsertData(
                table: "Gear",
                columns: new[] { "Id", "Armor", "CreatedAt", "Damage", "Durability", "GladiatorId", "Name", "Slots", "StatModifiersPercentId", "StatModifiersPointsId", "UpdatedAt", "Weight" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7417), 1, 1, 1, "Gear 1", 1, 25, 26, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7417), 1 },
                    { 2, 2, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7419), 2, 2, 2, "Gear 2", 2, 27, 28, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7419), 2 },
                    { 3, 3, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7420), 3, 3, 3, "Gear 3", 3, 29, 30, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7421), 3 },
                    { 4, 4, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7422), 4, 4, 4, "Gear 4", 4, 31, 32, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7423), 4 },
                    { 5, 5, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7424), 5, 5, 5, "Gear 5", 5, 33, 34, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7425), 5 },
                    { 6, 6, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7426), 6, 6, 6, "Gear 6", 6, 35, 36, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7427), 6 },
                    { 7, 7, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7429), 7, 7, 7, "Gear 7", 7, 37, 38, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7429), 7 },
                    { 8, 8, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7430), 8, 8, 8, "Gear 8", 8, 39, 40, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7431), 8 },
                    { 9, 9, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7432), 9, 9, 9, "Gear 9", 9, 41, 42, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7433), 9 },
                    { 10, 10, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7434), 10, 10, 10, "Gear 10", 10, 43, 44, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7434), 10 },
                    { 11, 11, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7436), 11, 11, 11, "Gear 11", 11, 45, 46, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7436), 11 },
                    { 12, 12, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7437), 12, 12, 12, "Gear 12", 12, 47, 48, new DateTime(2022, 4, 20, 14, 4, 7, 562, DateTimeKind.Utc).AddTicks(7438), 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArenaPlayer_OwnersId",
                table: "ArenaPlayer",
                column: "OwnersId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleLog_GladiatorId",
                table: "BattleLog",
                column: "GladiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Gear_GladiatorId",
                table: "Gear",
                column: "GladiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Gear_StatModifiersPercentId",
                table: "Gear",
                column: "StatModifiersPercentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gear_StatModifiersPointsId",
                table: "Gear",
                column: "StatModifiersPointsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gladiator_PlayerId",
                table: "Gladiator",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Gladiator_SchoolId",
                table: "Gladiator",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Gladiator_StatsId",
                table: "Gladiator",
                column: "StatsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gladiator_StatUpdatesId",
                table: "Gladiator",
                column: "StatUpdatesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_ArenaId",
                table: "School",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_School_PlayerId",
                table: "School",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArenaPlayer");

            migrationBuilder.DropTable(
                name: "BattleLog");

            migrationBuilder.DropTable(
                name: "Gear");

            migrationBuilder.DropTable(
                name: "Gladiator");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Arena");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
