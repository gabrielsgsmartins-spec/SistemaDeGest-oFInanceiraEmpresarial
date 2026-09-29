using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Seguranca;
using SistemaGestaoFinanceiraEmpresarial.Services;

namespace SistemaGestaoFinanceiraEmpresarial.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class ApplicationUserController : Controller
    {
        private readonly ApplicationUserService _service;

        public ApplicationUserController(ApplicationUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var usuarios = _service.ListarTodos();

            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar(
            ApplicationUserModel usuario,
            string senha)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            usuario.UserName = usuario.Email;
            usuario.Ativo = true;
            usuario.DataCadastro = DateTime.Now;

            var resultado = await _service.Criar(usuario, senha);

            if (resultado.Succeeded)
            {
                TempData["Sucesso"] = "Usuário cadastrado com sucesso.";

                return RedirectToAction(nameof(Index));
            }

            foreach (var erro in resultado.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    erro.Description);
            }

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Detalhes(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            var usuario = _service.BuscarPorId(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            var usuario = _service.BuscarPorId(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ApplicationUserModel usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            try
            {
                _service.Atualizar(usuario);

                TempData["Sucesso"] = "Usuário atualizado com sucesso.";

                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return View(usuario);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ativar(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            var usuario = _service.BuscarPorId(id);

            if (usuario == null)
                return NotFound();

            _service.Ativar(usuario);

            TempData["Sucesso"] = "Usuário ativado com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Desativar(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            var usuario = _service.BuscarPorId(id);

            if (usuario == null)
                return NotFound();

            _service.Desativar(usuario);

            TempData["Sucesso"] = "Usuário desativado com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AlterarRole(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            var usuario = _service.BuscarPorId(id);

            if (usuario == null)
                return NotFound();

            var roleAtual = await _service.ObterRole(usuario);

            ViewBag.RoleAtual = roleAtual;

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlterarRole(
            string id,
            string role)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            if (string.IsNullOrWhiteSpace(role))
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Selecione uma função para o usuário.");

                var usuarioErro = _service.BuscarPorId(id);

                if (usuarioErro == null)
                    return NotFound();

                return View(usuarioErro);
            }

            var usuario = _service.BuscarPorId(id);

            if (usuario == null)
                return NotFound();

            var resultado = await _service.AlterarRole(
                usuario,
                role);

            if (resultado.Succeeded)
            {
                TempData["Sucesso"] =
                    "Permissão do usuário alterada com sucesso.";

                return RedirectToAction(nameof(Index));
            }

            foreach (var erro in resultado.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    erro.Description);
            }

            ViewBag.RoleAtual = await _service.ObterRole(usuario);

            return View(usuario);
        }
    }
}