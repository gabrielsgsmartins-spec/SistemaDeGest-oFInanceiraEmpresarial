using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;
using SistemaGestaoFinanceiraEmpresarial.Enums;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Bancario;

namespace SistemaGestaoFinanceiraEmpresarial
{
    public class ContaBancariaService
    {
        private readonly IContaBancariaRepository _contasBancariasRepository;
        private readonly IMovimentacaoFinanceiraRepository _movimentacaoFinanceiraRepository;
        public ContaBancariaService(IContaBancariaRepository contasBancariasRepository, IMovimentacaoFinanceiraRepository movimentacaoFinanceiraRepository)
        {
            _contasBancariasRepository = contasBancariasRepository;
            _movimentacaoFinanceiraRepository = movimentacaoFinanceiraRepository;
        }
        public List<ContaBancariaModel> ListarTodos()
        {
            try
            {
                return _contasBancariasRepository.ListarTodos();
            }
            catch (Exception ex)
            {
                //Erro ao listar as Contas Bancárias
                throw new Exception("Ocorreu um erro ao listar as contas bancárias.", ex);
            }
        }
        public ContaBancariaModel? BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException(
                        "O ID da conta bancária deve ser maior que zero.",
                        nameof(id));
                }
                return _contasBancariasRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Ocorreu um erro ao buscar a conta bancária com ID {id}.",
                    ex);
            }
        }
        public void Cadastrar(ContaBancariaModel contaBancaria)
        {
            try
            {
                if (contaBancaria == null)
                {
                    throw new ArgumentNullException(nameof(contaBancaria), "A conta bancária não pode ser nula.");
                }
                if (string.IsNullOrWhiteSpace(contaBancaria.Banco))
                {
                    throw new ArgumentException("O nome do banco não pode ser nulo ou vazio.", nameof(contaBancaria.Banco));
                }
                if (string.IsNullOrWhiteSpace(contaBancaria.Agencia))
                {
                    throw new ArgumentException("O número da agência não pode ser nulo ou vazio.", nameof(contaBancaria.Agencia));
                }
                if (string.IsNullOrWhiteSpace(contaBancaria.NumeroConta))
                {
                    throw new ArgumentException("O número da conta não pode ser nulo ou vazio.", nameof(contaBancaria.NumeroConta));
                }
                if (string.IsNullOrWhiteSpace(contaBancaria.TipoConta))
                {
                    throw new ArgumentException("O tipo da conta não pode ser nulo ou vazio.", nameof(contaBancaria.TipoConta));
                }
                if(contaBancaria.Saldo < 0)
                {
                    throw new ArgumentException("O saldo da conta não pode ser negativo.", nameof(contaBancaria.Saldo));
                }

                if (contaBancaria.Agencia.Length > 100)
                {
                    throw new ArgumentException("O número da agência não pode ter mais de 100 caracteres.", nameof(contaBancaria.Agencia));
                }
                if (_contasBancariasRepository.BuscarPorId(contaBancaria.Id) != null)
                {
                    throw new InvalidOperationException($"Já existe uma conta bancária com o ID {contaBancaria.Id}.");
                }
                contaBancaria.DataCadastro = DateTime.Now;
                contaBancaria.Saldo = 0;

                _contasBancariasRepository.Adicionar(contaBancaria);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadastrar a conta bancária.", ex);
            }
        }
        public void Atualizar(ContaBancariaModel contaBancaria)
        {
            try
            {
                if (contaBancaria == null)
                {
                    throw new ArgumentNullException(nameof(contaBancaria), "A conta bancária não pode ser nula.");
                }
                
                if (string.IsNullOrWhiteSpace(contaBancaria.Banco))
                {
                    throw new ArgumentException("O nome do banco não pode ser nulo ou vazio.", nameof(contaBancaria.Banco));
                }
                if (contaBancaria.Agencia.Length > 100)
                {
                    throw new ArgumentException("O nome do banco não pode ter mais de 100 caracteres.", nameof(contaBancaria.Banco));
                }
                var contaExistente = _contasBancariasRepository.BuscarPorId(contaBancaria.Id);
                if (contaExistente == null)
                {
                    throw new InvalidOperationException($"Não existe uma conta bancária com o ID {contaBancaria.Id}.");
                }
                _contasBancariasRepository.Atualizar(contaBancaria);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar a conta bancária.", ex);
            }
        }
        public void Ativar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID da conta bancária inválido.");

            var conta = _contasBancariasRepository.BuscarPorId(id);

            if (conta == null)
                throw new KeyNotFoundException("Conta bancária não encontrada.");

            if (conta.Ativa)
                throw new InvalidOperationException("A conta bancária já está ativa.");

         

            conta.Ativa = true;

            _contasBancariasRepository.Atualizar(conta);
        }
        public void Desativar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID da conta bancária inválido.");

            var conta = _contasBancariasRepository.BuscarPorId(id);

            if (conta == null)
                throw new KeyNotFoundException("Conta bancária não encontrada.");

            if (!conta.Ativa)
                throw new InvalidOperationException("A conta bancária já está desativada.");

            if (_movimentacaoFinanceiraRepository.PossuiOperacoesPendentes(id))
                throw new InvalidOperationException(
                    "Não é possível desativar a conta porque existem operações pendentes."
                );

            conta.Ativa = false;

            _contasBancariasRepository.Atualizar(conta);
        }
    }
   
}