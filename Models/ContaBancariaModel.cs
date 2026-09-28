using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public class ContaBancariaModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Banco { get; set; }

        [StringLength(20)]
        public string? Agencia { get; set; }

        [StringLength(30)]
        public string? NumeroConta { get; set; }

        [StringLength(20)]
        public string? TipoConta { get; set; }

        public decimal Saldo { get; set; }

        public bool Ativa { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public List<MovimentacaoFinanceiraModel> Movimentacoes { get; set; } = new();
    }
}