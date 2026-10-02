using Microsoft.EntityFrameworkCore;
using SistemaDeGestãoFinanceiraEmpresarial.Data;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
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

        public void Cadastrar(DepartamentoModel departamento)
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

        public bool Excluir(int id)
        {
            if (id <= 0)
                return false;

            var departamentoExistente = _context.Departamentos
                .FirstOrDefault(d => d.Id == id);

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
        public DepartamentoModel BuscarPorNome(string nome)
        {
            return _context.Departamentos
                .FirstOrDefault(d => d.Nome == nome);
        }
    }
}