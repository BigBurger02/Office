using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Office.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deanery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeaneryName = table.Column<string>(type: "TEXT", nullable: true),
                    Dean = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deanery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cathedra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CathedraName = table.Column<string>(type: "TEXT", nullable: true),
                    DeaneryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cathedra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cathedra_Deanery_DeaneryId",
                        column: x => x.DeaneryId,
                        principalTable: "Deanery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Audience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(type: "TEXT", nullable: true),
                    TeacherName = table.Column<string>(type: "TEXT", nullable: true),
                    BuildingId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeaneryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CathedraId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audience_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audience_Cathedra_CathedraId",
                        column: x => x.CathedraId,
                        principalTable: "Cathedra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audience_Deanery_DeaneryId",
                        column: x => x.DeaneryId,
                        principalTable: "Deanery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audience_BuildingId",
                table: "Audience",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Audience_CathedraId",
                table: "Audience",
                column: "CathedraId");

            migrationBuilder.CreateIndex(
                name: "IX_Audience_DeaneryId",
                table: "Audience",
                column: "DeaneryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cathedra_DeaneryId",
                table: "Cathedra",
                column: "DeaneryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audience");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Cathedra");

            migrationBuilder.DropTable(
                name: "Deanery");
        }
    }
}
