using Obligatorio_Logica.Entidades;
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

        public PagoRecurrente(metodoPago metodo, DateTime fechaInicio, DateTime fechaFin, string descripcion, int cuotaspagas, int cuotas, double monto, Tipo_gasto tipo, Usuario usuario)
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

        public override double CalcularMontoConBeneficioORecargo()
        {
            double montoFinal = Monto;

            if (_cuotas == 0) 
            {
                montoFinal *= 1.03; 
            }
            else if (_cuotas > 10)
            {
                montoFinal *= 1.10; 
            }
            else if (_cuotas >= 6 && _cuotas <= 9)
            {
                montoFinal *= 1.05; 
            }
            else if (_cuotas <= 5)
            {
                montoFinal *= 1.03; 
            }

            return montoFinal;
        }
    }
}
