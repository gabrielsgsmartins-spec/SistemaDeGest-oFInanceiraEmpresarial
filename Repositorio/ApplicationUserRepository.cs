using Microsoft.EntityFrameworkCore;
using SistemaDeGestãoFinanceiraEmpresarial.Data;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Seguranca;
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
                .Include(u => u.Funcionario)
                    .ThenInclude(f => f.Departamento)
                .ToList();
        }

        public ApplicationUserModel? BuscarPorId(string id)
        {
            return _context.ApplicationUsers
                .Include(u => u.Funcionario)
                    .ThenInclude(f => f.Departamento)
                .FirstOrDefault(u => u.Id == id);
        }

        public void Atualizar(ApplicationUserModel usuario)
        {
            _context.ApplicationUsers.Update(usuario);
            _context.SaveChanges();
        }
    }
}