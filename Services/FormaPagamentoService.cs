using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;

namespace SistemaGestaoFinanceiraEmpresarial.Services
{
    public class FormaPagamentoService
    {
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;

        public FormaPagamentoService(
            IFormaPagamentoRepository formaPagamentoRepository)
        {
            _formaPagamentoRepository = formaPagamentoRepository;
        }

        public List<FormaPagamentoModel> ListarTodos()
        {
            return _formaPagamentoRepository.ListarTodos();
        }

        public FormaPagamentoModel? BuscarPorId(int id)
        {
            if (id <= 0)
                return null;

            return _formaPagamentoRepository.BuscarPorId(id);
        }

        public void Adicionar(FormaPagamentoModel formaPagamento)
        {
            if (formaPagamento == null)
                throw new ArgumentNullException(nameof(formaPagamento));

            if (string.IsNullOrWhiteSpace(formaPagamento.Nome))
                throw new ArgumentException(
                    "O nome da forma de pagamento é obrigatório.");

            formaPagamento.Nome = formaPagamento.Nome.Trim();

            if (formaPagamento.Nome.Length > 100)
                throw new ArgumentException(
                    "O nome da forma de pagamento não pode ter mais de 100 caracteres.");

            if (_formaPagamentoRepository.NomeExiste(formaPagamento.Nome, formaPagamento.Id))
            {
                throw new ArgumentException(
                    "Essa forma de pagamento já está cadastrada.");
            }
            formaPagamento.Ativa = true;

            _formaPagamentoRepository.Adicionar(formaPagamento);
        }

        public void Atualizar(FormaPagamentoModel formaPagamento)
        {
            if (formaPagamento == null)
                throw new ArgumentNullException(nameof(formaPagamento));

            if (formaPagamento.Id <= 0)
                throw new ArgumentException(
                    "O ID da forma de pagamento é inválido.");

            var existente = _formaPagamentoRepository
                .BuscarPorId(formaPagamento.Id);

            if (existente == null)
                throw new KeyNotFoundException(
                    "Forma de pagamento não encontrada.");

            if (string.IsNullOrWhiteSpace(formaPagamento.Nome))
                throw new ArgumentException(
                    "O nome da forma de pagamento é obrigatório.");

            formaPagamento.Nome = formaPagamento.Nome.Trim();

            if (formaPagamento.Nome.Length > 100)
            {
                throw new ArgumentException("O nome da forma de pagamento não pode ter mais de 100 caracteres.");

            }

            if (_formaPagamentoRepository.NomeExiste(formaPagamento.Nome, formaPagamento.Id))
            {
                throw new ArgumentException(
                    "Essa forma de pagamento já está cadastrada.");
            }

            existente.Nome = formaPagamento.Nome;
            existente.Ativa = formaPagamento.Ativa;

            _formaPagamentoRepository.Atualizar(existente);
        }

        public void Excluir(int id)
        {
            if (id <= 0)
                throw new ArgumentException(
                    "O ID da forma de pagamento é inválido.");

            var existente = _formaPagamentoRepository.BuscarPorId(id);

            if (existente == null)
                throw new KeyNotFoundException(
                    "Forma de pagamento não encontrada.");

            _formaPagamentoRepository.Excluir(id);
        }
    }
}