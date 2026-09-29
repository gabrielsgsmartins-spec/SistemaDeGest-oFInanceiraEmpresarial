using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;


namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface ICategoriaFinanceiraRepository
    {
        List<CategoriaFinanceiraModel> ListarTodos();
        CategoriaFinanceiraModel? BuscarPorId(int id);
        void Adicionar(CategoriaFinanceiraModel categoria);
        void Editar(CategoriaFinanceiraModel categoria);
        void Excluir(int id);
        void Atualizar(CategoriaFinanceiraModel categoria);
    }
}