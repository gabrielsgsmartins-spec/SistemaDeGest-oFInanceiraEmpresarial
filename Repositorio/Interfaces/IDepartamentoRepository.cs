using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;


namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface IDepartamentoRepository
    {
        List<DepartamentoModel> ListarTodos();
        DepartamentoModel? BuscarPorId(int id);
        void Adicionar(DepartamentoModel departamento);
        void Editar(DepartamentoModel departamento);
        bool Excluir(DepartamentoModel departamento);
        void Atualizar(DepartamentoModel departamento);
    }
}