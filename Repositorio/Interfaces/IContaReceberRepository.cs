using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Bancario;


namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface IContaReceberRepository
    {
        List<ContaReceberModel> ListarTodos();
        ContaReceberModel? BuscarPorId(int id);
        void Adicionar(ContaReceberModel contaReceber);
        void Atualizar(ContaReceberModel contaReceber);
        void Excluir(int id);

        bool PossuiContasReceber(int clienteId);
    }
}