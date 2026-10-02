using Microsoft.EntityFrameworkCore;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Bancario;
using SistemaDeGestãoFinanceiraEmpresarial.Data;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories
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
            return _context.ContasBancarias.AsNoTracking().OrderBy(c => c.Id).ToList();
        }
        public ContaBancariaModel? BuscarPorId(int id)
        {
            if (id <= 0)
            {
                return null;

            }
            return _context.ContasBancarias.FirstOrDefault(c => c.Id == id);
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
                throw new ArgumentException(
                    "O ID da conta bancária é inválido.",
                    nameof(contaBancaria));
            var contaBancariaExistente = _context.ContasBancarias
                .FirstOrDefault(c => c.Id == contaBancaria.Id);
            if (contaBancariaExistente == null)
                throw new KeyNotFoundException(
                    "Conta bancária não encontrada.");
            contaBancariaExistente.Banco = contaBancaria.Banco;
            contaBancariaExistente.Agencia = contaBancaria.Agencia;
            contaBancariaExistente.NumeroConta = contaBancaria.NumeroConta;
            _context.SaveChanges();
        }
        public void Excluir(int id)
        {
            if (id <= 0)
                throw new ArgumentException(
                    "O ID da conta bancária é inválido.",
                    nameof(id));
            var contaBancariaExistente = _context.ContasBancarias
                .FirstOrDefault(c => c.Id == id);
            if (contaBancariaExistente == null)
                throw new KeyNotFoundException(
                    "Conta bancária não encontrada.");
            _context.ContasBancarias.Remove(contaBancariaExistente);
            _context.SaveChanges();
        }
        public bool PossuiContasReceber(int clienteId)
        {
            return _context.ContasReceber
                .Any(c => c.ClienteId == clienteId);
        }

    }
}