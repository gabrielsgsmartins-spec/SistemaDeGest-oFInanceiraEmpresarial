using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
using SistemaGestaoFinanceiraEmpresarial.Enums;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IContaReceberRepository _contaReceberRepository;
        private readonly IOrcamentoRepository _orcamentoRepository; 
        public ClienteService(IClienteRepository clienteRepository, IContaReceberRepository contaReceberRepository, IOrcamentoRepository orcamentoRepository)
        {
            _clienteRepository = clienteRepository;
            _contaReceberRepository = contaReceberRepository;
            _orcamentoRepository = orcamentoRepository;
        }

        public List<ClienteModel> ListarTodos()
        {
            try
            {
                return _clienteRepository.ListarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar os clientes.", ex);
            }
        }

        public ClienteModel? BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID do cliente deve ser maior que zero.", nameof(id));
                }
                return _clienteRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar o cliente com ID {id}.", ex);
            }
        }
        public void Cadastrar(ClienteModel cliente)
        {
            try
            {
            if (cliente == null)
            {
                throw new ArgumentNullException(
                    nameof(cliente),
                    "O cliente não pode ser nulo."
                );
            }

            if (string.IsNullOrWhiteSpace(cliente.Nome))
            {
                throw new ArgumentException(
                    "O nome do cliente é obrigatório.",
                    nameof(cliente.Nome)
                );
            }

            if (string.IsNullOrWhiteSpace(cliente.Documento))
            {
                throw new ArgumentException(
                    "O documento do cliente é obrigatório.",
                    nameof(cliente.Documento)
                );
            }

            if (cliente.Nome.Length > 100)
            {
                throw new ArgumentException(
                    "O nome do cliente não pode ter mais de 100 caracteres.",
                    nameof(cliente.Nome)
                );
            }

            var clienteExistente = _clienteRepository.BuscarPorId(cliente.Id);

            if (clienteExistente != null)
            {
                throw new ArgumentException(
                    "Já existe um cliente com o mesmo ID.",
                    nameof(cliente.Id)
                );
            }
            cliente.DataCadastro = DateTime.Now;
            cliente.Ativo = true;

            _clienteRepository.Adicionar(cliente);
        }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadastrar o cliente.", ex);
            }
        }

        public void Editar(ClienteModel cliente)
        {
            try
            {
                if (cliente == null)
                {
                    throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo.");
                }
                if (string.IsNullOrWhiteSpace(cliente.Nome))
                {
                    throw new ArgumentException("O nome do cliente não pode ser nulo ou vazio.", nameof(cliente.Nome));
                }
                if (cliente.Nome.Length > 100)
                {
                    throw new ArgumentException("O nome do cliente não pode ter mais de 100 caracteres.", nameof(cliente.Nome));
                }
                var ClienteDocumento = _clienteRepository.BuscarPorId(cliente.Id);

                if (ClienteDocumento != null)
                {
                    throw new ArgumentException("Já existe um cliente com o mesmo ID.", nameof(cliente.Id));
                }

                var existingCliente = _clienteRepository.BuscarPorId(cliente.Id);
                if (existingCliente == null)
                {
                    throw new KeyNotFoundException("Cliente não encontrado.");
                }
                _clienteRepository.Atualizar(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao editar o cliente.", ex);
            }
        }
        public bool Excluir(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID do cliente deve ser maior que zero.", nameof(id));
                }
                var existingCliente = _clienteRepository.BuscarPorId(id);
                if (existingCliente == null)
                {
                    throw new KeyNotFoundException("Cliente não encontrado.");
                }
                var possuiContasReceber = _contaReceberRepository.PossuiContasReceber(id);

                if (possuiContasReceber)
                {
                    throw new InvalidOperationException(
                        "Não é possível excluir o cliente porque existem contas a receber vinculadas a ele."
                    );
                }
                // Verificar se possui orçamentos
                var possuiOrcamentos = _orcamentoRepository.PossuiOrcamentos(id);

                if (possuiOrcamentos)
                {
                    throw new InvalidOperationException(
                        "Não é possível excluir o cliente porque existem orçamentos vinculados a ele."
                    );
                }
                return _clienteRepository.Excluir(existingCliente.Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao excluir o cliente com ID {id}.", ex);
            }
        }
    }
}
