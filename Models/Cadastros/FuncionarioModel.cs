using SistemaDeGestãoFinanceiraEmpresarial.Models.Seguranca;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros
{
    public class FuncionarioModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required]
        [StringLength(14)]
        public string CPF { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Telefone { get; set; }

        [Required]
        [StringLength(100)]
        public string Cargo { get; set; } = string.Empty;

        public DateTime DataAdmissao { get; set; }

        public decimal Salario { get; set; }

        public bool Ativo { get; set; } = true;

        public int DepartamentoId { get; set; }

        public DepartamentoModel? Departamento { get; set; }

        public string? UsuarioId { get; set; }

        public ApplicationUserModel? Usuario { get; set; }
    }
}