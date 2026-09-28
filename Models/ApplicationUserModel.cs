using Microsoft.AspNetCore.Identity;

namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public FuncionarioModel? Funcionario { get; set; }
    }
}