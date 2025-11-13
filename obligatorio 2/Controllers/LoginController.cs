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
        public IActionResult Index(string email, string contraseña) 
        {
            try
            {
                Usuario u = s.Login(email, contraseña);
                if(u.cargo)
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
