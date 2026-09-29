using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Comercial;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string? Nome { get; set; }

        [StringLength(18)]
        public string? Documento { get; set; }

        [EmailAddress]
        [StringLength(150)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Telefone { get; set; }

        [StringLength(250)]
        public string? Endereco { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public bool Ativo { get; set; } = true;

        public List<ContaReceberModel> ContasReceber { get; set; } = new();

        public List<OrcamentoModel> Orcamentos { get; set; } = new();
    }
}