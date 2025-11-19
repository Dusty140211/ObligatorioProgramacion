using Microsoft.AspNetCore.Mvc;
using Obligatorio_Logica;

namespace obligatorio_2.Controllers
{
    public class EmpleadoController : Controller
    {
        private Sistema s = Sistema.Instancia; 
        public IActionResult Index()
        {
            string? email = HttpContext.Session.GetString("email");
            if (HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Index", "Login"); 
            }
            return View(s.listarPagosPorMail("email"));
        }
        public IActionResult Perfil()
        {
            string? email = HttpContext.Session.GetString("email");

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }

            Usuario u = Sistema.Instancia.BuscarporMail(email);

            double totalMes = Sistema.Instancia.MontoGastadoEsteMes(email);
           
            ViewBag.TotalMes = totalMes;

            return View(u); 
        }
    }
}
