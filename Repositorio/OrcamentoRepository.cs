using Microsoft.EntityFrameworkCore;
using SistemaDeGestãoFinanceiraEmpresarial.Data;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Comercial;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public OrcamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<OrcamentoModel> ListarTodos()
        {
            return _context.Orcamentos.AsNoTracking().OrderBy(o => o.Id).ToList();
        }
        public OrcamentoModel? BuscarPorId(int id)
        {
            if (id <= 0)
                return null;
            return _context.Orcamentos
                .FirstOrDefault(o => o.Id == id);
        }

        public void Adicionar(OrcamentoModel orcamento)
        {
            ArgumentNullException.ThrowIfNull(orcamento);
            _context.Orcamentos.Add(orcamento);
            _context.SaveChanges();
        }
        public void Atualizar(OrcamentoModel orcamento)
        {
            ArgumentNullException.ThrowIfNull(orcamento);
            if (orcamento.Id <= 0)
                throw new ArgumentException(
                    "O ID do orçamento é inválido.",
                    nameof(orcamento));
            var orcamentoExistente = _context.Orcamentos
                .FirstOrDefault(o => o.Id == orcamento.Id);
            if (orcamentoExistente == null)
                throw new KeyNotFoundException("Orçamento não encontrado.");
            orcamentoExistente.DataValidade = orcamento.DataValidade;
            orcamentoExistente.ValorTotal = orcamento.ValorTotal;
            _context.SaveChanges();
        }
        public void Excluir(int id)
        {
            if (id <= 0)throw new ArgumentException("O ID do orçamento é inválido.",nameof(id));
            var orcamentoExistente = _context.Orcamentos.FirstOrDefault(o => o.Id == id);
            if (orcamentoExistente == null)throw new KeyNotFoundException("Orçamento não encontrado.");

            _context.Orcamentos.Remove(orcamentoExistente);
            _context.SaveChanges();
        }
    }
}