using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaGestaoFinanceiraEmpresarial.Enums;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;

namespace SistemaGestaoFinanceiraEmpresarial.Services
{
    public class CategoriaFinanceiraService
    {
        private readonly ICategoriaFinanceiraRepository _categoriaFinanceiraRepository;
        public CategoriaFinanceiraService(ICategoriaFinanceiraRepository categoriaFinanceiraRepository)
        {
            _categoriaFinanceiraRepository = categoriaFinanceiraRepository;
        }

        public List<CategoriaFinanceiraModel> ListarTodos()
        {
            try
            {
                return _categoriaFinanceiraRepository.ListarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar as categorias financeiras.", ex);
            }
        }

        public CategoriaFinanceiraModel? BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID da categoria financeira deve ser maior que zero.", nameof(id));
                }
                return _categoriaFinanceiraRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar a categoria financeira com ID {id}.", ex);
            }
        }
        public void Cadastrar(CategoriaFinanceiraModel categoriaFinanceira)
        {
            try
            {
                if (categoriaFinanceira == null)
                {
                    throw new ArgumentNullException(nameof(categoriaFinanceira), "A categoria financeira não pode ser nula.");
                }
                if (string.IsNullOrWhiteSpace(categoriaFinanceira.Nome))
                {
                    throw new ArgumentException("O nome da categoria financeira não pode ser nulo ou vazio.", nameof(categoriaFinanceira.Nome));
                }
                if (categoriaFinanceira.Nome.Length > 100)
                {
                    throw new ArgumentException("O nome da categoria financeira não pode ter mais de 100 caracteres.", nameof(categoriaFinanceira.Nome));
                }
                if (_categoriaFinanceiraRepository.BuscarPorId(categoriaFinanceira.Id) != null)
                {
                    throw new ArgumentException("A categoria financeira já existe.", nameof(categoriaFinanceira.Id));
                }
                _categoriaFinanceiraRepository.Adicionar(categoriaFinanceira);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadastrar a categoria financeira.", ex);
            }
        }
        public void Editar(CategoriaFinanceiraModel categoriaFinanceira)
        {
            try
            {
                var existingCategoria = _categoriaFinanceiraRepository.BuscarPorId(categoriaFinanceira.Id);
                if (existingCategoria == null)
                {
                    throw new ArgumentException("A categoria financeira não existe.", nameof(categoriaFinanceira.Id));
                }
                _categoriaFinanceiraRepository.Editar(categoriaFinanceira);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao editar a categoria financeira.", ex);
            }
        }
        public bool Excluir(int id)
        {
            try
            {
                var existingCategoria = _categoriaFinanceiraRepository.BuscarPorId(id);
                if (existingCategoria == null)
                {
                    throw new ArgumentException("A categoria financeira não existe.", nameof(id));
                }
                _categoriaFinanceiraRepository.Excluir(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao excluir a categoria financeira com ID {id}.", ex);
            }
        }
    }
}
