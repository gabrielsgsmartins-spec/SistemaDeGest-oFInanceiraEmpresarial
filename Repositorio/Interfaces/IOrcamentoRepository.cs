using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Comercial;


namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface IOrcamentoRepository
    {
        List<OrcamentoModel> ListarTodos();
        OrcamentoModel? BuscarPorId(int id);
        void Adicionar(OrcamentoModel orcamento);
        void Atualizar(OrcamentoModel orcamento);
        void Excluir(int id);

    }
}