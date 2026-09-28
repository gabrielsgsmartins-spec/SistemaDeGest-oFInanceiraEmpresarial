using Microsoft.AspNetCore.Mvc;
using SistemaGestaoFinanceiraEmpresarial.Models;
using SistemaGestaoFinanceiraEmpresarial.Services.Interfaces;

namespace SistemaGestaoFinanceiraEmpresarial.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserService _service;

        public ApplicationUserController(IApplicationUserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var usuarios = _service.ListarTodos();

            return View(usuarios);
        }

        public IActionResult Editar(string id)
        {
            var usuario = _service.BuscarPorId(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(ApplicationUserModel usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            _service.Atualizar(usuario);

            return RedirectToAction(nameof(Index));
        }
    }
}