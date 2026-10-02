using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;


namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface IDepartamentoRepository
    {
        List<DepartamentoModel> ListarTodos();
        DepartamentoModel? BuscarPorId(int id);
        void Cadastrar(DepartamentoModel departamento);
        void Editar(DepartamentoModel departamento);
        bool Excluir(int id);
        void Atualizar(DepartamentoModel departamento);
        DepartamentoModel? BuscarPorNome(string nome);
    }
}