using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Seguranca;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros
{
    public class DepartamentoModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(255)]
        public string? Descricao { get; set; }

        public bool Ativo { get; set; } = true;

        public List<ApplicationUserModel> Usuarios { get; set; } = new();
    }
}