using Microsoft.AspNetCore.Identity;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Seguranca;
using SistemaGestaoFinanceiraEmpresarial.Repositories.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Services
{
    public class ApplicationUserService
    {
        private readonly IApplicationUserRepository _repository;
        private readonly UserManager<ApplicationUserModel> _userManager;

        public ApplicationUserService(
            IApplicationUserRepository repository,
            UserManager<ApplicationUserModel> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public List<ApplicationUserModel> ListarTodos()
        {
            return _repository.ListarTodos();
        }

        public ApplicationUserModel? BuscarPorId(string id)
        {
            return _repository.BuscarPorId(id);
        }

        public async Task<IdentityResult> Criar(
            ApplicationUserModel usuario,
            string senha)
        {
            return await _userManager.CreateAsync(usuario, senha);
        }

        public void Atualizar(ApplicationUserModel usuario)
        {
            var usuarioExistente = _repository.BuscarPorId(usuario.Id);

            if (usuarioExistente == null)
                throw new ArgumentException("Usuário não encontrado.");

            usuarioExistente.Email = usuario.Email;
            usuarioExistente.UserName = usuario.UserName;
            usuarioExistente.PhoneNumber = usuario.PhoneNumber;
            usuarioExistente.Ativo = usuario.Ativo;

            _repository.Atualizar(usuarioExistente);
        }

        public async Task<IdentityResult> AlterarRole(
            ApplicationUserModel usuario,
            string role)
        {
            var rolesAtuais = await _userManager.GetRolesAsync(usuario);

            if (rolesAtuais.Any())
            {
                var removerResultado =
                    await _userManager.RemoveFromRolesAsync(usuario, rolesAtuais);

                if (!removerResultado.Succeeded)
                    return removerResultado;
            }

            return await _userManager.AddToRoleAsync(usuario, role);
        }

        public async Task<string?> ObterRole(ApplicationUserModel usuario)
        {
            var roles = await _userManager.GetRolesAsync(usuario);

            return roles.FirstOrDefault();
        }

        public void Ativar(ApplicationUserModel usuario)
        {
            usuario.Ativo = true;
            _repository.Atualizar(usuario);
        }

        public void Desativar(ApplicationUserModel usuario)
        {
            usuario.Ativo = false;
            _repository.Atualizar(usuario);
        }
    }
}