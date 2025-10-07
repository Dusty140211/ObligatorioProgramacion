using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Logica
{
    public class Usuario
    {
        private string nombre;
        private string apellido;
        private string contrasenia;
        private string email;
        private Equipo equipo; // El usuario tiene un equipo asociado
        private DateTime fecha_Inicio; 

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Equipo Equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }

        public DateTime Fecha_Inicio
        {
            get { return fecha_Inicio; }
            set { fecha_Inicio = value; }
        }

        public Usuario(string nombre, string apellido, string contrasenia, string email, Equipo equipo, DateTime fecha_Inicio)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.contrasenia = contrasenia;
            this.email = email;
            this.equipo = equipo;
            this.fecha_Inicio = fecha_Inicio;
        }

        public static bool validarNombre(string nombre) 
        {
            if (string.IsNullOrWhiteSpace(nombre)) return false;
            return true; 
        }

        public static bool validarApellido(string apellido) 
        {
            if (string.IsNullOrWhiteSpace(apellido)) return false;
            return true; 
        }


        public static bool validarContrasenia(string contrasenia) 
        {
            if (string.IsNullOrWhiteSpace(contrasenia))
            {
                return false;
            }

            if (contrasenia.Length < 8) 
            {
                return false;
            }

            return true;
        }
    }
}
    