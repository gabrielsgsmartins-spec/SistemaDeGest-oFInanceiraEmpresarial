using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public class OrcamentoModel
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public ClienteModel? Cliente { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime? DataValidade { get; set; }

        public decimal ValorTotal { get; set; }

        [Required]
        [StringLength(30)]
        public string Status { get; set; }

        [StringLength(500)]
        public string? Observacao { get; set; }

        public List<OrcamentoItemModel> Itens { get; set; } = new();
    }
}