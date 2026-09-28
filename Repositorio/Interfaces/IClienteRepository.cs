using SistemaGestaoFinanceiraEmpresarial.Models;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        List<ClienteModel> ListarTodos();

        ClienteModel? BuscarPorId(int id);

        void Adicionar(ClienteModel cliente);

        void Atualizar(ClienteModel cliente);

        bool Excluir(ClienteModel cliente);

        bool DocumentoExiste(string documento, int? id = null);
    }
}