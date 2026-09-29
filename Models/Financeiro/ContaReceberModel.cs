using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro
{
    public class ContaReceberModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime? DataRecebimento { get; set; }

        [Required]
        [StringLength(30)]
        public string Status { get; set; }

        public int ClienteId { get; set; }

        public ClienteModel? Cliente { get; set; }

        public int CategoriaFinanceiraId { get; set; }

        public CategoriaFinanceiraModel? CategoriaFinanceira { get; set; }

        public int? FormaPagamentoId { get; set; }

        public FormaPagamentoModel? FormaPagamento { get; set; }

        public List<ParcelaModel> Parcelas { get; set; } = new();
    }
}