using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Bancario;


namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface IFuncionarioRepository
    {
        List<FuncionarioModel> ListarTodos();
        FuncionarioModel? BuscarPorId(int id);
        void Adicionar(FuncionarioModel funcionario);
        void Atualizar(FuncionarioModel funcionario);
        void Excluir(int id);
    }
}