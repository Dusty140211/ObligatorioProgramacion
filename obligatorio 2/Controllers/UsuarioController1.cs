using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Obligatorio_Logica;
using Obligatorio_Logica.Entidades;

namespace obligatorio_2.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema s = Sistema.Instancia;

        // ======================================================
        // 👤 PERFIL DE USUARIO (Gerente o Empleado)
        // ======================================================
        public IActionResult PerfilEmpleado()
        {
            try
            {
                string? email = HttpContext.Session.GetString("email");
                if (string.IsNullOrEmpty(email))
                {
                    return RedirectToAction("Index", "Login");
                }

                Usuario u = s.BuscarporMail(email);
                double totalMes = s.MontoGastadoEsteMes(email);
                ViewBag.TotalMes = totalMes;

                return View(u);
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }

        public IActionResult PerfilGerente()
        {
            try
            {
                string? email = HttpContext.Session.GetString("email");

                Usuario u = s.BuscarporMail(email);
                double totalMes = s.MontoGastadoEsteMes(email);
                ViewBag.TotalMes = totalMes;


                List<Usuario> integrantes = s.ObtenerIntegrantesEquipo(u);
                ViewBag.Integrantes = integrantes;


                return View(u);
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }
    }
}