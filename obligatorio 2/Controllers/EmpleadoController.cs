using Microsoft.AspNetCore.Mvc;
using Obligatorio_Logica;

namespace obligatorio_2.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
