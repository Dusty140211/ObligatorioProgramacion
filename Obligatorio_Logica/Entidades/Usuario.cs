using Obligatorio_Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Logica
{
    public class Usuario
    {
        private string _nombre;
        private string _apellido; 
        private string _contrasenia;
        private string _email;
        public Cargo _rol;  
        private Equipo _equipo; 
        private DateTime _fecha_Inicio;

        public Cargo Rol // ES ENUM 
        {
            get { return _rol; }
            set { _rol = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Contrasenia
        {
            get { return _contrasenia; }
            set { _contrasenia = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

    

        public Equipo Equipo
        {
            get { return _equipo; }
            set { _equipo = value; }
        }

        public DateTime Fecha_Inicio
        {
            get { return _fecha_Inicio; }
            set { _fecha_Inicio = value; }
        }

        public Usuario(string nombre, string apellido, string contrasenia, string email, Equipo equipo, DateTime fecha_Inicio, Cargo rol)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._contrasenia = contrasenia;
            this._email = email;
            this._equipo = equipo;
            this._fecha_Inicio = fecha_Inicio;
            this._rol = rol;
        }

        public void validar() 
        {
            validarNombre();
            validarApellido();
            validarContrasenia(); 
        }

        public void validarNombre()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede estar vacio") ;

        }

        public void validarApellido()
        {
            if (string.IsNullOrEmpty(_apellido)) throw new Exception("El apellido no puede estar vacio"); 
        }


        public void validarContrasenia()
        {
            if (string.IsNullOrEmpty(_contrasenia)) throw new Exception("La contraseña no puede estar vacia");
            if (_contrasenia.Length < 8) throw new Exception("La contraseña no puede tener menos de 8 caracteres"); 

            
        }

        public void validarEmail() {
            if (string.IsNullOrEmpty(_email)) throw new Exception("el email no puede ser nulo");
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} {Apellido}, " +
                   $"Email: {Email}, " +
                   $"Equipo: {Equipo.Nombre}, " +
                   $"Fecha de inicio: {Fecha_Inicio.Day + "/" + Fecha_Inicio.Month + "/" + Fecha_Inicio.Year}";
        }
    }
}
