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
        public void Cadastrar(CategoriaFinanceiraModel categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(
                    nameof(categoria),
                    "A categoria financeira não pode ser nula.");
            }

            if (string.IsNullOrWhiteSpace(categoria.Nome))
            {
                throw new ArgumentException(
                    "O nome da categoria é obrigatório.",
                    nameof(categoria.Nome));
            }

            categoria.Nome = categoria.Nome.Trim();

            if (categoria.Nome.Length > 100)
            {
                throw new ArgumentException(
                    "O nome da categoria não pode ter mais de 100 caracteres.",
                    nameof(categoria.Nome));
            }

            if (!Enum.IsDefined(typeof(TipoCategoriaEnum),categoria.Tipo))
            {
                throw new ArgumentException("O tipo da categoria é inválido.",nameof(categoria.Tipo));
            }
            var categoriaExistente = _categoriaFinanceiraRepository.BuscarPorNome(categoria.Nome);

            if (categoriaExistente != null)
            {
                throw new InvalidOperationException("Já existe uma categoria financeira com esse nome.");
            }

            categoria.Ativa = true;

            _categoriaFinanceiraRepository.Adicionar(categoria);
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
                if(string.IsNullOrWhiteSpace(categoriaFinanceira.Nome))
                {
                    throw new ArgumentException("O nome da categoria é obrigatório.", nameof(categoriaFinanceira.Nome));
                }

                _categoriaFinanceiraRepository.Editar(categoriaFinanceira);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao editar a categoria financeira.", ex);
            }
        }
        public void Excluir(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID da categoria deve ser maior que zero.",nameof(id));
            }

            var categoria = _categoriaFinanceiraRepository.BuscarPorId(id);

            if (categoria == null)
            {
                throw new KeyNotFoundException("Categoria financeira não encontrada.");
            }

            bool possuiMovimentacoes =_categoriaFinanceiraRepository.PossuiMovimentacoes(id);

            bool possuiContasAPagar =_categoriaFinanceiraRepository.PossuiContasAPagar(id);

            bool possuiContasAReceber =_categoriaFinanceiraRepository.PossuiContasAReceber(id);

            if (possuiMovimentacoes ||possuiContasAPagar ||possuiContasAReceber)
            {
                categoria.Ativa = false;

                _categoriaFinanceiraRepository.Atualizar(categoria);

                return;
            }

            _categoriaFinanceiraRepository.Excluir(id);
        }
    }
}
