using Microsoft.EntityFrameworkCore;
using SistemaDeGestãoFinanceiraEmpresarial.Data;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ClienteModel> ListarTodos()
        {
            return _context.Clientes
                .AsNoTracking()
                .OrderBy(c => c.Nome)
                .ToList();
        }

        public ClienteModel? BuscarPorId(int id)
        {
            if (id <= 0)
                return null;

            return _context.Clientes
                .FirstOrDefault(c => c.Id == id);
        }

        public void Adicionar(ClienteModel cliente)
        {
            ArgumentNullException.ThrowIfNull(cliente);

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Atualizar(ClienteModel cliente)
        {
            ArgumentNullException.ThrowIfNull(cliente);

            if (cliente.Id <= 0)
                throw new ArgumentException(
                    "O ID do cliente é inválido.",
                    nameof(cliente));

            var clienteExistente = _context.Clientes
                .FirstOrDefault(c => c.Id == cliente.Id);

            if (clienteExistente == null)
                throw new KeyNotFoundException(
                    "Cliente não encontrado.");

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Documento = cliente.Documento;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Telefone = cliente.Telefone;
            clienteExistente.Endereco = cliente.Endereco;
            clienteExistente.Ativo = cliente.Ativo;

            _context.SaveChanges();
        }

        public bool Excluir(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O ID do cliente é inválido.", nameof(id));
            var clienteExistente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (clienteExistente == null)
                throw new KeyNotFoundException("Cliente não encontrado.");
            _context.Clientes.Remove(clienteExistente);
            _context.SaveChanges();
            return true;
        }

        public bool DocumentoExiste(string documento, int? id = null)
        {
            return _context.Clientes
                .Any(c =>
                    c.Documento == documento &&
                    (!id.HasValue || c.Id != id.Value));
        }
    }
}