using Microsoft.AspNetCore.Mvc;
using Obligatorio_Logica;
using Obligatorio_Logica.Entidades;

namespace obligatorio_2.Controllers
{
    public class PagosController : Controller
    {
        private Sistema s = Sistema.Instancia;

        public IActionResult Index()
        {
            try
            {
                string? email = HttpContext.Session.GetString("email");
                if (email == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                s.CalcularPagoPendientesPorMail(email);
                Usuario u = s.BuscarporMail(email);
                List<Pago> pagos = s.pagosDelMes(DateTime.Now, u);

                return View(pagos);
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }

        public IActionResult CargarPagos()
        {
            return View();
        }

        // ======================================================
        // 💵 PAGO ÚNICO
        // ======================================================

        [HttpGet]
        public IActionResult PagoUnico()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PagoUnico(
            metodoPago metodo,
            DateTime fecha,
            decimal nroRecibo,
            double monto,
            string descripcion,
            string nombreTipo)
        {
            try
            {
                string? email = HttpContext.Session.GetString("email");
                if (string.IsNullOrEmpty(email))
                    return RedirectToAction("Index", "Login");

                Usuario u = s.BuscarporMail(email);
                Tipo_gasto tipo = s.BuscarTipoGastoPorNombre(nombreTipo);

                PagoUnico nuevo = new PagoUnico(metodo, fecha, nroRecibo, monto, descripcion, tipo, u);
                s.altaPago(nuevo);

                return RedirectToAction("Index", "Pagos");
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }

        // ======================================================
        // 🔁 PAGO RECURRENTE
        // ======================================================

        [HttpGet]
        public IActionResult PagoRecurrente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PagoRecurrente(
            metodoPago metodo,
            DateTime fechaInicio,
            DateTime fechaFin,
            string descripcion,
            int cuotasPagas,
            int cuotas,
            double monto,
            string nombreTipo)
        {
            try
            {
                string? email = HttpContext.Session.GetString("email");
                if (string.IsNullOrEmpty(email))
                    return RedirectToAction("Index", "Login");

                Usuario u = s.BuscarporMail(email);
                Tipo_gasto tipogasto = s.BuscarTipoGastoPorNombre(nombreTipo);

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

                s.altaPago(nuevo);

                return RedirectToAction("Index", "Pagos");
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }

        // ======================================================
        // 🔁 VER LISTADO DE PAGOS
        // ======================================================

        public IActionResult equipoPagos(DateTime? fecha)
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
    }
}