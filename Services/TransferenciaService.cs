using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaGestaoFinanceiraEmpresarial.Enums;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Bancario;

namespace SistemaGestaoFinanceiraEmpresarial.Services
{
    public class TransferenciaService
    {
        private readonly ITransferenciaRepository _transferenciaRepository;
        public TransferenciaService(ITransferenciaRepository transferenciaRepository)
        {
            _transferenciaRepository = transferenciaRepository;
        }
        public List<TransferenciaModel> ListarTodos()
        {
            try
            {
                return _transferenciaRepository.ListarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar as transferências.", ex);
            }
        }
        public TransferenciaModel? BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID da transferência deve ser maior que zero.", nameof(id));
                }
                return _transferenciaRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar a transferência com ID {id}.", ex);
            }
        }
        public void Cadastrar(TransferenciaModel transferencia)
        {
            try
            {
                if (transferencia == null)
                {
                    throw new ArgumentNullException(nameof(transferencia), "A transferência não pode ser nula.");
                }
                if (transferencia.Valor <= 0)
                {
                    throw new ArgumentException("O valor da transferência deve ser maior que zero.", nameof(transferencia.Valor));
                }
                _transferenciaRepository.Adicionar(transferencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadastrar a transferência.", ex);
            }
        }
        public void Atualizar(TransferenciaModel transferencia)
        {
            try
            {
                if (transferencia == null)
                {
                    throw new ArgumentNullException(nameof(transferencia), "A transferência não pode ser nula.");
                }
                if (transferencia.Id <= 0)
                {
                    throw new ArgumentException("O ID da transferência deve ser maior que zero.", nameof(transferencia.Id));
                }
                _transferenciaRepository.Atualizar(transferencia);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao atualizar a transferência com ID {transferencia.Id}.", ex);
            }
        }
        public void Excluir(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID da transferência deve ser maior que zero.", nameof(id));
                }
                _transferenciaRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao excluir a transferência com ID {id}.", ex);
            }
        }
    }
}