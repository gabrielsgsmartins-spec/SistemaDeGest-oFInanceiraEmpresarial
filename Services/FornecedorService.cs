using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaGestaoFinanceiraEmpresarial.Enums;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;

namespace SistemaGestaoFinanceiraEmpresarial.Services
{
    public class FornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public List<FornecedorModel> ListarTodos()
        {
            try
            {
                return _fornecedorRepository.ListarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar os fornecedores.", ex);
            }
        }

        public FornecedorModel? BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID do fornecedor deve ser maior que zero.", nameof(id));
                }
                return _fornecedorRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar o fornecedor com ID {id}.", ex);
            }
        }
        public void Cadastrar(FornecedorModel fornecedor)
        {
            try
            {
                if (fornecedor == null)
                {
                    throw new ArgumentNullException(nameof(fornecedor), "O fornecedor não pode ser nulo.");
                }
                if (string.IsNullOrWhiteSpace(fornecedor.NomeFantasia))
                {
                    throw new ArgumentException("O nome fantasia do fornecedor não pode ser nulo ou vazio.", nameof(fornecedor.NomeFantasia));
                }
                if (fornecedor.NomeFantasia.Length > 100)
                {
                    throw new ArgumentException("O nome fantasia do fornecedor não pode ter mais de 100 caracteres.", nameof(fornecedor.NomeFantasia));
                }
                if (_fornecedorRepository.BuscarPorId(fornecedor.Id) != null)
                {
                    throw new InvalidOperationException("Já existe um fornecedor com o mesmo ID.");
                }

                _fornecedorRepository.Adicionar(fornecedor);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao cadastrar o fornecedor.", ex);
            }
        }

        public void Editar(FornecedorModel fornecedor)
        {
            try
            {
                if (fornecedor == null)
                {
                    throw new ArgumentNullException(nameof(fornecedor), "O fornecedor não pode ser nulo.");
                }
                if (fornecedor.Id <= 0)
                {
                    throw new ArgumentException("O ID do fornecedor deve ser maior que zero.", nameof(fornecedor.Id));
                }
               
                _fornecedorRepository.Atualizar(fornecedor);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao editar o fornecedor.", ex);
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID do fornecedor deve ser maior que zero.", nameof(id));
                }
                if (_fornecedorRepository.BuscarPorId(id) == null)
                {
                    throw new KeyNotFoundException($"Fornecedor com ID {id} não encontrado.");
                }

                return _fornecedorRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao excluir o fornecedor com ID {id}.", ex);
            }
        }

    }
}