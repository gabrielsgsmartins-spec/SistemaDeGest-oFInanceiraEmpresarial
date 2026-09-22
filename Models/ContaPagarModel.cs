using Microsoft.AspNetCore.Mvc;

namespace SistemaDeGestãoFinanceiraEmpresarial.Models
{
    public class ContaPagarModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
