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
        private int cuotasPagas;
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

        public int cuotaspagas
        {
            get { return cuotasPagas; }
            set { cuotasPagas = value; }
        }

        public int Cuotas
        {
            get { return cuotas; }
            set { cuotas = value; }
        }

        public PagoRecurrente(double monto, string descripcion, List<Tipo_gasto> tipo, Usuario usuario, DateTime fechaInicio, DateTime fechaFin, int pagosPagas, int cuotas)
            : base(monto, descripcion, tipo, usuario)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.cuotaspagas = cuotaspagas;
            this.cuotas = cuotas;
        }

        public override string ToString()
        {
            return $"PagoRecurrente: FechaInicio={FechaInicio}, FechaFin={FechaFin}, cuotas Pagas = {cuotaspagas}, Cuotas={Cuotas}, Monto={Monto}, Descripción={Descripcion}";
        }

        public int calcularPagosPendientes()
        {
            return cuotas - cuotasPagas; 
        }
    }
}
