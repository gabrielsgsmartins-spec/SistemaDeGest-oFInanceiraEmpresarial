using Microsoft.AspNetCore.Mvc;

namespace SistemaDeGestãoFinanceiraEmpresarial.Models
{
    public class DepartamentoModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
