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


        public List<Usuario> listarUsuarios()
        {
            return _usuarios;
        }

        public void precarga() { }

        public void altaUsuario(Usuario u)
        {
            u.validar();
            if (_usuarios.Contains(u))
            {
                throw new Exception("El usuario ya existe");
            }
            
            _usuarios.Add(u); 
            
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
