
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoFinanceiraEmpresarial.Data;
using SistemaGestaoFinanceiraEmpresarial.Models;

namespace SistemaDeGestaoFinanceiraEmpresarial.Controllers
{
    public class CategoriaFinanceiraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaFinanceiraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 
        public async Task<IActionResult> Index()
        {
            var categorias = await _context.CategoriasFinanceiras.ToListAsync();

            return View(categorias);
        }

        // Mostra a tela de cadastro
        public IActionResult Adicionar()
        {
            return View();
        }

        // Salva a categoria
        [HttpPost]
        public async Task<IActionResult> Adicionar(CategoriaFinanceiraModel categoria)
        {
            if (!ModelState.IsValid)
                return View(categoria);

            _context.CategoriasFinanceiras.Add(categoria);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Mostra a tela de edição
        public async Task<IActionResult> Editar(int id)
        {
            var categoria = await _context.CategoriasFinanceiras.FindAsync(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        // Salva a edição
        [HttpPost]
        public async Task<IActionResult> Editar(int id, CategoriaFinanceiraModel categoria)
        {
            if (id != categoria.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(categoria);

            _context.CategoriasFinanceiras.Update(categoria);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Exclui a categoria
        public async Task<IActionResult> Excluir(int id)
        {
            var categoria = await _context.CategoriasFinanceiras.FindAsync(id);

            if (categoria == null)
                return NotFound();

            _context.CategoriasFinanceiras.Remove(categoria);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
