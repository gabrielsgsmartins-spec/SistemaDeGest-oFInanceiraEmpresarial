using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        List<ClienteModel> ListarTodos();

        ClienteModel? BuscarPorId(int id);

        void Adicionar(ClienteModel cliente);

        void Atualizar(ClienteModel cliente);

        bool Excluir(int id);

        bool DocumentoExiste(string documento, int? id = null);
    }
}