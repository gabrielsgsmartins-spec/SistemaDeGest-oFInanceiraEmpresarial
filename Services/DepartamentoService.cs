using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Repositories;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;
using SistemaGestaoFinanceiraEmpresarial.Enums;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Cadastros;

namespace SistemaGestaoFinanceiraEmpresarial.Services
{
    public class DepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;

        public DepartamentoService(IDepartamentoRepository departamentoRepository, IFuncionarioRepository funcionarioRepository)
        {
            _departamentoRepository = departamentoRepository;
            _funcionarioRepository = funcionarioRepository;
        }

        public List<DepartamentoModel> ListarTodos()
        {
            try
            {
                return _departamentoRepository.ListarTodos();

            }
            catch (Exception ex)
            {
                //Erro ao listar os departamentos
                throw new Exception("Ocorreu um erro ao listar os departamentos.", ex);
            }
        }

        public DepartamentoModel? BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("O ID do departamento deve ser maior que zero.", nameof(id));
                }

                return _departamentoRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                //Erro ao buscar o departamento com ID
                throw new Exception($"Ocorreu um erro ao buscar o departamento com ID {id}.", ex);
            }
        }
        public void Cadastrar(DepartamentoModel departamento)
        {
            try
            {
                if (departamento == null)
                {
                    throw new ArgumentNullException(nameof(departamento), "O departamento não pode ser nulo.");
                }
                if (string.IsNullOrWhiteSpace(departamento.Nome))
                {
                    throw new ArgumentException("O nome do departamento não pode ser nulo ou vazio.", nameof(departamento.Nome));
                }
                var departamentoExistente = _departamentoRepository.BuscarPorNome(departamento.Nome);
                if (departamentoExistente != null)
                {
                    throw new InvalidOperationException($"Já existe um departamento com o nome '{departamento.Nome}'.");
                }
                if (departamento.Nome.Length > 100)
                {
                    throw new ArgumentException("O nome do departamento não pode ter mais de 100 caracteres.", nameof(departamento.Nome));
                }

                _departamentoRepository.Cadastrar(departamento);
            }
            catch (Exception ex)
            {
                //Erro ao cadastrar o departamento
                throw new Exception("Ocorreu um erro ao cadastrar o departamento.", ex);
            }
        }

        public void Atualizar(DepartamentoModel departamento)
        {
            try
            {
                if (departamento == null)
                {
                    throw new ArgumentNullException(nameof(departamento), "O departamento não pode ser nulo.");
                }
                if (departamento.Id <= 0)
                {
                    throw new ArgumentException("O ID do departamento deve ser maior que zero.", nameof(departamento.Id));
                }
                if (string.IsNullOrWhiteSpace(departamento.Nome))
                {
                    throw new ArgumentException("O nome do departamento não pode ser nulo ou vazio.", nameof(departamento.Nome));
                }
                if (departamento.Nome.Length > 100)
                {
                    throw new ArgumentException("O nome do departamento não pode ter mais de 100 caracteres.", nameof(departamento.Nome));
                }
                _departamentoRepository.Atualizar(departamento);
            }
            catch (Exception ex)
            {
                //Erro ao atualizar o departamento
                throw new Exception($"Ocorreu um erro ao atualizar o departamento com ID {departamento.Id}.", ex);
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentNullException(nameof(id), "O ID do departamento não pode ser nulo ou zero.");
                }
                var BuscarDepartamento = _departamentoRepository.BuscarPorId(id);

                if (BuscarDepartamento == null)
                {
                    throw new InvalidOperationException($"Não foi possível excluir o departamento com ID {id} porque ele não existe.");
                }
                if (id <= 0)
                {
                    throw new ArgumentException("O ID do departamento deve ser maior que zero.", nameof(id));
                }

                if (_funcionarioRepository.PossuiFuncionarios(id))
                {
                    throw new InvalidOperationException("Não é possível excluir o departamento porque existem funcionários vinculados a ele.");
                }
                return _departamentoRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                //Erro ao excluir o departamento
                throw new Exception($"Ocorreu um erro ao excluir o departamento com ID {id}.", ex);
            }
        }
        public List<DepartamentoModel> ListarAtivos()
        {
            try
            {
                var departamentos = _departamentoRepository.ListarTodos();
                return departamentos.Where(d => d.Ativo).ToList();
            }
            catch (Exception ex)
            {
                //Erro ao listar os departamentos ativos
                throw new Exception("Ocorreu um erro ao listar os departamentos ativos.", ex);
            }
        }

        public List<DepartamentoModel> ListarInativos()
        {
            try
            {
                var departamentos = _departamentoRepository.ListarTodos();
                return departamentos.Where(d => !d.Ativo).ToList();
            }
            catch (Exception ex)
            {
                //Erro ao listar os departamentos inativos
                throw new Exception("Ocorreu um erro ao listar os departamentos inativos.", ex);
            }
        }

    }
}
