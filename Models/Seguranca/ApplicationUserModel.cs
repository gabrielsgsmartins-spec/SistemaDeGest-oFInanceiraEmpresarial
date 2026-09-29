using Microsoft.AspNetCore.Identity;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;

namespace SistemaDeGestãoFinanceiraEmpresarial.Models.Seguranca
{
    public class ApplicationUserModel : IdentityUser
    {
        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public FuncionarioModel? Funcionario { get; set; }
    }
}