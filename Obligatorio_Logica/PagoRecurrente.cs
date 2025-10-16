using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Logica
{
    public class PagoRecurrente : Pago
    {
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private int pagosPendientes;
        private int cuotas;

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

        public int PagosPendientes
        {
            get { return pagosPendientes; }
            set { pagosPendientes = value; }
        }

        public int Cuotas
        {
            get { return cuotas; }
            set { cuotas = value; }
        }

        public PagoRecurrente(double monto, string descripcion, List<Tipo_gasto> tipo, Usuario usuario, DateTime fechaInicio, DateTime fechaFin, int pagosPendientes, int cuotas)
            : base(monto, descripcion, tipo, usuario)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.pagosPendientes = pagosPendientes;
            this.cuotas = cuotas;
        }


    }
}
