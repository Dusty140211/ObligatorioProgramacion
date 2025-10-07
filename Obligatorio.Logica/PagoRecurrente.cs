using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Logica
{
    public class PagoRecurrente : Pago
    {
        private DateTime fechaInicio;
        private DateTime fechaFin;
        
        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        public PagoRecurrente(double monto, string descripcion, List<Tipo_gasto> tipo, Usuario usuario, DateTime fechaInicio, DateTime fechaFin)
            : base(monto, descripcion, tipo, usuario)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
        }


    }
}
