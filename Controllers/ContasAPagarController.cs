using Microsoft.AspNetCore.Mvc;
using SistemaGestaoFinanceiraEmpresarial.Services;
using SistemaGestaoFinanceiraEmpresarial.Enums;
using SistemaDeGestãoFinanceiraEmpresarial.Models.Financeiro;

namespace SistemaGestaoFinanceiraEmpresarial.Controllers
{
    public class ContasAPagarController : Controller
    {
        private readonly ContasAPagarService _service;
        public ContasAPagarController(ContasAPagarService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var contasAPagar = _service.ListarTodos();

            return View(contasAPagar);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(ContaPagarModel contaPagar)
        {
            if (!ModelState.IsValid)
                return View(contaPagar);

            _service.Cadastrar(contaPagar);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var contaPagar = _service.BuscarPorId(id);

            if (contaPagar == null)
                return NotFound();

            return View(contaPagar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ContaPagarModel contaPagar)
        {
            if (!ModelState.IsValid)
                return View(contaPagar);

            _service.Editar(contaPagar);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int id)
        {
            _service.Excluir(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegistrarPagamento(int id)
        {
            _service.RegistrarPagamento(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult PorFornecedor(int fornecedorId)
        {
            var contas = _service.ListarContasPorFornecedor(fornecedorId);

            return View(contas);
        }

        [HttpGet]
        public IActionResult PorStatus(StatusContaEnum status)
        {
            var contas = _service.ListarContasPorStatus(status);

            return View(contas);
        }

        [HttpGet]
        public IActionResult PorCategoria(int categoriaId)
        {
            var contas = _service.ListarContasPorCategoria(categoriaId);

            return View(contas);
        }

        [HttpGet]
        public IActionResult PorCentroCustoVencidas(int centroCustoId)
        {
            var contas = _service.ListarStatusVencida(centroCustoId);

            return View(contas);
        }

        [HttpGet]
        public IActionResult PorDataVencimento(DateTime dataVencimento)
        {
            var contas = _service.ListarContasPorDataVencimento(dataVencimento);

            return View(contas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizarStatusContas()
        {
            _service.AtualizarStatusContas();

            return RedirectToAction(nameof(Index));
        }
    }
}