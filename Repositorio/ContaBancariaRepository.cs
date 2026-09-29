using Microsoft.EntityFrameworkCore;
using SistemaDeGestãoFinanceiraEmpresarial.Data;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Bancario;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial
{
    public class ContaBancariaRepository : IContaBancariaRepository
    {
        private readonly ApplicationDbContext _context;

        public ContaBancariaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ContaBancariaModel> ListarTodos()
        {
            return _context.ContasBancarias
                .AsNoTracking()
                .OrderBy(c => c.Banco)
                .ToList();
        }

        public ContaBancariaModel? BuscarPorId(int id)
        {
            if (id <= 0)
                return null;

            return _context.ContasBancarias
                .FirstOrDefault(c => c.Id == id);
        }

        public void Adicionar(ContaBancariaModel contaBancaria)
        {
            ArgumentNullException.ThrowIfNull(contaBancaria);

            _context.ContasBancarias.Add(contaBancaria);
            _context.SaveChanges();
        }

        public void Atualizar(ContaBancariaModel contaBancaria)
        {
            ArgumentNullException.ThrowIfNull(contaBancaria);

            if (contaBancaria.Id <= 0)
            {
                throw new ArgumentException(
                    "O ID da conta bancária é inválido.",
                    nameof(contaBancaria));
            }

            var contaBancariaExistente = _context.ContasBancarias
                .FirstOrDefault(c => c.Id == contaBancaria.Id);

            if (contaBancariaExistente == null)
            {
                throw new KeyNotFoundException(
                    "Conta bancária não encontrada.");
            }

            contaBancariaExistente.Banco = contaBancaria.Banco;
            contaBancariaExistente.Agencia = contaBancaria.Agencia;
            contaBancariaExistente.NumeroConta = contaBancaria.NumeroConta;
            contaBancariaExistente.TipoConta = contaBancaria.TipoConta;
            contaBancariaExistente.Ativa = contaBancaria.Ativa;

            _context.SaveChanges();
        }

        public void AtualizarSaldo(int id, decimal valor)
        {
            if (id <= 0)
            {
                throw new ArgumentException(
                    "O ID da conta bancária é inválido.",
                    nameof(id));
            }

            var contaBancaria = _context.ContasBancarias
                .FirstOrDefault(c => c.Id == id);

            if (contaBancaria == null)
            {
                throw new KeyNotFoundException(
                    "Conta bancária não encontrada.");
            }

            contaBancaria.Saldo += valor;

            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(
                    "O ID da conta bancária é inválido.",
                    nameof(id));
            }

            var contaBancaria = _context.ContasBancarias
                .FirstOrDefault(c => c.Id == id);

            if (contaBancaria == null)
            {
                throw new KeyNotFoundException(
                    "Conta bancária não encontrada.");
            }

            _context.ContasBancarias.Remove(contaBancaria);

            _context.SaveChanges();
        }
    }
}