using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Masanori.com.App.Data.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresaViewComponent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaViewComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompraViewComponent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmpresaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraViewComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraViewComponent_EmpresaViewComponent_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "EmpresaViewComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoViewComponent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmpresaId = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoViewComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoViewComponent_EmpresaViewComponent_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "EmpresaViewComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraViewComponent_EmpresaId",
                table: "CompraViewComponent",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoViewComponent_EmpresaId",
                table: "EnderecoViewComponent",
                column: "EmpresaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraViewComponent");

            migrationBuilder.DropTable(
                name: "EnderecoViewComponent");

            migrationBuilder.DropTable(
                name: "EmpresaViewComponent");
        }
    }
}
