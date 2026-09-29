using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Bancario;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro
{
    public class MovimentacaoFinanceiraModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Valor { get; set; }

        [Required]
        [StringLength(20)]
        public string Tipo { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public int ContaBancariaId { get; set; }

        public ContaBancariaModel? ContaBancaria { get; set; }

        public int CategoriaFinanceiraId { get; set; }

        public CategoriaFinanceiraModel? CategoriaFinanceira { get; set; }
    }
}