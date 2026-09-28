using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoFinanceiraEmpresarial.Data;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<DepartamentoModel> ListarTodos()
        {
            return _context.Departamentos
                .AsNoTracking()
                .OrderBy(d => d.Nome)
                .ToList();
        }

        public DepartamentoModel? BuscarPorId(int id)
        {
            if (id <= 0)
                return null;

            return _context.Departamentos
                .FirstOrDefault(d => d.Id == id);
        }

        public void Adicionar(DepartamentoModel departamento)
        {
            ArgumentNullException.ThrowIfNull(departamento);

            _context.Departamentos.Add(departamento);
            _context.SaveChanges();
        }

        public void Editar(DepartamentoModel departamento)
        {
            ArgumentNullException.ThrowIfNull(departamento);

            if (departamento.Id <= 0)
                throw new ArgumentException(
                    "O ID do departamento é inválido.",
                    nameof(departamento));

            var departamentoExistente = _context.Departamentos
                .FirstOrDefault(d => d.Id == departamento.Id);

            if (departamentoExistente == null)
                throw new KeyNotFoundException(
                    "Departamento não encontrado.");

            departamentoExistente.Nome = departamento.Nome;
            departamentoExistente.Descricao = departamento.Descricao;
            departamentoExistente.Ativo = departamento.Ativo;

            _context.SaveChanges();
        }

        public bool Excluir(DepartamentoModel departamento)
        {
            ArgumentNullException.ThrowIfNull(departamento);

            if (departamento.Id <= 0)
                return false;

            var departamentoExistente = _context.Departamentos
                .FirstOrDefault(d => d.Id == departamento.Id);

            if (departamentoExistente == null)
                return false;

            _context.Departamentos.Remove(departamentoExistente);
            _context.SaveChanges();

            return true;
        }

        public void Atualizar(DepartamentoModel departamento)
        {
            ArgumentNullException.ThrowIfNull(departamento);

            if (departamento.Id <= 0)
                throw new ArgumentException(
                    "O ID do departamento é inválido.",
                    nameof(departamento));

            var departamentoExistente = _context.Departamentos
                .FirstOrDefault(d => d.Id == departamento.Id);

            if (departamentoExistente == null)
                throw new KeyNotFoundException(
                    "Departamento não encontrado.");

            departamentoExistente.Nome = departamento.Nome;
            departamentoExistente.Descricao = departamento.Descricao;
            departamentoExistente.Ativo = departamento.Ativo;

            _context.SaveChanges();
        }
    }
}