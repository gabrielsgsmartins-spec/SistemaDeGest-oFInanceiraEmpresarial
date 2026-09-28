using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeGestãoFinanceiraEmpresarial.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasFinanceiras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ativa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasFinanceiras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentrosCusto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosCusto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContasBancarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Banco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Agencia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NumeroConta = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TipoConta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasBancarias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormasPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ativa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transferencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContaOrigemId = table.Column<int>(type: "int", nullable: false),
                    ContaDestinoId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orcamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacoesFinanceiras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContaBancariaId = table.Column<int>(type: "int", nullable: false),
                    CategoriaFinanceiraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacoesFinanceiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacoesFinanceiras_CategoriasFinanceiras_CategoriaFinanceiraId",
                        column: x => x.CategoriaFinanceiraId,
                        principalTable: "CategoriasFinanceiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimentacoesFinanceiras_ContasBancarias_ContaBancariaId",
                        column: x => x.ContaBancariaId,
                        principalTable: "ContasBancarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContasReceber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRecebimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    CategoriaFinanceiraId = table.Column<int>(type: "int", nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasReceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasReceber_CategoriasFinanceiras_CategoriaFinanceiraId",
                        column: x => x.CategoriaFinanceiraId,
                        principalTable: "CategoriasFinanceiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContasReceber_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContasReceber_FormasPagamento_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormasPagamento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContasPagar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FormaPagamento = table.Column<int>(type: "int", nullable: false),
                    CategoriaFinanceiraId = table.Column<int>(type: "int", nullable: true),
                    CentroCustoId = table.Column<int>(type: "int", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCriacaoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormaPagamentoModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasPagar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasPagar_CategoriasFinanceiras_CategoriaFinanceiraId",
                        column: x => x.CategoriaFinanceiraId,
                        principalTable: "CategoriasFinanceiras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContasPagar_CentrosCusto_CentroCustoId",
                        column: x => x.CentroCustoId,
                        principalTable: "CentrosCusto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContasPagar_FormasPagamento_FormaPagamentoModelId",
                        column: x => x.FormaPagamentoModelId,
                        principalTable: "FormasPagamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContasPagar_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrcamentoItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrcamentoId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrcamentoItens_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroParcela = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContaPagarId = table.Column<int>(type: "int", nullable: true),
                    ContaReceberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelas_ContasPagar_ContaPagarId",
                        column: x => x.ContaPagarId,
                        principalTable: "ContasPagar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parcelas_ContasReceber_ContaReceberId",
                        column: x => x.ContaReceberId,
                        principalTable: "ContasReceber",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_DepartamentoId",
                table: "ApplicationUsers",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasPagar_CategoriaFinanceiraId",
                table: "ContasPagar",
                column: "CategoriaFinanceiraId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasPagar_CentroCustoId",
                table: "ContasPagar",
                column: "CentroCustoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasPagar_FormaPagamentoModelId",
                table: "ContasPagar",
                column: "FormaPagamentoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasPagar_FornecedorId",
                table: "ContasPagar",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasReceber_CategoriaFinanceiraId",
                table: "ContasReceber",
                column: "CategoriaFinanceiraId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasReceber_ClienteId",
                table: "ContasReceber",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasReceber_FormaPagamentoId",
                table: "ContasReceber",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesFinanceiras_CategoriaFinanceiraId",
                table: "MovimentacoesFinanceiras",
                column: "CategoriaFinanceiraId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesFinanceiras_ContaBancariaId",
                table: "MovimentacoesFinanceiras",
                column: "ContaBancariaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoItens_OrcamentoId",
                table: "OrcamentoItens",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_ClienteId",
                table: "Orcamentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_ContaPagarId",
                table: "Parcelas",
                column: "ContaPagarId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_ContaReceberId",
                table: "Parcelas",
                column: "ContaReceberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "MovimentacoesFinanceiras");

            migrationBuilder.DropTable(
                name: "OrcamentoItens");

            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropTable(
                name: "Transferencias");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "ContasBancarias");

            migrationBuilder.DropTable(
                name: "Orcamentos");

            migrationBuilder.DropTable(
                name: "ContasPagar");

            migrationBuilder.DropTable(
                name: "ContasReceber");

            migrationBuilder.DropTable(
                name: "CentrosCusto");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "CategoriasFinanceiras");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "FormasPagamento");
        }
    }
}
