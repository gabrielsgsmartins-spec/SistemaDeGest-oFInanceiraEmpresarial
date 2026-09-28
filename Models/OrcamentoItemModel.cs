using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public class OrcamentoItemModel
    {
        public int Id { get; set; }

        public int OrcamentoId { get; set; }

        public OrcamentoModel? Orcamento { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal { get; set; }
    }
}