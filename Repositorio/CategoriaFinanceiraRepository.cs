using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoFinanceiraEmpresarial.Data;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories
{
    public class CategoriaFinanceiraRepository : ICategoriaFinanceiraRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaFinanceiraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CategoriaFinanceiraModel> ListarTodos()
        {
            return _context.CategoriasFinanceiras
                .AsNoTracking()
                .OrderBy(c => c.Nome)
                .ToList();
        }

        public CategoriaFinanceiraModel? BuscarPorId(int id)
        {
            if (id <= 0)
                return null;

            return _context.CategoriasFinanceiras
                .FirstOrDefault(c => c.Id == id);
        }

        public void Adicionar(CategoriaFinanceiraModel categoria)
        {
            ArgumentNullException.ThrowIfNull(categoria);

            _context.CategoriasFinanceiras.Add(categoria);
            _context.SaveChanges();
        }

        public void Atualizar(CategoriaFinanceiraModel categoria)
        {
            ArgumentNullException.ThrowIfNull(categoria);

            if (categoria.Id <= 0)
                throw new ArgumentException(
                    "O ID da categoria é inválido.",
                    nameof(categoria));

            var categoriaExistente = _context.CategoriasFinanceiras
                .FirstOrDefault(c => c.Id == categoria.Id);

            if (categoriaExistente == null)
                throw new KeyNotFoundException(
                    "Categoria financeira não encontrada.");

            categoriaExistente.Nome = categoria.Nome;
            categoriaExistente.Descricao = categoria.Descricao;
            categoriaExistente.Ativa = categoria.Ativa;

            _context.SaveChanges();
        }

        public bool Excluir(CategoriaFinanceiraModel categoria)
        {
            ArgumentNullException.ThrowIfNull(categoria);

            if (categoria.Id <= 0)
                return false;

            var categoriaExistente = _context.CategoriasFinanceiras
                .FirstOrDefault(c => c.Id == categoria.Id);

            if (categoriaExistente == null)
                return false;

            _context.CategoriasFinanceiras.Remove(categoriaExistente);
            _context.SaveChanges();

            return true;
        }

        public bool NomeExiste(string nome, int? id = null)
        {
            return _context.CategoriasFinanceiras
                .Any(c =>
                    c.Nome == nome &&
                    (!id.HasValue || c.Id != id.Value));
        }
        public void Editar(CategoriaFinanceiraModel categoria)
        {
            ArgumentNullException.ThrowIfNull(categoria);
            if (categoria.Id <= 0)
                throw new ArgumentException(
                    "O ID da categoria é inválido.",
                    nameof(categoria));
            var categoriaExistente = _context.CategoriasFinanceiras
                .FirstOrDefault(c => c.Id == categoria.Id);
            if (categoriaExistente == null)
                throw new KeyNotFoundException(
                    "Categoria financeira não encontrada.");
            categoriaExistente.Nome = categoria.Nome;
            categoriaExistente.Descricao = categoria.Descricao;
            categoriaExistente.Ativa = categoria.Ativa;
            _context.SaveChanges();
        }
    }
}