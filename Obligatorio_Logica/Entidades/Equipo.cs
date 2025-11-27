using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Logica
{
    public class Equipo
    {
        private int id;
        private string nombre;

        public static int contador = 0;

        public int Id
        {
            get { return id; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Equipo(string nombre)
        {
            contador++;
            this.id = contador;
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return $"ID: {id} | Nombre del equipo: {nombre}";
        }
        public void validar() 
        {
            validarNombre(); 
        }
        public void validarNombre()
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("el nombre no puede estar vacio"); 
        }
    }
}
