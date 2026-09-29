using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestaoFinanceiraEmpresarial.Enums;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestãoFinanceiraEmpresarial.Models.Comercial
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
        public StatusOrcamentoEnum Status { get; set; } = StatusOrcamentoEnum.Pendente;

        [StringLength(200)]
        public string? Observacao { get; set; }

        public List<OrcamentoItemModel> Itens { get; set; } = new();
    }
}