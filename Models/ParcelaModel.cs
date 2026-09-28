using SistemaDeGestãoFinanceiraEmpresarial;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public class ParcelaModel
    {
        public int Id { get; set; }

        public int NumeroParcela { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }

        [Required]
        [StringLength(30)]
        public string Status { get; set; }

        public int? ContaPagarId { get; set; }

        public ContaPagarModel? ContaPagar { get; set; }

        public int? ContaReceberId { get; set; }

        public ContaReceberModel? ContaReceber { get; set; }
    }
}