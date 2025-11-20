using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Logica
{
    public class PagoRecurrente : Pago
    {
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private int _cuotasPagas;
        private int _cuotas;
        private int _PagosPendientes; 

        public int PagosPendientes 
        { 
            get { return _PagosPendientes; }
            set { _PagosPendientes = value;  }
        }
        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }

        public int cuotaspagas
        {
            get { return _cuotasPagas; }
            set { _cuotasPagas = value; }
        }

        public int Cuotas
        {
            get { return _cuotas; }
            set { _cuotas = value; }
        }

        public PagoRecurrente(double monto, metodo_pago metodo, string descripcion, Tipo_gasto tipo, Usuario usuario, DateTime fechaInicio, DateTime fechaFin, int pagosPagas, int cuotas)
            : base(metodo ,monto, descripcion, tipo, usuario)
        {
            this._fechaInicio = fechaInicio;
            this._fechaFin = fechaFin;
            this._cuotasPagas = cuotaspagas;
            this._cuotas = cuotas;
        }

        public override string ToString()
        {
            return $"PagoRecurrente: FechaInicio={FechaInicio}, FechaFin={FechaFin}, cuotas Pagas = {cuotaspagas}, Cuotas={Cuotas}, Monto={Monto}, Descripción={Descripcion}";
        }

        public void calcularPagosPendientes()
        {
            _PagosPendientes = _cuotas - _cuotasPagas;
        }
    }
}
