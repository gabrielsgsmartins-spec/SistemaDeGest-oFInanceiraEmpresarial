using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestãoFinanceiraEmpresarial.Models
{
    public class ApplicationUser : IdentityUser
        {

        [Required(ErrorMessage = "Informe o nome do funcionário.")]
        [StringLength(100)]
        public string NomeCompleto { get; set; }
            public bool Ativo { get; set; }
            public DateTime DataCadastro { get; set; }

            public int? DepartamentoId { get; set; }
            public DepartamentoModel? Departamento { get; set; }
        }
    }
}
