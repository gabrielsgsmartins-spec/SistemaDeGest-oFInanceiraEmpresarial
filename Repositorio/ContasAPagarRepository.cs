using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoFinanceiraEmpresarial.Data;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories
{
    public class ContasAPagarRepository : IContasAPagarRepository
    {
        private readonly ApplicationDbContext _context;

        public ContasAPagarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ContaPagarModel> ListarTodos()
        {
            return _context.ContasPagar
                .ToList();
        }

        public ContaPagarModel? BuscarPorId(int id)
        {
            return _context.ContasPagar
                .FirstOrDefault(c => c.Id == id);
        }

        public void Adicionar(ContaPagarModel contaPagar)
        {
            _context.ContasPagar.Add(contaPagar);
            _context.SaveChanges();
        }

        public void Editar(ContaPagarModel contaPagar)
        {
            _context.ContasPagar.Update(contaPagar);
            _context.SaveChanges();
        }

        public bool Excluir(int id)
        {
            var contaPagar = _context.ContasPagar.Find(id);

            if (contaPagar == null)
            {
                return false;
            }

            _context.ContasPagar.Remove(contaPagar);
            _context.SaveChanges();

            return true;
        }

        public void Atualizar(ContaPagarModel contaPagar)
        {
            _context.ContasPagar.Update(contaPagar);
            _context.SaveChanges();
        }
    }
}