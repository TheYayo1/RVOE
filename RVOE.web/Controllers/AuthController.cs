using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RVOE.contextos;
using System.Linq;

namespace RVOE.web.Controllers
{
    public class AuthController : Controller
    {
        private readonly PladseLocalContext _context;

        public AuthController(PladseLocalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string contrasena)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == correo && u.ContrasenaHash == contrasena);

            if (usuario != null)
            {
                HttpContext.Session.SetString("UsuarioId", usuario.UsuarioId.ToString());
                HttpContext.Session.SetString("Nombre", usuario.Nombre);
                return RedirectToAction("Index", "Escuelas");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
