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
        // b . dado un correo, listar los pagos realizados por ese usuario (monto, descripción, tipo de gasto, método de pago)
        // c . alta de usuario (nombre, apellido, contraseña, equipo) - 
        // d . dado un nombre de equipo, listar los usuarios que lo integran (nombre, mail) 


        //Listar usuarios- LISTO (por ahora)

        public int contadorListaUsuarios()
        {
            int contador = 0;
            if (_usuarios.Count > 0)
            {
                contador++;

            }
            return contador;
        }

        public List<Usuario> listarUsuarios()
        {
            return _usuarios;
        }

        public void AgregarUsuario(string nombre, string apellido, string contrasenia, Equipo e, DateTime fecha)
        {

            if (Usuario.validarNombre(nombre) && Usuario.validarApellido(apellido) && Usuario.validarContrasenia(contrasenia))
            {
                string nom = nombre.ToLower().Substring(0, 2);
                string ape = apellido.ToLower().Substring(0, 2);

                string email = nom + ape + "@laEmpresa.com";

                if (verificarMail(email) == true)
                {
                    if (Usuario.validarNombre(nombre) && Usuario.validarApellido(apellido) && Usuario.validarContrasenia(contrasenia))
                    {
                        Usuario atributo = new Usuario(nombre, apellido, contrasenia, email, e, fecha);
                        _usuarios.Add(atributo);
                    }
                }
            }
        }

        public void AgregarEquipo(string nombre)
        {

            if (Equipo.validarNombre(nombre))
            {
                _equipo.Add(new Equipo(nombre));
            }

        }

        public bool verificarMail(string email)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u.Email == email)
                {
                    return false;
                }

            }
            return true;
        }
    }
}
