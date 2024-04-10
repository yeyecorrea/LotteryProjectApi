using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotteryProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lotteries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lotteries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "chances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LotteryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chances_lotteries_LotteryId",
                        column: x => x.LotteryId,
                        principalTable: "lotteries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "raffles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberRaffle = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: false),
                    Prize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raffles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_raffles_chances_ChanceId",
                        column: x => x.ChanceId,
                        principalTable: "chances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chances_LotteryId",
                table: "chances",
                column: "LotteryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_raffles_ChanceId",
                table: "raffles",
                column: "ChanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "raffles");

            migrationBuilder.DropTable(
                name: "chances");

            migrationBuilder.DropTable(
                name: "lotteries");
        }
    }
}
