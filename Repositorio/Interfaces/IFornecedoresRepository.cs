using SistemaDeGestãoFinanceiraEmpresarial;
using SistemaDeGestãoFinanceiraEmpresarial.Models;

namespace SistemaGestaoFinanceiraEmpresarial.Models
{
    public interface IFornecedorRepository
    {
        List<FornecedorModel> ListarTodos();

        FornecedorModel? BuscarPorId(int id);

        void Adicionar(FornecedorModel fornecedor);

        void Atualizar(FornecedorModel fornecedor);

        bool Excluir(int id);

        bool ExisteCnpj(string cnpj, int? id = null);
    }
}
