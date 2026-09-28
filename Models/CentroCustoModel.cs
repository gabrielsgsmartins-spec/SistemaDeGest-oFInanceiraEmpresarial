using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public class CentroCustoModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(255)]
        public string? Descricao { get; set; }

        public bool Ativo { get; set; } = true;
    }
}