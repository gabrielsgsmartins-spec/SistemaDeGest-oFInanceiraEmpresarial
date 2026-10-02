using Microsoft.EntityFrameworkCore;
using SistemaDeGestãoFinanceiraEmpresarial.Data;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;
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

        public IEnumerable<CentroCustoModel> ListarTodos()
        {
            return _context.CentrosCusto
                .AsNoTracking()
                .OrderBy(c => c.Nome)
                .ToList();
        }

        public CentroCustoModel? BuscarPorId(int id)
        {
            return _context.CentrosCusto
                .FirstOrDefault(c => c.Id == id);
        }

        public CentroCustoModel? BuscarPorNome(string nome)
        {
            return _context.CentrosCusto
                .FirstOrDefault(c => c.Nome == nome);
        }

        public void Adicionar(CentroCustoModel centroCusto)
        {
            _context.CentrosCusto.Add(centroCusto);
            _context.SaveChanges();
        }

        public void Atualizar(CentroCustoModel centroCusto)
        {
            _context.CentrosCusto.Update(centroCusto);
            _context.SaveChanges();
        }

        public bool Excluir(int id)
        {
            var centroCusto = _context.CentrosCusto
                .FirstOrDefault(c => c.Id == id);

            if (centroCusto == null)
                return false;

            _context.CentrosCusto.Remove(centroCusto);
            _context.SaveChanges();

            return true;
        }

        public bool PossuiContasAPagar(int centroCustoId)
        {
            return _context.ContasPagar
                .Any(c => c.CentroCustoId == centroCustoId);
        }
    }
}