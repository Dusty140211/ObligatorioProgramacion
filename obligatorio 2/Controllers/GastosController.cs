using Microsoft.AspNetCore.Mvc;
using Obligatorio_Logica;

namespace obligatorio_2.Controllers
{
    public class GastosController : Controller
    {
        Sistema s = Sistema.Instancia;


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
                return RedirectToAction("listaGastos");
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
