using Obligatorio_Logica;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_Logica.Entidades;


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
                HttpContext.Session.SetString("email", u.Email);
                HttpContext.Session.SetString("pass", u.Contrasenia);

                if (u.Rol == Cargo.EMPLEADO)
                {
                    HttpContext.Session.SetString("Rol", "Empleado");
                    return RedirectToAction("Index", "Empleado");
                }
                else if (u.Rol == Cargo.GERENTE)
                {
                    HttpContext.Session.SetString("Rol", "Gerente");
                    return RedirectToAction("Index", "Gerente");
                }
                else 
                {
                    return RedirectToAction("index", "Home");
                }
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
            return RedirectToAction("Index", "Login");
        }
    }
}
