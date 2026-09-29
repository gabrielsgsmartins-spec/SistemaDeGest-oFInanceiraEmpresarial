using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Bancario;


namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface ITransferenciaRepository
    {
        List<TransferenciaModel> ListarTodos();
        TransferenciaModel? BuscarPorId(int id);
        void Adicionar(TransferenciaModel transferencia);
        void Atualizar(TransferenciaModel transferencia);
        void Excluir(int id);
    }
}