using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoFinanceiraEmpresarial.Data;
using SistemaGestaoFinanceiraEmpresarial.Data;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ApplicationUserModel> ListarTodos()
        {
            return _context.ApplicationUsers
                .Include(u => u.Departamento)
                .ToList();
            
        }

        public ApplicationUserModel? BuscarPorId(string id)
        {
            return _context.ApplicationUsers
                .Include(u => u.Departamento)
                .FirstOrDefault(u => u.Id == id);
        }

        public void Atualizar(ApplicationUserModel usuario)
        {
            _context.ApplicationUsers.Update(usuario);
            _context.SaveChanges();
        }
    }
}