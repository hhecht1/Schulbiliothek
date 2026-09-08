using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchulbibliothekAP14.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonenTyp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonenTyp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransaktionTyp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransaktionTyp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bild = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IstAktiv = table.Column<bool>(type: "bit", nullable: false),
                    PersonenTypId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_PersonenTyp_PersonenTypId",
                        column: x => x.PersonenTypId,
                        principalTable: "PersonenTyp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaktion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bemerkung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BuchId = table.Column<int>(type: "int", nullable: false),
                    TransaktionTypId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaktion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaktion_Buch_BuchId",
                        column: x => x.BuchId,
                        principalTable: "Buch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaktion_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaktion_TransaktionTyp_TransaktionTypId",
                        column: x => x.TransaktionTypId,
                        principalTable: "TransaktionTyp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonenTypId",
                table: "Person",
                column: "PersonenTypId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaktion_BuchId",
                table: "Transaktion",
                column: "BuchId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaktion_PersonId",
                table: "Transaktion",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaktion_TransaktionTypId",
                table: "Transaktion",
                column: "TransaktionTypId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaktion");

            migrationBuilder.DropTable(
                name: "Buch");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "TransaktionTyp");

            migrationBuilder.DropTable(
                name: "PersonenTyp");
        }
    }
}
