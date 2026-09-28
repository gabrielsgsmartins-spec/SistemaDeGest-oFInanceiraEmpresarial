using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        public string NomeCompleto { get; set; }

        public int? DepartamentoId { get; set; }

        public DepartamentoModel? Departamento { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}