using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;


namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface IMovimentacaoFinanceiraRepository
    {
        List<MovimentacaoFinanceiraModel> ListarTodos();
        MovimentacaoFinanceiraModel? BuscarPorId(int id);
        void Cadastrar(MovimentacaoFinanceiraModel movimentacao);
        void Editar(MovimentacaoFinanceiraModel movimentacao);
        bool Excluir(MovimentacaoFinanceiraModel movimentacao);
        void Atualizar(MovimentacaoFinanceiraModel movimentacao);
    }
}