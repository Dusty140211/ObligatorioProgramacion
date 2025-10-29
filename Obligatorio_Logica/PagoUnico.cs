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
        public metodo_pago Metodo { get; set; }

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


        public PagoUnico(metodo_pago metodo, DateTime fecha, decimal nroRecibo, double monto, string descripcion, List<Tipo_gasto> tipo, Usuario usuario) :
            base(monto, descripcion, tipo, usuario)
        {
            this.Metodo = metodo;
            this._fecha = fecha;
            this._nroRecibo = nroRecibo;
        }

        public override string ToString()
        {
            return $"Pago Único - {base.ToString()}, Fecha: {Fecha:dd/MM/yyyy}, Nro. Recibo: {NroRecibo}";
        }

    }
}
