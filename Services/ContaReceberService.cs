using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
using SistemaGestaoFinanceiraEmpresarial.Enums;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;

namespace SistemaGestaoFinanceiraEmpresarial
{
    public class ContasAReceberService
    {
        private readonly IContaReceberRepository _contasAReceberRepository;
        public ContasAReceberService(IContaReceberRepository contasAReceberRepository)
        {
            _contasAReceberRepository = contasAReceberRepository;
        }

        public List<ContaReceberModel> ListarTodos()
        {
            try
            {
                return _contasAReceberRepository.ListarTodos();

            }
            catch (Exception ex)
            {
                //Erro ao listar as Contas a Receber
                throw new Exception("Ocorreu um erro ao listar os departamentos.", ex);
            }
        }
        public ContaReceberModel? BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException(
                        "O ID da conta a receber deve ser maior que zero.",
                        nameof(id));
                }

                return _contasAReceberRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Ocorreu um erro ao buscar a conta a receber com ID {id}.",
                    ex);
            }
        }
    }
}
