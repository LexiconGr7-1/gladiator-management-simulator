using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gladiator.Infrastructure.Data.Migrations
{
    public partial class gladiatorid : Migration
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
                    ArenasId = table.Column<int>(type: "int", nullable: false),
                    OwnersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaPlayer", x => new { x.ArenasId, x.OwnersId });
                    table.ForeignKey(
                        name: "FK_ArenaPlayer_Arena_ArenasId",
                        column: x => x.ArenasId,
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
                    ArenaId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Gladiator_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[] { 1, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1304), "Arena 1", new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1304) });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(863), "Player 1", new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(868) });

            migrationBuilder.InsertData(
                table: "Stats",
                columns: new[] { "Id", "Agility", "Constitution", "CreatedAt", "Dexterity", "Intelligence", "Strength", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1384), 1, 1, 1, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1385) },
                    { 2, 2, 2, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1446), 2, 2, 2, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1446) },
                    { 3, 3, 3, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1448), 3, 3, 3, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1448) },
                    { 4, 4, 4, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1450), 4, 4, 4, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1450) }
                });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "ArenaId", "CreatedAt", "Name", "PlayerId", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1333), "Arena 1", 1, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1333) });

            migrationBuilder.InsertData(
                table: "Gladiator",
                columns: new[] { "Id", "ArenaId", "CreatedAt", "Experience", "Health", "Name", "PlayerId", "SchoolId", "StatUpdatesId", "StatsId", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1272), 0, 1, "Gladiator 1", 1, 1, 2, 1, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1273) });

            migrationBuilder.InsertData(
                table: "Gear",
                columns: new[] { "Id", "Armor", "CreatedAt", "Damage", "Durability", "GladiatorId", "Name", "Slots", "StatModifiersPercentId", "StatModifiersPointsId", "UpdatedAt", "Weight" },
                values: new object[] { 1, 1, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1360), 1, 1, 1, "Gear 1", 1, 3, 4, new DateTime(2022, 4, 20, 2, 19, 41, 50, DateTimeKind.Utc).AddTicks(1361), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ArenaPlayer_OwnersId",
                table: "ArenaPlayer",
                column: "OwnersId");

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
                name: "IX_Gladiator_ArenaId",
                table: "Gladiator",
                column: "ArenaId");

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
