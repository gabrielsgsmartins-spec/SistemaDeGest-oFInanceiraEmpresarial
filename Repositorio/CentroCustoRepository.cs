using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoFinanceiraEmpresarial.Data;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories
{
    public class CentroCustoRepository : ICentroCustoRepository
    {
        private readonly ApplicationDbContext _context;

        public CentroCustoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CentroCustoModel> ListarTodos()
        {
            return _context.CentrosCusto
                .ToList();
        }

        public CentroCustoModel? BuscarPorId(int id)
        {
            return _context.CentrosCusto
                .FirstOrDefault(c => c.Id == id);
        }

        public void Adicionar(CentroCustoModel centroCusto)
        {
            _context.CentrosCusto.Add(centroCusto);
            _context.SaveChanges();
        }

        public void Editar(CentroCustoModel centroCusto)
        {
            _context.CentrosCusto.Update(centroCusto);
            _context.SaveChanges();
        }

        public bool Excluir(int id)
        {
            var centroCusto = _context.CentrosCusto.Find(id);

            if (centroCusto == null)
            {
                return false;
            }

            _context.CentrosCusto.Remove(centroCusto);
            _context.SaveChanges();

            return true;
        }

        public void Atualizar(CentroCustoModel centroCusto)
        {
            _context.CentrosCusto.Update(centroCusto);
            _context.SaveChanges();
        }
    }
}