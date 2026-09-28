using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;


namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface ICategoriaFinanceiraRepository
    {
        List<CategoriaFinanceiraModel> ListarTodos();
        CategoriaFinanceiraModel? BuscarPorId(int id);
        void Adicionar(CategoriaFinanceiraModel categoria);
        void Editar(CategoriaFinanceiraModel categoria);
        bool Excluir(CategoriaFinanceiraModel categoria);
        void Atualizar(CategoriaFinanceiraModel categoria);
    }
}