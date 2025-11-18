using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Logica
{
    public class Tipo_gasto
    {
        private string nombre;
        private string description;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Tipo_gasto(string nombre, string description)
        {
            this.nombre = nombre;
            this.description = description;
        }


    }
}
