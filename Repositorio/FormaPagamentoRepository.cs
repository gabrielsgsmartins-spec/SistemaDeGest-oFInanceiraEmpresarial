using Microsoft.EntityFrameworkCore;
using SistemaDeGestãoFinanceiraEmpresarial.Data;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories
{
    public class FormaPagamentoRepository : IFormaPagamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public FormaPagamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<FormaPagamentoModel> ListarTodos()
        {
            return _context.FormasPagamento
                .ToList();
        }
        public FormaPagamentoModel? BuscarPorId(int id)
        {
            return _context.FormasPagamento
                .FirstOrDefault(c => c.Id == id);
        }
        public void Adicionar(FormaPagamentoModel formaPagamento)
        {
            _context.FormasPagamento.Add(formaPagamento);
            _context.SaveChanges();
        }
        public void Editar(FormaPagamentoModel formaPagamento)
        {
            _context.FormasPagamento.Update(formaPagamento);
            _context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var formaPagamento = _context.FormasPagamento.Find(id);
            if (formaPagamento == null)
            {
                throw new KeyNotFoundException("Forma de pagamento não encontrada.");
            }
            _context.FormasPagamento.Remove(formaPagamento);
            _context.SaveChanges();
        }
        public void Atualizar(FormaPagamentoModel formaPagamento)
        {
            _context.FormasPagamento.Update(formaPagamento);
            _context.SaveChanges();
        }
        public bool NomeExiste(string nome, int? id = null)
        {
            return _context.FormasPagamento
                .Any(f => f.Nome == nome &&
                          (!id.HasValue || f.Id != id.Value));
        }

    }
}
