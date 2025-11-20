using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Logica
{
    public class PagoUnico : Pago
    {
        private DateTime _fecha;
        private decimal _nroRecibo;
       

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public decimal NroRecibo
        {
            get { return _nroRecibo; }
            set { _nroRecibo = value; }
        }


        public PagoUnico(metodo_pago metodo, DateTime fecha, decimal nroRecibo, double monto, string descripcion, Tipo_gasto tipo, Usuario usuario) :
            base(metodo, monto, descripcion, tipo, usuario)
        {
           
            this._fecha = fecha;
            this._nroRecibo = nroRecibo;
        }

        public override string ToString()
        {
            return $"Pago Único - {base.ToString()}, Fecha: {Fecha:dd/MM/yyyy}, Nro. Recibo: {NroRecibo}";
        }

    }
}
