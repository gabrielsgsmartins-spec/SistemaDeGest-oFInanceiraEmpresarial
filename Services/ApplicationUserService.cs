using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaGestaoFinanceiraEmpresarial.Services.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _repository;

        public ApplicationUserService(IApplicationUserRepository repository)
        {
            _repository = repository;
        }

        public List<ApplicationUserModel> ListarTodos()
        {
            return _repository.ListarTodos();
        }

        public ApplicationUserModel? BuscarPorId(string id)
        {
            return _repository.BuscarPorId(id);
        }

        public void Atualizar(ApplicationUserModel usuario)
        {
            _repository.Atualizar(usuario);
        }
    }
}
