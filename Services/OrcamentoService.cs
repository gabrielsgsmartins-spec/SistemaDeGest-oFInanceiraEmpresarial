using SistemaGestaoFinanceiraEmpresarial.Repositories;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaGestaoFinanceiraEmpresarial.Enums;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;

namespace SistemaGestaoFinanceiraEmpresarial
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
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
                if (_clienteRepository.BuscarPorId(cliente.Id) != null)
                {
                    throw new InvalidOperationException($"Já existe um cliente com o ID {cliente.Id}.");
                }
                _clienteRepository.Adicionar(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadastrar o cliente.", ex);
            }
        }
        public void Atualizar(ClienteModel cliente)
        {
            try
            {
                if (cliente == null)
                {
                    throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo.");
                }
                if (cliente.Id <= 0)
                {
                    throw new ArgumentException("O ID do cliente deve ser maior que zero.", nameof(cliente.Id));
                }
                var clienteExistente = _clienteRepository.BuscarPorId(cliente.Id);
                if (clienteExistente == null)
                {
                    throw new KeyNotFoundException($"Cliente com ID {cliente.Id} não encontrado.");
                }
                _clienteRepository.Atualizar(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao atualizar o cliente com ID {cliente.Id}.", ex);
            }
        }
        public void Excluir(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID do cliente deve ser maior que zero.", nameof(id));
                }
                var clienteExistente = _clienteRepository.BuscarPorId(id);
                if (clienteExistente == null)
                {
                    throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");
                }
                _clienteRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao excluir o cliente com ID {id}.", ex);
            }
        }
    }
}