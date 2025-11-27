using System;
using Obligatorio_Logica;
using Obligatorio_Logica.Entidades;
using System.Collections.Generic;

namespace Obligatorio_Consola
{
    internal class Program
    {
        private static Sistema sistema = Sistema.Instancia;

        static void Main(string[] args)
        {
            bool seguir = true;

            while (seguir)
            {
                MostrarMenu();
                int opcion = SeleccionarOpcion();

                switch (opcion)
                {
                    case 1:
                        ListarUsuarios();
                        break;
                    case 2:
                        ListarPagosPorCorreo();
                        break;
                    case 3:
                        AltaDeUsuario();
                        break;
                    case 4:
                        MostrarUsuariosPorEquipo();
                        break;
                    case 99:
                        seguir = false;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

                if (seguir)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("=========== SISTEMA DE PAGOS ===========");
            Console.WriteLine("1 - Listar todos los usuarios");
            Console.WriteLine("2 - Listar pagos por correo de usuario");
            Console.WriteLine("3 - Alta de usuario");
            Console.WriteLine("4 - Listar usuarios de un equipo");
            Console.WriteLine("99 - Salir");
            Console.WriteLine("========================================");
        }

        private static int SeleccionarOpcion()
        {
            Console.Write("Seleccione una opción: ");
            int.TryParse(Console.ReadLine(), out int opcion);
            return opcion;
        }

        // a) Listar todos los usuarios
        private static void ListarUsuarios()
        {
            try
            {
                var usuarios = sistema.listarUsuarios();
                if (usuarios.Count == 0)
                {
                    Console.WriteLine("No hay usuarios registrados.");
                    return;
                }

                Console.WriteLine("NOMBRE EMAIL GRUPO");
                Console.WriteLine("------------------------------------------");
                foreach (var u in usuarios)
                {
                    Console.WriteLine($"{u.Nombre} {u.Apellido} {u.Email} {u.Equipo.Nombre}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar usuarios: {ex.Message}");
            }
        }

        // b) Dado un correo, listar pagos del usuario
        private static void ListarPagosPorCorreo()
        {
            try
            {
                Console.Write("Ingrese el correo del usuario: ");
                string email = Console.ReadLine();

                var pagos = sistema.listarPagosPorMail(email);

                if (pagos.Count == 0)
                {
                    Console.WriteLine("No se encontraron pagos para ese usuario.");
                    return;
                }

                Console.WriteLine("PAGOS DEL USUARIO:");
                Console.WriteLine("------------------------------------------");
                foreach (var p in pagos)
                {
                    Console.WriteLine($"{p.Descripcion} - ${p.Monto} - {p.Tipo.Nombre} - {p.Metodo}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar pagos: {ex.Message}");
            }
        }

        // c) Alta de usuario
        private static void AltaDeUsuario()
        {
            try
            {
                Console.Write("Ingrese nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese apellido: ");
                string apellido = Console.ReadLine();
                Console.Write("Ingrese contraseña: ");
                string pass = Console.ReadLine();
                Console.Write("Ingrese nombre del equipo: ");
                string nombreEquipo = Console.ReadLine();

                if (!sistema.existeEquipo(nombreEquipo))
                {
                    Console.WriteLine("El equipo no existe. Debe crear el equipo primero.");
                    return;
                }

                Equipo equipo = null;
                foreach (Equipo e in sistema.Equipos)
                {
                    if (e.Nombre == nombreEquipo)
                    {
                        equipo = e;
                        break;
                    }
                }

                string email = sistema.crearMail(nombre, apellido);
                Usuario u = new Usuario(nombre, apellido, pass, email, equipo, DateTime.Now, Cargo.EMPLEADO);

                sistema.altaUsuario(u);
                Console.WriteLine($"✅ Usuario {nombre} agregado con éxito. Email generado: {email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al dar de alta el usuario: {ex.Message}");
            }
        }

        // d) Dado un nombre de equipo, mostrar los usuarios del equipo
        private static void MostrarUsuariosPorEquipo()
        {
            try
            {
                Console.Write("Ingrese el nombre del equipo: ");
                string nombreEquipo = Console.ReadLine();

                if (!sistema.existeEquipo(nombreEquipo))
                {
                    Console.WriteLine("El equipo no existe.");
                    return;
                }

                Console.WriteLine($"Usuarios del equipo {nombreEquipo}:");
                Console.WriteLine("------------------------------------------");

                foreach (var u in sistema.Usuarios)
                {
                    if (u.Equipo.Nombre.Equals(nombreEquipo))
                    {
                        Console.WriteLine($"{u.Nombre} {u.Apellido} - {u.Email}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar usuarios del equipo: {ex.Message}");
            }
        }
    }
}
