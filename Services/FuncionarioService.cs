using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaGestaoFinanceiraEmpresarial.Enums;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;

namespace SistemaGestaoFinanceiraEmpresarial.Services
{
    public class FuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
        public List<FuncionarioModel> ListarTodos()
        {
            try
            {
                return _funcionarioRepository.ListarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar os funcionários.", ex);
            }
        }
        public FuncionarioModel? BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID do funcionário deve ser maior que zero.", nameof(id));
                }
                return _funcionarioRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar o funcionário com ID {id}.", ex);
            }
        }
        public void Cadastrar(FuncionarioModel funcionario)
        {
            try
            {
                if (funcionario == null)
                {
                    throw new ArgumentNullException(nameof(funcionario), "O funcionário não pode ser nulo.");
                }
                if (string.IsNullOrWhiteSpace(funcionario.NomeCompleto))
                {
                    throw new ArgumentException("O nome completo do funcionário não pode ser nulo ou vazio.", nameof(funcionario.NomeCompleto));
                }
                if (funcionario.NomeCompleto.Length > 150)
                {
                    throw new ArgumentException("O nome completo do funcionário não pode ter mais de 150 caracteres.", nameof(funcionario.NomeCompleto));
                }
                if (_funcionarioRepository.BuscarPorId(funcionario.Id) != null)
                {
                    throw new InvalidOperationException($"Já existe um funcionário com o ID {funcionario.Id}.");
                }
                _funcionarioRepository.Adicionar(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadastrar o funcionário.", ex);
            }
        }
        public void Atualizar(FuncionarioModel funcionario)
        {
            try
            {
                if (funcionario == null)
                {
                    throw new ArgumentNullException(nameof(funcionario), "O funcionário não pode ser nulo.");
                }
                if (string.IsNullOrWhiteSpace(funcionario.NomeCompleto))
                {
                    throw new ArgumentException("O nome completo do funcionário não pode ser nulo ou vazio.", nameof(funcionario.NomeCompleto));
                }
                if (funcionario.NomeCompleto.Length > 150)
                {
                    throw new ArgumentException("O nome completo do funcionário não pode ter mais de 150 caracteres.", nameof(funcionario.NomeCompleto));
                }
                var funcionarioExistente = _funcionarioRepository.BuscarPorId(funcionario.Id);
                if (funcionarioExistente == null)
                {
                    throw new InvalidOperationException($"Não existe um funcionário com o ID {funcionario.Id}.");
                }
                _funcionarioRepository.Atualizar(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar o funcionário.", ex);
            }
        }
        public void Excluir(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID do funcionário deve ser maior que zero.", nameof(id));
                }
                var funcionarioExistente = _funcionarioRepository.BuscarPorId(id);
                if (funcionarioExistente == null)
                {
                    throw new InvalidOperationException($"Não existe um funcionário com o ID {id}.");
                }
                _funcionarioRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao excluir o funcionário com ID {id}.", ex);
            }
        }
    }
}