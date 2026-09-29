using Microsoft.EntityFrameworkCore;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Bancario;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Comercial;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Seguranca;

namespace SistemaDeGestãoFinanceiraEmpresarial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUserModel> ApplicationUsers { get; set; }

        public DbSet<CategoriaFinanceiraModel> CategoriasFinanceiras { get; set; }

        public DbSet<CentroCustoModel> CentrosCusto { get; set; }

        public DbSet<ClienteModel> Clientes { get; set; }

        public DbSet<ContaBancariaModel> ContasBancarias { get; set; }

        public DbSet<ContaPagarModel> ContasPagar { get; set; }

        public DbSet<ContaReceberModel> ContasReceber { get; set; }

        public DbSet<DepartamentoModel> Departamentos { get; set; }

        public DbSet<FormaPagamentoModel> FormasPagamento { get; set; }

        public DbSet<FornecedorModel> Fornecedores { get; set; }

        public DbSet<MovimentacaoFinanceiraModel> MovimentacoesFinanceiras { get; set; }

        public DbSet<OrcamentoItemModel> OrcamentoItens { get; set; }

        public DbSet<OrcamentoModel> Orcamentos { get; set; }

        public DbSet<ParcelaModel> Parcelas { get; set; }

        public DbSet<TransferenciaModel> Transferencias { get; set; }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}