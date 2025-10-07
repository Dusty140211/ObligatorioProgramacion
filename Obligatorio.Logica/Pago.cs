using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Logica
{
    public class Pago
    {
        public enum metodo_pago { CREDITO = 1, DEBITO = 2, EFECTIVO = 3 }

        private int id;
        private double monto;
        private string descripcion;
        private Tipo_gasto tipo;
        private Usuario usuario; 

        public metodo_pago Metodo { get; set; }

        public static int contador = 0;
        public int Id
        {
            get { return id; }
        }

        public double Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public metodo_pago metodo
        {
            get { return metodo; }
            set { metodo = value; }
        }

        public Tipo_gasto Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }



        public Pago(double monto, string descripcion, List<Tipo_gasto> tipo, Usuario usuario)
        {
            contador++; 
            this.id = contador;
            this.monto = monto;
            this.descripcion = descripcion;
            this.usuario = usuario;
        }

        public void metodoPago(string texto)
        {
            texto = texto.Trim().ToUpper();

            if (texto == "CREDITO") Metodo = metodo_pago.CREDITO;
            else if (texto == "DEBITO") Metodo = metodo_pago.DEBITO;
            else if (texto == "EFECTIVO") Metodo = metodo_pago.EFECTIVO;
        }



    }
}
