using Microsoft.EntityFrameworkCore;
using SistemaDeGestãoFinanceiraEmpresarial.Data;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<FuncionarioModel> ListarTodos()
        {
            return _context.Funcionarios.AsNoTracking().OrderBy(f => f.NomeCompleto).ToList();
        }
        public FuncionarioModel? BuscarPorId(int id)
        {
            if (id <= 0)
                return null;
            return _context.Funcionarios
                .FirstOrDefault(f => f.Id == id);
        }
        public void Adicionar(FuncionarioModel funcionario)
        {
            ArgumentNullException.ThrowIfNull(funcionario);
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }
        public void Atualizar(FuncionarioModel funcionario)
        {
            ArgumentNullException.ThrowIfNull(funcionario);
            if (funcionario.Id <= 0)
                throw new ArgumentException(
                    "O ID do funcionário é inválido.",
                    nameof(funcionario));
            var funcionarioExistente = _context.Funcionarios
                .FirstOrDefault(f => f.Id == funcionario.Id);
            if (funcionarioExistente == null)
                throw new KeyNotFoundException(
                    "Funcionário não encontrado.");
            funcionarioExistente.NomeCompleto = funcionario.NomeCompleto;
            funcionarioExistente.Cargo = funcionario.Cargo;
            funcionarioExistente.CPF = funcionario.CPF;
            funcionarioExistente.Telefone = funcionario.Telefone;
            _context.SaveChanges();
        }
        public void Excluir(int id)
        {
            if (id <= 0)
                throw new ArgumentException(
                    "O ID do funcionário é inválido.",
                    nameof(id));
            var funcionarioExistente = _context.Funcionarios
                .FirstOrDefault(f => f.Id == id);
            if (funcionarioExistente == null)
                throw new KeyNotFoundException(
                    "Funcionário não encontrado.");
            _context.Funcionarios.Remove(funcionarioExistente);
            _context.SaveChanges();
        }
       
    }
}
