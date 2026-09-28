using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;


namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface IContasAPagarRepository
    {                               
        List<ContaPagarModel> ListarTodos();
        ContaPagarModel? BuscarPorId(int id);
        void Adicionar(ContaPagarModel contaPagar);
        void Editar(ContaPagarModel contaPagar);
        bool Excluir(int id);
        void Atualizar(ContaPagarModel contaPagar);
    }
}