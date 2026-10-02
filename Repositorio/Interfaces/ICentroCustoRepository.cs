using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces
{
    public interface ICentroCustoRepository
    {
        IEnumerable<CentroCustoModel> ListarTodos();

        CentroCustoModel? BuscarPorId(int id);

        CentroCustoModel? BuscarPorNome(string nome);

        void Adicionar(CentroCustoModel centroCusto);

        void Atualizar(CentroCustoModel centroCusto);

        bool Excluir(int id);

        bool PossuiContasAPagar(int centroCustoId);
    }
}