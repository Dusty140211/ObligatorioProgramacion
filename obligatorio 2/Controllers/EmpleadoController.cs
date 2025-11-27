using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Obligatorio_Logica;
using Obligatorio_Logica.Entidades;

namespace obligatorio_2.Controllers
{
    public class EmpleadoController : Controller
    {
        private Sistema s = Sistema.Instancia;
        public IActionResult Index()
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

            // Si es gerente, obtiene todos los miembros de su equipo
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

                ViewBag.Integrantes = integrantes;
            }

            return View(u);
        }
        public IActionResult CargarPagos()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PagoUnico()
        {
            // Carga la vista del formulario para ingresar un pago único.
            // Acá no se hace ninguna lógica, solo se muestra la página.
            return View();
        }
        [HttpPost]
        public IActionResult PagoUnico(metodoPago metodo, DateTime fecha, decimal nroRecibo, double monto, string descripcion, string nombreTipo)
        {
        try { 
            string? email = HttpContext.Session.GetString("email");

            Usuario u = Sistema.Instancia.BuscarporMail(email);
            Tipo_gasto tipo = null;

                foreach (Tipo_gasto tg in Sistema.Instancia.tipo_Gastos)
                {
                    if (tg.Nombre == nombreTipo)
                    {
                        tipo = tg;
                        break; // lo encontramos, no hace falta seguir
                    }
                }

                if (tipo == null)
                {
                    throw new Exception("Tipo de gasto inválido");
                }

                PagoUnico nuevo = new PagoUnico(
                metodo,
                fecha,
                nroRecibo,
                monto,
                descripcion,
                tipo,
                u
            );

            Sistema.Instancia.altaPago(nuevo);
            return RedirectToAction("index");
        }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                
                return View("PagoUnico");
            }

        }
        [HttpGet]
        public IActionResult PagoRecurrente() 
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult PagoRecurrente( metodoPago metodo,DateTime fechaInicio,DateTime fechaFin,string descripcion,int cuotasPagas,int cuotas,double monto,string nombreTipo)
        {
            try {
                    string? email = HttpContext.Session.GetString("email");

                    Usuario u = Sistema.Instancia.BuscarporMail(email);
                    Tipo_gasto tipogasto = null;

                    foreach (Tipo_gasto tg in Sistema.Instancia.tipo_Gastos)
                    {
                        if (tg.Nombre == nombreTipo)
                        {
                            tipogasto = tg;
                            break; 
                        }
                    }

                    if (tipogasto == null)
                    {
                        throw new Exception("Tipo de gasto inválido");
                    }

                    PagoRecurrente nuevo = new PagoRecurrente(
                    metodo,
                    fechaInicio,
                    fechaFin,
                    descripcion,
                    cuotasPagas,
                    cuotas,
                    monto,
                    tipogasto,
                    u
                );

                Sistema.Instancia.altaPago(nuevo);
                return RedirectToAction("index");
              }
            catch (Exception ex)
              {
                TempData["Error"] = ex.Message;

                return View("PagoRecurrente");
             }
        }


     
        

    }
}
