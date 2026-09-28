using SistemaGestaoFinanceiraEmpresarial.Models;

namespace SistemaGestaoFinanceiraEmpresarial.Services.Interfaces
{
    public interface IApplicationUserService
    {
        List<ApplicationUserModel> ListarTodos();
        ApplicationUserModel? BuscarPorId(string id);
        void Atualizar(ApplicationUserModel usuario);
    }
}
