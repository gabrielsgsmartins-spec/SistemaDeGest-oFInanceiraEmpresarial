using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro
{ 
    public class FormaPagamentoModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nome { get; set; }

        [StringLength(255)]
        public string? Descricao { get; set; }

        public bool Ativa { get; set; } = true;

        public List<ContaPagarModel> ContasPagar { get; set; } = new();

        public List<ContaReceberModel> ContasReceber { get; set; } = new();
    }
}