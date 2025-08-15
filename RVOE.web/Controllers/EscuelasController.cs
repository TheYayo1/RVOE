using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RVOE.contextos;
using RVOE.modelos.ValidadorModelos;

namespace RVOE.web.Controllers
{
    public class EscuelasController : Controller
    {
        private readonly ValidadorUniversidadesContext _context;

        public EscuelasController(ValidadorUniversidadesContext context)
        {
            _context = context;
        }

        // Listado + Buscador
        public async Task<IActionResult> Index(string search)
        {
            var query = _context.Escuelas.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.NombreEscuela.Contains(search) || e.CCT.Contains(search));
            }

            return View(await query.ToListAsync());
        }

        // GET Crear
        public IActionResult Agregar()
        {
            ViewBag.TiposEscuela = _context.TiposEscuela.ToList();
            return View();
        }

        // POST Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar(Escuelas escuela)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escuela);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escuela);
        }

        // GET Detalles (Dashboard de la escuela)
        public async Task<IActionResult> Details(int id)
        {
            var escuela = await _context.Escuelas.FindAsync(id);
            if (escuela == null) return NotFound();

            return View(escuela);
        }
    }
}
