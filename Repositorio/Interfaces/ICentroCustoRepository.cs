using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;


namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface ICentroCustoRepository
    {
        List<CentroCustoModel> ListarTodos();
        CentroCustoModel? BuscarPorId(int id);
        void Adicionar(CentroCustoModel centroCusto);
        void Editar(CentroCustoModel centroCusto);
        bool Excluir(int id);
        void Atualizar(CentroCustoModel centroCusto);

    }
}