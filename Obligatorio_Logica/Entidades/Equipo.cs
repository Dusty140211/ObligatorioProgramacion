using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Logica
{
    public class Equipo
    {
        private int _id;
        private string _nombre;

        public static int contador = 0;

        public int Id
        {
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public Equipo(string nombre)
        {
            contador++;
            this._id = contador;
            this._nombre = nombre;
        }

        public override string ToString()
        {
            return $"ID: {_id} | Nombre del equipo: {_nombre}";
        }
        public void validar() 
        {
            validarNombre(); 
        }
        public void validarNombre()
        {
            if (string.IsNullOrWhiteSpace(_nombre)) throw new Exception("el nombre no puede estar vacio"); 
        }
    }
}
