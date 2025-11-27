using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Obligatorio_Logica
{
    public class Tipo_gasto
    {
        private string _nombre;
        private string _descripcion;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Description
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public Tipo_gasto(string nombre, string description)
        {
            this._nombre = nombre;
            this._descripcion = description;
        }

        public void Validar() 
        {
            validarDescripcion(); 
            validarNombre();
        }

        public void validarDescripcion() 
        {
            if (string.IsNullOrEmpty(_descripcion)) throw new Exception("La descripcion no puede estar vacio");
        }

        public void validarNombre() 
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede estar vacio");
        }
        

    }
}
