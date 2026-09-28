using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeGestãoFinanceiraEmpresarial.Migrations
{
    /// <inheritdoc />
    public partial class AdicioneiamodeldeFuncionarioModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Departamentos_DepartamentoId",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "NomeCompleto",
                table: "ApplicationUsers");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "ApplicationUsers",
                newName: "DepartamentoModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsers_DepartamentoId",
                table: "ApplicationUsers",
                newName: "IX_ApplicationUsers_DepartamentoModelId");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "ApplicationUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "FuncionarioModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionarioModel_ApplicationUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FuncionarioModel_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioModel_DepartamentoId",
                table: "FuncionarioModel",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioModel_UsuarioId",
                table: "FuncionarioModel",
                column: "UsuarioId",
                unique: true,
                filter: "[UsuarioId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Departamentos_DepartamentoModelId",
                table: "ApplicationUsers",
                column: "DepartamentoModelId",
                principalTable: "Departamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Departamentos_DepartamentoModelId",
                table: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "FuncionarioModel");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "ApplicationUsers");

            migrationBuilder.RenameColumn(
                name: "DepartamentoModelId",
                table: "ApplicationUsers",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsers_DepartamentoModelId",
                table: "ApplicationUsers",
                newName: "IX_ApplicationUsers_DepartamentoId");

            migrationBuilder.AddColumn<string>(
                name: "NomeCompleto",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Departamentos_DepartamentoId",
                table: "ApplicationUsers",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id");
        }
    }
}
