using System;
using System.Collections.Generic;
using Obligatorio_Logica;

namespace ObligatorioProgramacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // instancia del sistema
            Sistema s = new Sistema(); 

            //precarga de datos
            s.precargaEquipo();
            s.precargaUsuarios();

            // Menu de opciones
            bool flag = true;
            while (flag)
            {
                MostrarOpciones();
                int opcion = SeleccionarMetodo();
                switch (opcion)
                {
                    case 1:
                        mostrarUsuarios(s);
                        Console.WriteLine();
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadLine();
                        break;
                    case 2:
                        break;

                    case 3: 
                        AltaUsuario(s);
                        Console.WriteLine();
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadLine();
                        break;


                    case 99:
                        flag = false;
                        break;
                }
           
            }
            
        }

        // Menú de opciones
        private static void MostrarOpciones()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Clear();
            Console.WriteLine("🌐 =============================== 🌐");
            Console.WriteLine("        📋   MENÚ PRINCIPAL   📋   ");
            Console.WriteLine("🌐 =============================== 🌐");
            Console.WriteLine(" 👤  1) Listar Usuarios");
            Console.WriteLine(" 💳  2) Listar pagos de usuario por mail");
            Console.WriteLine(" 🆕  3) Alta de usuario");
            Console.WriteLine(" 👥  4) Listar usuarios de un equipo");
            Console.WriteLine();
            Console.WriteLine(" ❌  99) Salir");
            Console.WriteLine("🌐 =============================== 🌐");
        }

        // Selección de opción
        private static int SeleccionarMetodo()
        {
            Console.Write("👉 Seleccione una opción: ");
            int.TryParse(Console.ReadLine(), out int opcion);
            return opcion;
        }


        // a . listado de usuarios (nombre, mail, grupo) 
        static void mostrarUsuarios(Sistema sistema)
        {
            List<Usuario> usuarios = sistema.listarUsuarios();

            Console.WriteLine("----------LISTADO DE USUARIOS----------");
            if (usuarios.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados");
            }
            else
            {
                foreach (Usuario usuario in usuarios)
                {
                    Console.WriteLine("Nombre: " + usuario.Nombre + "Email: " + usuario.Email + "Grupo: " + usuario.Equipo.Nombre);
                }
            }
            Console.WriteLine("----------LISTADO DE USUARIOS----------");
        }

        // b . dado un correo, listar los pagos realizados por ese usuario (monto, descripción, tipo de gasto, método de pago) y si es recurrente mostrar cuants pagos quedan pendientes

        static void ListarPagosPorUsuario(Sistema s)
        {
            
        }



        // c . alta de usuario (nombre, apellido, contraseña, equipo) -
        static void AltaUsuario(Sistema s)
        {
            Console.WriteLine("Ingrese los datos solicitados:");
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Apellido: ");
            string apellido = Console.ReadLine();
            Console.WriteLine("Contraseña: ");
            string contrasenia = Console.ReadLine();
            string Email = s.crearMail(nombre, apellido);
            Console.WriteLine("Email generado: " + Email);
            Console.WriteLine("Equipo: ");
            string equipo = Console.ReadLine();
            s.existeEquipo(equipo);
            DateTime fecha_Inicio = DateTime.Now;

            Equipo e = new Equipo(equipo);
            Usuario u = new Usuario(nombre, apellido, contrasenia, Email, e, fecha_Inicio);

            try
            {
                s.altaUsuario(u);
                Console.WriteLine("Usuario agregado con éxito");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar usuario: " + ex.Message);
            }

        }
    }
}