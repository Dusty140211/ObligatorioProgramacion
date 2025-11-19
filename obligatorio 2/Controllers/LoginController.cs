using Obligatorio_Logica;
using Microsoft.AspNetCore.Mvc;


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

                if (u.Rol == Usuario.Cargo.Empleado)
                  {
                      HttpContext.Session.SetString("Rol", "Empleado");
                  }
                  else if(u.Rol == Usuario.Cargo.Gerente)
                  {
                      HttpContext.Session.SetString("Rol", "Gerente");
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
            return RedirectToAction("Index", "Login");
        }
    }
}
