using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_Logica
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Equipo> _equipo = new List<Equipo>();
        private List<Pago> _pago = new List<Pago>();

        // a . listado de usuarios (nombre, mail, grupo) - 
        // b . dado un correo, listar los pagos realizados por ese usuario (monto, descripción, tipo de gasto, método de pago) y si es recurrente mostrar cuants pagos quedan pendientes 
        // c . alta de usuario (nombre, apellido, contraseña, equipo) - 
        // d . dado un nombre de equipo, listar los usuarios que lo integran (nombre, mail) 


        //Listar usuarios- LISTO (por ahora)

        // a . listado de usuarios (nombre, mail, grupo) - 
        public List<Usuario> listarUsuarios()
        {
            return _usuarios;
        }

        // precarga de equipos y usuarios
        public void precargaEquipo() 
        { 
            Equipo e1 = new Equipo("Los Pica Teclas");
            Equipo e2 = new Equipo("404 Not Found"); 
            Equipo e3 = new Equipo("Los Debuggers");
            Equipo e4 = new Equipo("Los Exception");
            Equipo e5 = new Equipo("Los Improvisados");

            AltaEquipo(e1);
            AltaEquipo(e2);
            AltaEquipo(e3);
            AltaEquipo(e4);
            AltaEquipo(e5);
        }
        public void precargaUsuarios()
        {
            // Asegúrate de que los equipos ya estén precargados
            if (_equipo.Count == 0)
                precargaEquipo();

            // Acceso directo por índice
            Equipo equipo1 = _equipo[0]; 
            Equipo equipo2 = _equipo[1];
            Equipo equipo3 = _equipo[2]; 

            // precarga de datos de los usuarios
            Usuario u1 = new Usuario(
                "Ana", "García", "pass123", crearMail("Ana", "García"), equipo1, new DateTime(2023, 1, 15));
            Usuario u2 = new Usuario(
                "Luis", "Pérez", "pass456", crearMail("Luis", "Pérez"), equipo2, new DateTime(2022, 6, 10));
            Usuario u3 = new Usuario(
                "María", "López", "pass789", crearMail("María", "López"), equipo1, new DateTime(2023, 3, 5));
            Usuario u4 = new Usuario(
                "Carlos", "Fernández", "pass321", crearMail("Carlos", "Fernández"), equipo3, new DateTime(2021, 11, 20));
            Usuario u5 = new Usuario(
                "Sofía", "Martínez", "pass654", crearMail("Sofía", "Martínez"), equipo2, new DateTime(2022, 9, 30));

            altaUsuario(u1);
            altaUsuario(u2);
            altaUsuario(u3);
            altaUsuario(u4);
            altaUsuario(u5);
        }


        // c . alta de usuario (nombre, apellido, contraseña, equipo) - 
        public void altaUsuario(Usuario u)
        {
            u.validar();
            if (_usuarios.Contains(u))
            {
                throw new Exception("El usuario ya existe");
            }
            
            _usuarios.Add(u); 
            
        }
        public void AltaEquipo(Equipo e)
        {

            e.validar(); 

        }


        public string crearMail(string nombre, string apellido)
        {
            int cont = 0;
            string nombremin = nombre.ToLower();
            string apellidomin = apellido.ToLower();

            string email = "";
            if (nombremin.Length <= 3)
            {
                email += nombremin;

            }
            else
            {
                email += nombremin.Substring(0, 3);
            }


            if (apellidomin.Length < 3)
            {
                email += apellidomin;
            }
            else 
            {
                email += apellidomin.Substring(0, 3);
            }


            foreach (Usuario u in _usuarios)
            {
               if (u.Email.Contains(email))
                  {
                     cont++; 
                  }
            }

            email += cont + "@Empresa.com";
            return email; 
        }

        public bool existeEquipo(string nombre) 
        {
            bool existe = false;
            foreach(Equipo e in _equipo) 
            {
                if (e.Nombre == nombre)
                {
                    existe = true;     
                }
            
            }
            return existe;
        }
    }
}
