using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onkruid.Core.Data.Migrations
{
    public partial class addmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Familie",
                columns: table => new
                {
                    Familie_Naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familie", x => x.Familie_Naam);
                });

            migrationBuilder.CreateTable(
                name: "Gebruik",
                columns: table => new
                {
                    Gebruik_Nr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gebruik_Beschrijving = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruik", x => x.Gebruik_Nr);
                });

            migrationBuilder.CreateTable(
                name: "Onkruid_Naam",
                columns: table => new
                {
                    Familie_Naam = table.Column<string>(nullable: false),
                    Gebruik_Nr = table.Column<string>(nullable: false),
                    WetenschappelijkeNaam = table.Column<string>(name: "Wetenschappelijke Naam", nullable: true),
                    NederlandseNaam = table.Column<string>(name: "Nederlandse Naam", nullable: true),
                    Gebruik_Nr1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onkruid_Naam", x => new { x.Familie_Naam, x.Gebruik_Nr });
                    table.ForeignKey(
                        name: "FK_Onkruid_Naam_Familie_Familie_Naam",
                        column: x => x.Familie_Naam,
                        principalTable: "Familie",
                        principalColumn: "Familie_Naam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Onkruid_Naam_Gebruik_Gebruik_Nr1",
                        column: x => x.Gebruik_Nr1,
                        principalTable: "Gebruik",
                        principalColumn: "Gebruik_Nr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Onkruid_Naam_Gebruik_Nr1",
                table: "Onkruid_Naam",
                column: "Gebruik_Nr1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Onkruid_Naam");

            migrationBuilder.DropTable(
                name: "Familie");

            migrationBuilder.DropTable(
                name: "Gebruik");
        }
    }
}
