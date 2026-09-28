using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public class TransferenciaModel
    {
        public int Id { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Valor { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public int ContaOrigemId { get; set; }

        public int ContaDestinoId { get; set; }

        [StringLength(255)]
        public string? Descricao { get; set; }
    }
}