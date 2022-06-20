using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW.Migrations
{
    public partial class AddedOtherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PCId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pret = table.Column<int>(type: "int", nullable: false),
                    Detalii = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componente_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Configuratie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Procesor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAM = table.Column<int>(type: "int", nullable: false),
                    Stocare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuratie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pret = table.Column<int>(type: "int", nullable: false),
                    Id_Client = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAdress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tara = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cod_Postal = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdress_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Are",
                columns: table => new
                {
                    Id_PC = table.Column<int>(type: "int", nullable: false),
                    Id_Configuratie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Are", x => new { x.Id_PC, x.Id_Configuratie });
                    table.ForeignKey(
                        name: "FK_Are_Configuratie_Id_Configuratie",
                        column: x => x.Id_Configuratie,
                        principalTable: "Configuratie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Are_PC_Id_PC",
                        column: x => x.Id_PC,
                        principalTable: "PC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PCId",
                table: "AspNetUsers",
                column: "PCId");

            migrationBuilder.CreateIndex(
                name: "IX_Are_Id_Configuratie",
                table: "Are",
                column: "Id_Configuratie");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_UserId",
                table: "Componente",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAdress_UserId",
                table: "UserAdress",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PC_PCId",
                table: "AspNetUsers",
                column: "PCId",
                principalTable: "PC",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PC_PCId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Are");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "UserAdress");

            migrationBuilder.DropTable(
                name: "Configuratie");

            migrationBuilder.DropTable(
                name: "PC");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PCId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PCId",
                table: "AspNetUsers");
        }
    }
}
