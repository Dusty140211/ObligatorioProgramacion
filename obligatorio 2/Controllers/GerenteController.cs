using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Obligatorio_Logica;
using Obligatorio_Logica.Entidades;

namespace obligatorio_2.Controllers
{
    public class GerenteController : Controller
    {
        private Sistema s = Sistema.Instancia;

        /*
        public IActionResult index(DateTime? fecha)
        {
            try
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
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        */


        /*
        public IActionResult equipoI(DateTime? fecha) 
        {
            try
            {
                string? email = HttpContext.Session.GetString("email");

                if (email == null)
                    return RedirectToAction("Index", "Login");

                List<Pago> pagos = s.ObtenerPagosDeEquipo(fecha, email);

                return View(pagos);
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }
        */
        /*
        public IActionResult Perfil()
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
        */
        /*
        [HttpGet]
        public IActionResult cargarGasto() 
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult cargarGasto(string nombre, string descripcion) 
        {
            try
            {
                Tipo_gasto nuevo = new Tipo_gasto(
                   nombre,
                   descripcion
                   );
                s.altaGasto(nuevo);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }
        

        public IActionResult listaGastos()
        {
            List<Tipo_gasto> gastos = s.listarTiposGasto();
            return View(gastos); 
        }
        */

        public IActionResult EliminarGasto(string nombre)
        {
            try
            {
                Tipo_gasto tg = s.BuscarTipoGastoPorNombre(nombre);
                return View(tg);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                List<Tipo_gasto> lista = s.listarTiposGasto();
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
