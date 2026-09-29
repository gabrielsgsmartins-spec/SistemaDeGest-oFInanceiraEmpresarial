using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Bancario;


namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface IFormaPagamentoRepository
    {
        List<FormaPagamentoModel> ListarTodos();
        FormaPagamentoModel? BuscarPorId(int id);
        void Adicionar(FormaPagamentoModel formaPagamento);
        void Atualizar(FormaPagamentoModel formaPagamento);
        void Excluir(int id);
        public bool NomeExiste(string nome, int? id = null);
    }
}