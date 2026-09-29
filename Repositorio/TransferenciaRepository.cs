using Microsoft.EntityFrameworkCore;
using SistemaDeGestãoFinanceiraEmpresarial.Data;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Bancario;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly ApplicationDbContext _context;

        public TransferenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TransferenciaModel> ListarTodos()
        {
            return _context.Transferencias
                .AsNoTracking()
                .OrderBy(t => t.Data)
                .ToList();
        }

        public TransferenciaModel? BuscarPorId(int id)
        {
            if (id <= 0)
                return null;

            return _context.Transferencias
                .FirstOrDefault(t => t.Id == id);
        }

        public void Adicionar(TransferenciaModel transferencia)
        {
            ArgumentNullException.ThrowIfNull(transferencia);

            _context.Transferencias.Add(transferencia);
            _context.SaveChanges();
        }

        public void Atualizar(TransferenciaModel transferencia)
        {
            ArgumentNullException.ThrowIfNull(transferencia);

            if (transferencia.Id <= 0)
                throw new ArgumentException(
                    "O ID da transferência é inválido.",
                    nameof(transferencia));

            var transferenciaExistente = _context.Transferencias
                .FirstOrDefault(t => t.Id == transferencia.Id);

            if (transferenciaExistente == null)
                throw new KeyNotFoundException(
                    "Transferência não encontrada.");

            transferenciaExistente.Data = transferencia.Data;
            transferenciaExistente.Valor = transferencia.Valor;
            transferenciaExistente.ContaOrigemId = transferencia.ContaOrigemId;
            transferenciaExistente.ContaDestinoId = transferencia.ContaDestinoId;
            transferenciaExistente.Descricao = transferencia.Descricao;

            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O ID da transferência é inválido.", nameof(id));

            var transferenciaExistente = _context.Transferencias.FirstOrDefault(t => t.Id == id);

            if (transferenciaExistente == null)
                throw new KeyNotFoundException("Transferência não encontrada.");
            _context.Transferencias.Remove(transferenciaExistente);
            _context.SaveChanges();
        }

   
        public void Editar(TransferenciaModel transferencia)
        {
            ArgumentNullException.ThrowIfNull(transferencia);
            if (transferencia.Id <= 0)
                throw new ArgumentException(
                    "O ID da transferência é inválido.",nameof(transferencia));

            var transferenciaExistente = _context.Transferencias
                .FirstOrDefault(t => t.Id == transferencia.Id);
            if (transferenciaExistente == null)
                throw new KeyNotFoundException(
                    "Transferência não encontrada.");
            transferenciaExistente.Data = transferencia.Data;
            transferenciaExistente.Valor = transferencia.Valor;
            transferenciaExistente.ContaOrigemId = transferencia.ContaOrigemId;
            transferenciaExistente.ContaDestinoId = transferencia.ContaDestinoId;
            transferenciaExistente.Descricao = transferencia.Descricao;
            _context.SaveChanges();
        }
    }
}