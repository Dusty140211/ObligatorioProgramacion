using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Logica
{
    public class PagoUnico : Pago
    {
        private DateTime fecha;
        private decimal nroRecibo;
        public metodo_pago Metodo { get; set; }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public decimal NroRecibo
        {
            get { return nroRecibo; }
            set { nroRecibo = value; }
        }


        public PagoUnico(metodo_pago metodo, DateTime fecha, decimal nroRecibo, double monto, string descripcion, List<Tipo_gasto> tipo, Usuario usuario) :
            base(monto, descripcion, tipo, usuario)
        {
            this.Metodo = metodo;
            this.fecha = fecha;
            this.nroRecibo = nroRecibo;
        }

        public int calcularDescuento(int monto)
        {
            int resultado;
            if (Metodo == metodo_pago.EFECTIVO)
            {
                resultado = monto - (int)(monto * 0.2);
            }
            else
            {
                resultado = monto - (int)(monto * 0.1);
            }
            return resultado;
        }
    }
}
