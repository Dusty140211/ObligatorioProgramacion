using Microsoft.AspNetCore.Mvc;
using Obligatorio_Logica;
using Obligatorio_Logica.Entidades;

namespace obligatorio_2.Controllers
{
    public class EmpleadoController : Controller
    {
        // 🔹 Instancia del sistema
        private Sistema s = Sistema.Instancia;

        // ======================================================
        // 🏠 ACCIONES PRINCIPALES
        // ======================================================

        public IActionResult Index()
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

            return View(u);
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
        public IActionResult PagoUnico(metodoPago metodo, DateTime fecha, decimal nroRecibo, double monto, string descripcion, string nombreTipo)
        {
            try
            {
                string? email = HttpContext.Session.GetString("email");
                Usuario u = s.BuscarporMail(email);

                // Buscar tipo de gasto
                Tipo_gasto tipo = s.BuscarTipoGastoPorNombre(nombreTipo);
                if (tipo == null)
                    throw new Exception("Tipo de gasto inválido");

                // Crear pago
                PagoUnico nuevo = new PagoUnico(metodo, fecha, nroRecibo, monto, descripcion, tipo, u);
                s.altaPago(nuevo);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("PagoUnico");
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
        public IActionResult PagoRecurrente(metodoPago metodo, DateTime fechaInicio, DateTime fechaFin, string descripcion, int cuotasPagas, int cuotas, double monto, string nombreTipo)
        {
            try
            {
                string? email = HttpContext.Session.GetString("email");
                Usuario u = s.BuscarporMail(email);

                // Buscar tipo de gasto
                Tipo_gasto tipogasto = s.BuscarTipoGastoPorNombre(nombreTipo);
                if (tipogasto == null)
                    throw new Exception("Tipo de gasto inválido");

                // Crear pago recurrente
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
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("PagoRecurrente");
            }
        }
    }
}
