using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaGestaoFinanceiraEmpresarial.Enums;

namespace SistemaGestaoFinanceiraEmpresarial.Services
{
    public class ContasAPagarService
    {
        private readonly IContasAPagarRepository _contasAPagarRepository;
        public ContasAPagarService(IContasAPagarRepository contasAPagarRepository)
        {
            _contasAPagarRepository = contasAPagarRepository;
        }
        public List<ContaPagarModel> ListarTodos()
        {
            return _contasAPagarRepository.ListarTodos();
        }
        public ContaPagarModel? BuscarPorId(int id)
        {
            return _contasAPagarRepository.BuscarPorId(id);
        }


        public void Cadastrar(ContaPagarModel contaPagar)
        {
            var existingConta = _contasAPagarRepository.BuscarPorId(contaPagar.Id);
            // Implementar a lógica de cadastro, como validações e regras de negócio
            if (contaPagar == null)
            {
                throw new ArgumentNullException(nameof(contaPagar), "A conta a pagar não pode ser nula.");
            }
            if (string.IsNullOrWhiteSpace(contaPagar.Descricao))
            {
                throw new ArgumentException("A descrição da conta a pagar é obrigatória.", nameof(contaPagar.Descricao));
            }
            if (contaPagar.Valor <= 0)
            {
                throw new ArgumentException("O valor da conta a pagar deve ser maior que zero.", nameof(contaPagar.Valor));
            }
            if (contaPagar.DataVencimento < contaPagar.DataEmissao)
            {
                throw new ArgumentException("A data de vencimento não pode ser anterior à data de emissão.", nameof(contaPagar.DataVencimento));
            }
            if (contaPagar.FornecedorId <= 0)
            {
                throw new ArgumentException("O ID do fornecedor deve ser maior que zero.", nameof(contaPagar.FornecedorId));
            }
            //Cadastarando ContasAPagar
            contaPagar.DataCadastro = DateTime.Now;
            _contasAPagarRepository.Adicionar(contaPagar);

        }

        public void Editar(ContaPagarModel contaPagar)
        {
            var existingConta = _contasAPagarRepository.BuscarPorId(contaPagar.Id);
            if (existingConta == null)
            {
                throw new ArgumentException("A conta a pagar não existe.", nameof(contaPagar.Id));
            }
            _contasAPagarRepository.Editar(contaPagar);
        }

        public bool Excluir(int id)
        {
            var existingConta = _contasAPagarRepository.BuscarPorId(id);
            if (existingConta == null)
            {
                throw new ArgumentException("A conta a pagar não existe.", nameof(id));
            }
            return _contasAPagarRepository.Excluir(id);
        }

        public List<ContaPagarModel> ListarContasPorFornecedor(int fornecedorId)
        {
            var contas = _contasAPagarRepository.ListarTodos();
            return contas.Where(c => c.FornecedorId == fornecedorId).ToList();
        }

        public List<ContaPagarModel> ListarContasPorStatus(StatusContaEnum status)
        {
            var contas = _contasAPagarRepository.ListarTodos();

            return contas.Where(c => c.Status == status).ToList();
        }

        public List<ContaPagarModel> ListarContasPorCategoria(int categoriaId)
        {
            var contas = _contasAPagarRepository.ListarTodos();
            return contas.Where(c => c.CategoriaFinanceiraId == categoriaId).ToList();
        }
        public List<ContaPagarModel> ListarStatusVencida(int centroCustoId)
        {
            var contas = _contasAPagarRepository.ListarTodos();
            return contas.Where(c => c.Status == StatusContaEnum.Vencida && c.CentroCustoId == centroCustoId).ToList();
        }
        public List<ContaPagarModel> ListarContasPorDataVencimento(DateTime dataVencimento)
        {
            var contas = _contasAPagarRepository.ListarTodos();
            return contas.Where(c => c.DataVencimento.Date == dataVencimento.Date).ToList();
        }

        public void AtualizarStatusContas()
        {
            var contas = _contasAPagarRepository.ListarTodos();
            foreach (var conta in contas)
            {
                if (conta.Status == StatusContaEnum.Pendente && conta.DataVencimento < DateTime.Now)
                {
                    conta.Status = StatusContaEnum.Vencida;
                    _contasAPagarRepository.Editar(conta);
                }
            }
        }
        public void RegistrarPagamento(int id)
        {
            var conta = _contasAPagarRepository.BuscarPorId(id);

            if (conta == null)
                throw new Exception("Conta a pagar não encontrada.");

            if (conta.Status == StatusContaEnum.Paga)
                throw new Exception("Esta conta já foi paga.");

            conta.Status = StatusContaEnum.Paga;
            conta.DataPagamento = DateTime.Now;

            _contasAPagarRepository.Atualizar(conta);
        }

    }
}
