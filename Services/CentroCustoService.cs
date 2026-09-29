using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaGestaoFinanceiraEmpresarial.Enums;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;

namespace SistemaGestaoFinanceiraEmpresarial.Services
{
    public class CentroCustoService
    {
        private readonly ICentroCustoRepository _centroCustoRepository;
        public CentroCustoService(ICentroCustoRepository centroCustoRepository)
        {
            _centroCustoRepository = centroCustoRepository;
        }

        public List<CentroCustoModel> ListarTodos()
        {
            try
            {
                return _centroCustoRepository.ListarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar os centros de custo.", ex);
            }
        }
        public CentroCustoModel? BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID do centro de custo deve ser maior que zero.", nameof(id));
                }
                return _centroCustoRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar o centro de custo com ID {id}.", ex);
            }
        }
        public void Cadastrar(CentroCustoModel centroCusto)
        {
            try
            {
                if (centroCusto == null)
                {
                    throw new ArgumentNullException(nameof(centroCusto), "O centro de custo não pode ser nulo.");
                }
                if (string.IsNullOrWhiteSpace(centroCusto.Nome))
                {
                    throw new ArgumentException("O nome do centro de custo não pode ser nulo ou vazio.", nameof(centroCusto.Nome));
                }
                if (centroCusto.Nome.Length > 100)
                {
                    throw new ArgumentException("O nome do centro de custo não pode ter mais de 100 caracteres.", nameof(centroCusto.Nome));
                }
                _centroCustoRepository.Adicionar(centroCusto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadastrar o centro de custo.", ex);
            }
        }
        public void Atualizar(CentroCustoModel centroCusto)
        {
            try
            {
                if (centroCusto == null)
                {
                    throw new ArgumentNullException(nameof(centroCusto), "O centro de custo não pode ser nulo.");
                }
                if (string.IsNullOrWhiteSpace(centroCusto.Nome))
                {
                    throw new ArgumentException("O nome do centro de custo não pode ser nulo ou vazio.", nameof(centroCusto.Nome));
                }
                if (centroCusto.Nome.Length > 100)
                {
                    throw new ArgumentException("O nome do centro de custo não pode ter mais de 100 caracteres.", nameof(centroCusto.Nome));
                }
                _centroCustoRepository.Atualizar(centroCusto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar o centro de custo.", ex);
            }
        }
        public void Excluir(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID do centro de custo deve ser maior que zero.", nameof(id));
                }
                _centroCustoRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao excluir o centro de custo com ID {id}.", ex);
            }
        }
    }
}