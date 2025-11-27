using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Obligatorio_Logica;
using Obligatorio_Logica.Entidades;

namespace obligatorio_2.Controllers
{
    public class GerenteController : Controller
    {
        private Sistema s = Sistema.Instancia;

        public IActionResult index(DateTime? fecha)
        {
            string? email = HttpContext.Session.GetString("email");
            if (HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            s.CalcularPagoPendientesPorMail(email);

            Usuario u = Sistema.Instancia.BuscarporMail(email);

            List<Pago> pagos = s.pagosDelMes(DateTime.Now, u);

            return View(pagos);

        }

        public IActionResult equipoI(DateTime? fecha) 
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

            Usuario u = s.BuscarporMail(email);

            List<Pago> pagos = s.pagosDeEquipo(f, u);

            return View(pagos);
        }

        public IActionResult Perfil()
        {
            string? email = HttpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }

            Usuario u = s.BuscarporMail(email);

            double totalMes = s.MontoGastadoEsteMes(email);
            ViewBag.TotalMes = totalMes;

           
            if (u.Rol == Cargo.GERENTE)
            {
                List<Usuario> integrantes = new List<Usuario>();
                foreach (Usuario otro in s.Usuarios)
                {
                    if (otro.Equipo.Nombre == u.Equipo.Nombre && otro != u)
                    {
                        integrantes.Add(otro);
                    }
                }
                integrantes.Sort(s.CompararPorEmail);

                ViewBag.Integrantes = integrantes;
            }
            return View(u);
        }
        [HttpGet]
        public IActionResult cargarGasto() 
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult cargarGasto(string nombre, string descripcion) 
        {
            Tipo_gasto nuevo = new Tipo_gasto(
               nombre,
               descripcion
               );
            s.altaGasto(nuevo);
            return RedirectToAction("index");
        }


        public IActionResult listaGastos()
        {
            List<Tipo_gasto> gastos = s.listarTiposGasto();
            return View(gastos); 
        }
       
        public IActionResult EliminarGasto(string nombre)
        {
            try
            {
                Tipo_gasto tg = null;

                foreach (Tipo_gasto t in s.listarTiposGasto())
                {
                    if (t.Nombre == nombre)
                    {
                        tg = t;
                        break;
                    }
                }

                if (tg != null)
                {
                   
                    return View(tg);
                }
                else
                {
                    List<Tipo_gasto> lista = s.listarTiposGasto();
                    ViewBag.Error = "El tipo de gasto no existe.";
                    return View("ListaGastos", lista);
                }
            }
            catch (Exception ex)
            {
                
                List<Tipo_gasto> lista = s.listarTiposGasto();
                ViewBag.Error = ex.Message;
                return View("ListaGastos", lista);
            }
        }

        [HttpPost]
        public IActionResult eliminarGasto(string nombre)
        {
            try
            {
                s.EliminarGasto(nombre);
                List<Tipo_gasto> lista = s.listarTiposGasto();
                return View("listaGastos", lista);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                List<Tipo_gasto> lista = s.listarTiposGasto();
                return View("ListaGastos", lista);
            }
        }
    }
}
