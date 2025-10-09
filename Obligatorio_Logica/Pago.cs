using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Logica
{
    public class Pago
    {
        public enum metodo_pago { CREDITO = 1, DEBITO = 2, EFECTIVO = 3 }

        private int _id;
        private double _monto;
        private string _descripcion;
        private Tipo_gasto _tipo;
        private Usuario _usuario;

        public metodo_pago Metodo { get; set; }

        public static int contador = 0;
        public int Id
        {
            get { return _id; }
        }

        public double Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public metodo_pago metodo
        {
            get { return metodo; }
            set { metodo = value; }
        }

        public Tipo_gasto Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }



        public Pago(double monto, string descripcion, List<Tipo_gasto> tipo, Usuario usuario)
        {
            contador++;
            this._id = contador;
            this._monto = monto;
            this._descripcion = descripcion;
            this._usuario = usuario;
        }

        public void validaciones() 
        {
            validarMonto();
            validarDescripcion(); 
        }

        public void validarMonto() 
        {
            if (_monto > 0) throw new Exception("El monto debe ser mayor a 0"); 
        }

        public void validarDescripcion() 
        {
            if (string.IsNullOrEmpty(_descripcion)) throw new Exception("La descripcion no puede estar vacia"); 
        }


    }
}
