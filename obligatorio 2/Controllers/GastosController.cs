using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Obligatorio_Logica;
using Obligatorio_Logica.Entidades;

namespace obligatorio_2.Controllers
{
    public class GastosController : Controller
    {
        Sistema si = Sistema.Instancia;
       

        [HttpGet]
        public IActionResult cargarGasto()
        {
            string? email = HttpContext.Session.GetString("email");


            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }


            Usuario s = si.BuscarporMail(email);
            if (s == null)
            {
                return RedirectToAction("Index", "Login");
            }


            if (s.Rol == Cargo.EMPLEADO)
            {
                return RedirectToAction("Index", "Pagos");
            }

            return View();
        }

        [HttpPost]
        public IActionResult CargarGasto(string nombre, string descripcion)
        {
            string? email = HttpContext.Session.GetString("email");


            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }


            Usuario s = si.BuscarporMail(email);
            if (s == null)
            {
                return RedirectToAction("Index", "Login");
            }


            if (s.Rol == Cargo.EMPLEADO)
            {
                return RedirectToAction("Index", "Pagos");
            }
            try
            {
                Tipo_gasto nuevo = new Tipo_gasto(nombre, descripcion);
                si.altaGasto(nuevo);
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
            string? email = HttpContext.Session.GetString("email");


            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }


            Usuario s = si.BuscarporMail(email);
            if (s == null)
            {
                return RedirectToAction("Index", "Login");
            }


            if (s.Rol == Cargo.EMPLEADO)
            {
                return RedirectToAction("Index", "Pagos");
            }

            List<Tipo_gasto> gastos = si.listarTiposGasto();
            return View(gastos);
        }


        public IActionResult EliminarGasto(string nombre)
        {
            string? email = HttpContext.Session.GetString("email");


            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }


            Usuario s = si.BuscarporMail(email);
            if (s == null)
            {
                return RedirectToAction("Index", "Login");
            }


            if (s.Rol == Cargo.EMPLEADO)
            {
                return RedirectToAction("Index", "Pagos");
            }

            try
            {
                Tipo_gasto tg = si.BuscarTipoGastoPorNombre(nombre);
                return View(tg);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                List<Tipo_gasto> lista = si.listarTiposGasto();
                return View("ListaGastos", lista);
            }
        }

        [HttpPost]
        public IActionResult ConfirmarEliminarGasto(string nombre)
        {
            string? email = HttpContext.Session.GetString("email");


            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }


            Usuario s = si.BuscarporMail(email);
            if (s == null)
            {
                return RedirectToAction("Index", "Login");
            }


            if (s.Rol == Cargo.EMPLEADO)
            {
                return RedirectToAction("Index", "Pagos");
            }

            try
            {
                si.EliminarGasto(nombre);
                List<Tipo_gasto> lista = si.listarTiposGasto();
                return View("listaGastos", lista);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                List<Tipo_gasto> lista = si.listarTiposGasto();
                return View("listaGastos", lista);
            }
        }

     
        

    }
}
