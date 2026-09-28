using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoFinanceiraEmpresarial.Data;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationDbContext _context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<FornecedorModel> ListarTodos()
        {
            return _context.Fornecedores
                .AsNoTracking()
                .ToList();
        }

        public FornecedorModel? BuscarPorId(int id)
        {
            return _context.Fornecedores
                .FirstOrDefault(f => f.Id == id);
        }

        public void Adicionar(FornecedorModel fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();
        }

        public void Atualizar(FornecedorModel fornecedor)
        {
            _context.Fornecedores.Update(fornecedor);
            _context.SaveChanges();
        }

        public bool Excluir(int id)
        {
            var fornecedor = _context.Fornecedores
                .FirstOrDefault(f => f.Id == id);

            if (fornecedor == null)
                return false;

            _context.Fornecedores.Remove(fornecedor);
            _context.SaveChanges();

            return true;
        }

        public bool ExisteCnpj(string cnpj, int? id = null)
        {
            return _context.Fornecedores
                .Any(f => f.CNPJ == cnpj && (!id.HasValue || f.Id != id.Value));
        }
    }
}