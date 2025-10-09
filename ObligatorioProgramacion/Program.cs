using System;
using System.Collections.Generic;
using Obligatorio_Logica;

namespace ObligatorioProgramacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = new Sistema();
            bool flag = true;
            
            while (flag)
            {
                MostrarOpciones();
                int opcion = SeleccionarMetodo();
                switch (opcion)
                {
                    case 1:
                        mostrarUsuarios(sistema);
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

        private static void MostrarOpciones()
        {
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

        private static int SeleccionarMetodo()
        {
            Console.Write("👉 Seleccione una opción: ");
            int.TryParse(Console.ReadLine(), out int opcion);
            return opcion;
        }

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
                    Console.WriteLine(usuario);
                }
            }
            Console.WriteLine("----------LISTADO DE USUARIOS----------");
        }
    }
}