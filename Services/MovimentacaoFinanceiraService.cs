using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;
using SistemaGestaoFinanceiraEmpresarial.Enums;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Services
{
    public class MovimentacaoFinanceiraService
    {
        private readonly IMovimentacaoFinanceiraRepository _movimentacaoFinanceiraRepository;
        public MovimentacaoFinanceiraService(IMovimentacaoFinanceiraRepository movimentacaoFinanceiraRepository)
        {
            _movimentacaoFinanceiraRepository = movimentacaoFinanceiraRepository;
        }
        public List<MovimentacaoFinanceiraModel> ListarTodos()
        {
            try
            {
                return _movimentacaoFinanceiraRepository.ListarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar as movimentações financeiras.", ex);
            }
        }
        public MovimentacaoFinanceiraModel? BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID da movimentação financeira deve ser maior que zero.", nameof(id));
                }
                return _movimentacaoFinanceiraRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar a movimentação financeira com ID {id}.", ex);
            }
        }
        public void Cadastrar(MovimentacaoFinanceiraModel movimentacaoFinanceira)
        {
            try
            {
                if (movimentacaoFinanceira == null)
                {
                    throw new ArgumentNullException(nameof(movimentacaoFinanceira), "A movimentação financeira não pode ser nula.");
                }
                if (string.IsNullOrWhiteSpace(movimentacaoFinanceira.Descricao))
                {
                    throw new ArgumentException("A descrição da movimentação financeira não pode ser nula ou vazia.", nameof(movimentacaoFinanceira.Descricao));
                }
                if (movimentacaoFinanceira.Valor <= 0)
                {
                    throw new ArgumentException("O valor da movimentação financeira deve ser maior que zero.", nameof(movimentacaoFinanceira.Valor));
                }
                _movimentacaoFinanceiraRepository.Cadastrar(movimentacaoFinanceira);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadastrar a movimentação financeira.", ex);
            }
        }
        public void Atualizar(MovimentacaoFinanceiraModel movimentacaoFinanceira)
        {
            try
            {
                if (movimentacaoFinanceira == null)
                {
                    throw new ArgumentNullException(nameof(movimentacaoFinanceira), "A movimentação financeira não pode ser nula.");
                }
                if (string.IsNullOrWhiteSpace(movimentacaoFinanceira.Descricao))
                {
                    throw new ArgumentException("A descrição da movimentação financeira não pode ser nula ou vazia.", nameof(movimentacaoFinanceira.Descricao));
                }
                if (movimentacaoFinanceira.Valor <= 0)
                {
                    throw new ArgumentException("O valor da movimentação financeira deve ser maior que zero.", nameof(movimentacaoFinanceira.Valor));
                }
                var movimentacaoExistente = _movimentacaoFinanceiraRepository.BuscarPorId(movimentacaoFinanceira.Id);
                if (movimentacaoExistente == null)
                {
                    throw new InvalidOperationException($"Não existe uma movimentação financeira com o ID {movimentacaoFinanceira.Id}.");
                }
                _movimentacaoFinanceiraRepository.Atualizar(movimentacaoFinanceira);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar a movimentação financeira.", ex);
            }
        }

        public void Excluir(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID da movimentação financeira deve ser maior que zero.", nameof(id));
                }
                var movimentacaoExistente = _movimentacaoFinanceiraRepository.BuscarPorId(id);
                if (movimentacaoExistente == null)
                {
                    throw new InvalidOperationException($"Não existe uma movimentação financeira com o ID {id}.");
                }
                _movimentacaoFinanceiraRepository.Excluir(movimentacaoExistente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao excluir a movimentação financeira com ID {id}.", ex);
            }
        }
    }
}
