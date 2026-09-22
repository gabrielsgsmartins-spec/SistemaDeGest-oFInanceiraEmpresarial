using Microsoft.AspNetCore.Mvc;

namespace SistemaDeGestãoFinanceiraEmpresarial
{
    public class CategoriaFinanceiraModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
