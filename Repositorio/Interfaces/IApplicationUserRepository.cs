using SistemaGestaoFinanceiraEmpresarial.Models;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUserModel> ListarTodos();
        ApplicationUserModel? BuscarPorId(string id);
        void Atualizar(ApplicationUserModel usuario);
    }
}