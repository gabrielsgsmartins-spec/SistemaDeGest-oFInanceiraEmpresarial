using Microsoft.EntityFrameworkCore;
using SistemaDeGestãoFinanceiraEmpresarial.Data;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories
{
    public class MovimentacaoFinanceiraRepository : IMovimentacaoFinanceiraRepository
    {
        private readonly ApplicationDbContext _context;

        public MovimentacaoFinanceiraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MovimentacaoFinanceiraModel> ListarTodos()
        {
            return _context.MovimentacoesFinanceiras.AsNoTracking().OrderBy(o => o.Id).ToList();
        }

        public MovimentacaoFinanceiraModel? BuscarPorId(int id)
        {
            if (id <= 0) return null;
            return _context.MovimentacoesFinanceiras.FirstOrDefault(o => o.Id == id);
        }
        public void Cadastrar(MovimentacaoFinanceiraModel movimentacao)
        {
            ArgumentNullException.ThrowIfNull(movimentacao);
            _context.MovimentacoesFinanceiras.Add(movimentacao);
            _context.SaveChanges();
        }
        public void Editar(MovimentacaoFinanceiraModel movimentacao)
        {
            ArgumentNullException.ThrowIfNull(movimentacao);
            if (movimentacao.Id <= 0)
                throw new ArgumentException("O ID da movimentação financeira é inválido.", nameof(movimentacao));
            var movimentacaoExistente = _context.MovimentacoesFinanceiras.FirstOrDefault(o => o.Id == movimentacao.Id);
            if (movimentacaoExistente == null)
                throw new KeyNotFoundException("Movimentação financeira não encontrada.");
            movimentacaoExistente.Data = movimentacao.Data;
            movimentacaoExistente.Valor = movimentacao.Valor;
            movimentacaoExistente.Tipo = movimentacao.Tipo;
            movimentacaoExistente.Descricao = movimentacao.Descricao;
            _context.SaveChanges();
        }
        public bool Excluir(MovimentacaoFinanceiraModel movimentacao)
        {
            ArgumentNullException.ThrowIfNull(movimentacao);
            if (movimentacao.Id <= 0)
                throw new ArgumentException("O ID da movimentação financeira é inválido.", nameof(movimentacao));
            var movimentacaoExistente = _context.MovimentacoesFinanceiras.FirstOrDefault(o => o.Id == movimentacao.Id);
            if (movimentacaoExistente == null)
                throw new KeyNotFoundException("Movimentação financeira não encontrada.");
            _context.MovimentacoesFinanceiras.Remove(movimentacaoExistente);
            _context.SaveChanges();
            return true;
        }

        public void Atualizar(MovimentacaoFinanceiraModel movimentacao)
        {
            ArgumentNullException.ThrowIfNull(movimentacao);
            if (movimentacao.Id <= 0)
                throw new ArgumentException("O ID da movimentação financeira é inválido.", nameof(movimentacao));
            var movimentacaoExistente = _context.MovimentacoesFinanceiras.FirstOrDefault(o => o.Id == movimentacao.Id);
            if (movimentacaoExistente == null)
                throw new KeyNotFoundException("Movimentação financeira não encontrada.");
            movimentacaoExistente.Data = movimentacao.Data;
            movimentacaoExistente.Valor = movimentacao.Valor;
            movimentacaoExistente.Tipo = movimentacao.Tipo;
            movimentacaoExistente.Descricao = movimentacao.Descricao;
            _context.SaveChanges();
        }

    }
}