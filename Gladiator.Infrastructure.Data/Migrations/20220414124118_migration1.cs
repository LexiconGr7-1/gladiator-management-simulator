using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gladiator.Infrastructure.Data.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arenas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arenas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArenaPlayer",
                columns: table => new
                {
                    ArenasId = table.Column<long>(type: "bigint", nullable: false),
                    PlayersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaPlayer", x => new { x.ArenasId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_ArenaPlayer_Arenas_ArenasId",
                        column: x => x.ArenasId,
                        principalTable: "Arenas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArenaPlayer_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    PlayerId1 = table.Column<long>(type: "bigint", nullable: false),
                    ArenaId = table.Column<int>(type: "int", nullable: true),
                    ArenaId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_Arenas_ArenaId1",
                        column: x => x.ArenaId1,
                        principalTable: "Arenas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schools_Players_PlayerId1",
                        column: x => x.PlayerId1,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gladiator",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    OnFightRoster = table.Column<bool>(type: "bit", nullable: false),
                    ArenaId = table.Column<int>(type: "int", nullable: true),
                    ArenaId1 = table.Column<long>(type: "bigint", nullable: true),
                    SchoolId = table.Column<int>(type: "int", nullable: true),
                    SchoolId1 = table.Column<long>(type: "bigint", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    PlayerId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gladiator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gladiator_Arenas_ArenaId1",
                        column: x => x.ArenaId1,
                        principalTable: "Arenas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gladiator_Players_PlayerId1",
                        column: x => x.PlayerId1,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gladiator_Schools_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "Schools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArenaPlayer_PlayersId",
                table: "ArenaPlayer",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_Gladiator_ArenaId1",
                table: "Gladiator",
                column: "ArenaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Gladiator_PlayerId1",
                table: "Gladiator",
                column: "PlayerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Gladiator_SchoolId1",
                table: "Gladiator",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_ArenaId1",
                table: "Schools",
                column: "ArenaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_PlayerId1",
                table: "Schools",
                column: "PlayerId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArenaPlayer");

            migrationBuilder.DropTable(
                name: "Gladiator");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Arenas");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
