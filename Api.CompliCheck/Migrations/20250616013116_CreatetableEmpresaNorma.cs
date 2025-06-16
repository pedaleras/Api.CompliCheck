using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.CompliCheck.Migrations
{
    /// <inheritdoc />
    public partial class CreatetableEmpresaNorma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACC_Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "NVARCHAR2(18)", maxLength: 18, nullable: false),
                    Setor = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ACC_Normas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Categoria = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DataLimite = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EmpresaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_Normas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ACC_Normas_ACC_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "ACC_Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACC_Normas_EmpresaId",
                table: "ACC_Normas",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACC_Normas");

            migrationBuilder.DropTable(
                name: "ACC_Empresas");
        }
    }
}
