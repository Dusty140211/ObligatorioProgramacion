using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Obligatorio.Logica.Pago;

namespace Obligatorio.Logica
{
    public class Sistema
    {
        private List<Usuario> usuario = new List<Usuario>();
        private List<Equipo> equipo = new List<Equipo>();
        private List<Pago> pago = new List<Pago>();

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
                        usuario.Add(atributo);
                    }
                }
            }
        }

        public void AgregarEquipo(string nombre) 
        { 
        
            if (Equipo.validarNombre(nombre))
            {
                equipo.Add(new Equipo(nombre));
            }

        }

        public void agregarPagoUnico() 
        { 
            
        }


        public bool verificarMail(string email) 
        {
            foreach(Usuario u in usuario) 
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
