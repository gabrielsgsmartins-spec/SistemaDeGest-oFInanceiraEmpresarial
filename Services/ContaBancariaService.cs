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
        public ContaBancariaService(IContaBancariaRepository contasBancariasRepository)
        {
            _contasBancariasRepository = contasBancariasRepository;
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
                if (contaBancaria.Agencia.Length > 100)
                {
                    throw new ArgumentException("O nome do banco não pode ter mais de 100 caracteres.", nameof(contaBancaria.Banco));
                }
                if (_contasBancariasRepository.BuscarPorId(contaBancaria.Id) != null)
                {
                    throw new InvalidOperationException($"Já existe uma conta bancária com o ID {contaBancaria.Id}.");
                }
                _contasBancariasRepository.Adicionar(contaBancaria);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadastrar a conta bancária.", ex);
            }
        }
    }
   
}