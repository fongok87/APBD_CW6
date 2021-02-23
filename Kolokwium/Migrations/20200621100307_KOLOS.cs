using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.Migrations
{
    public partial class KOLOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    IdAction = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    NeedSpecialEquipment = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "Firefighter",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firefighter", x => x.IdFirefighter);
                });

            migrationBuilder.CreateTable(
                name: "FireTruck",
                columns: table => new
                {
                    IdFireTruck = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationalNumber = table.Column<string>(maxLength: 10, nullable: false),
                    SpecialEquipment = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireTruck", x => x.IdFireTruck);
                });

            migrationBuilder.CreateTable(
                name: "Firefighter_Action",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(nullable: false),
                    IdAction = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firefighter_Action", x => new { x.IdFirefighter, x.IdAction });
                    table.ForeignKey(
                        name: "FK_Firefighter_Action_Action_IdAction",
                        column: x => x.IdAction,
                        principalTable: "Action",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Firefighter_Action_Firefighter_IdFirefighter",
                        column: x => x.IdFirefighter,
                        principalTable: "Firefighter",
                        principalColumn: "IdFirefighter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireTruck_Action",
                columns: table => new
                {
                    IdFireTruck_Action = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFireTruck = table.Column<int>(nullable: false),
                    IdAction = table.Column<int>(nullable: false),
                    AssigmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireTruck_Action", x => x.IdFireTruck_Action);
                    table.ForeignKey(
                        name: "FK_FireTruck_Action_Action_IdAction",
                        column: x => x.IdAction,
                        principalTable: "Action",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FireTruck_Action_FireTruck_IdFireTruck",
                        column: x => x.IdFireTruck,
                        principalTable: "FireTruck",
                        principalColumn: "IdFireTruck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Action",
                columns: new[] { "IdAction", "EndTime", "NeedSpecialEquipment", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Local), (byte)1, new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), (byte)2, new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), (byte)3, new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "FireTruck",
                columns: new[] { "IdFireTruck", "OperationalNumber", "SpecialEquipment" },
                values: new object[,]
                {
                    { 1, "Pozarowy", (byte)3 },
                    { 2, "Latajacy", (byte)2 },
                    { 3, "Wodny", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Firefighter",
                columns: new[] { "IdFirefighter", "Firstname", "LastName" },
                values: new object[,]
                {
                    { 1, "Rafał", "Smoczynski" },
                    { 2, "Kasia", "Smoczynska" },
                    { 3, "Maria", "Ligowska" }
                });

            migrationBuilder.InsertData(
                table: "FireTruck_Action",
                columns: new[] { "IdFireTruck_Action", "AssigmentDate", "IdAction", "IdFireTruck" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), 3, 1 },
                    { 2, new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Local), 2, 2 },
                    { 1, new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Firefighter_Action",
                columns: new[] { "IdFirefighter", "IdAction" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 2 },
                    { 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firefighter_Action_IdAction",
                table: "Firefighter_Action",
                column: "IdAction");

            migrationBuilder.CreateIndex(
                name: "IX_FireTruck_Action_IdAction",
                table: "FireTruck_Action",
                column: "IdAction");

            migrationBuilder.CreateIndex(
                name: "IX_FireTruck_Action_IdFireTruck",
                table: "FireTruck_Action",
                column: "IdFireTruck");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firefighter_Action");

            migrationBuilder.DropTable(
                name: "FireTruck_Action");

            migrationBuilder.DropTable(
                name: "Firefighter");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "FireTruck");
        }
    }
}
