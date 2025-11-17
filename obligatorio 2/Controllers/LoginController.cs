                    using Microsoft.AspNetCore.Mvc;
using Obligatorio_Logica;

namespace obligatorio_2.Controllers
{
    public class LoginController : Controller
    {
        Sistema s = Sistema.Instancia; 
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string email, string pass) 
        {
            try
            {
                Usuario u = s.Login(email, pass);

                if (u.Rol == Usuario.Cargo.Empleado)
                {
                    HttpContext.Session.SetString("Cargo", "Empleado");
                }
                else
                {
                    HttpContext.Session.SetString("Cargo", "Gerente");
                }
                return RedirectToAction("Index", "Empleado");
            }
            catch(Exception ex)
            {
                ViewBag.msg = ex.Message; 
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
