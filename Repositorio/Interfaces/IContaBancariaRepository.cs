using SistemaDeGestãoFinanceiraEmpresarial.Models.Bancario;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces
{
    public interface IContaBancariaRepository
    {
        List<ContaBancariaModel> ListarTodos();

        ContaBancariaModel? BuscarPorId(int id);

        void Adicionar(ContaBancariaModel contaBancaria);

        void Atualizar(ContaBancariaModel contaBancaria);

        void Excluir(int id);
    }
}