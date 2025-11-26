using Microsoft.AspNetCore.Mvc;
using Obligatorio_Logica;
using Obligatorio_Logica.Entidades;

namespace obligatorio_2.Controllers
{
    public class GerenteController : Controller
    {
        private Sistema s = Sistema.Instancia;

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

           
            if (u.Rol == Cargo.GERENTE)
            {
                List<Usuario> integrantes = new List<Usuario>();
                foreach (Usuario otro in Sistema.Instancia.Usuarios)
                {
                    if (otro.Equipo.Nombre == u.Equipo.Nombre && otro != u)
                    {
                        integrantes.Add(otro);
                    }
                }
                integrantes.Sort(Sistema.Instancia.CompararPorEmail);

                ViewBag.Integrantes = integrantes;
            }
            return View(u);
        }
        public IActionResult index(DateTime? fecha)
        {

            DateTime f;

            if (fecha == null)
            {
                f = DateTime.Now; // Usa la fecha actual
            }
            else
            {
                f = fecha.Value; // Usa la que pasó el usuario
            }

            string? email = HttpContext.Session.GetString("email");
            

            if (HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            s.CalcularPagoPendientesPorMail(email);

            Usuario u = Sistema.Instancia.BuscarporMail(email);

            List<Pago> pagos = s.pagosDeEquipo(f, u);
           
            return View(pagos);
        }
    }
}
