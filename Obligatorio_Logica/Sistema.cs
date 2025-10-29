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
        // b . Dado un correo de usuario listar todos los pagos que realizó ese usuario (monto, descripción, tipo de gasto, método de pago) y si es recurrente mostrar cuants pagos quedan pendientes 
        // c . alta de usuario (nombre, apellido, contraseña, equipo) - 
        // d . dado un nombre de equipo, listar los usuarios que lo integran (nombre) 


        //Listar usuarios- LISTO (por ahora)

        // a . listado de usuarios (nombre, mail, grupo) - 
        public List<Usuario> listarUsuarios()
        {
            return _usuarios;
        }

        // precarga de datos
        /*
           para poder precargarlo con github copilot le dije " precargame datos de usuarios y equipos" le tuve que decir varias veces que primero los instancie en una variable y
           despues los agregue a la lista sino me los agregaba directamente 
        */

        public void precargaPagos()
        {
            if (_usuarios.Count < 4)
                precargaUsuarios();

            // Precarga de tipos de gasto
            Tipo_gasto tg1 = new Tipo_gasto("Comida", "Gastos de alimentación");
            Tipo_gasto tg2 = new Tipo_gasto("Transporte", "Gastos de transporte");
            Tipo_gasto tg3 = new Tipo_gasto("Servicios", "Gastos de servicios");
            Tipo_gasto tg4 = new Tipo_gasto("Entretenimiento", "Gastos de ocio");

            Usuario u1 = _usuarios[0];
            Usuario u2 = _usuarios[1];
            Usuario u3 = _usuarios[2];
            Usuario u4 = _usuarios[3];

            // Pagos únicos
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2023, 2, 10), 1001, 1500, "Supermercado", new List<Tipo_gasto> { tg1 }, u1));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2023, 3, 5), 1002, 800, "Taxi", new List<Tipo_gasto> { tg2 }, u2));
            altaPago(new PagoUnico(Pago.metodo_pago.EFECTIVO, new DateTime(2023, 4, 12), 1003, 1200, "Internet", new List<Tipo_gasto> { tg3 }, u3));
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2023, 5, 15), 1004, 2000, "Restaurante", new List<Tipo_gasto> { tg1 }, u4));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2023, 6, 18), 1005, 950, "Ómnibus", new List<Tipo_gasto> { tg2 }, u1));
            altaPago(new PagoUnico(Pago.metodo_pago.EFECTIVO, new DateTime(2023, 7, 20), 1006, 1100, "Luz", new List<Tipo_gasto> { tg3 }, u2));
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2023, 8, 22), 1007, 1700, "Cine", new List<Tipo_gasto> { tg4 }, u3));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2023, 9, 25), 1008, 1300, "Panadería", new List<Tipo_gasto> { tg1 }, u4));
            altaPago(new PagoUnico(Pago.metodo_pago.EFECTIVO, new DateTime(2023, 10, 28), 1009, 900, "Subte", new List<Tipo_gasto> { tg2 }, u1));
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2023, 11, 30), 1010, 2100, "Agua", new List<Tipo_gasto> { tg3 }, u2));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2023, 12, 2), 1011, 1600, "Teatro", new List<Tipo_gasto> { tg4 }, u3));
            altaPago(new PagoUnico(Pago.metodo_pago.EFECTIVO, new DateTime(2023, 1, 4), 1012, 1400, "Verdulería", new List<Tipo_gasto> { tg1 }, u4));
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2023, 2, 6), 1013, 1000, "Taxi", new List<Tipo_gasto> { tg2 }, u1));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2023, 3, 8), 1014, 1250, "Gas", new List<Tipo_gasto> { tg3 }, u2));
            altaPago(new PagoUnico(Pago.metodo_pago.EFECTIVO, new DateTime(2023, 4, 10), 1015, 1800, "Concierto", new List<Tipo_gasto> { tg4 }, u3));
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2023, 5, 12), 1016, 1550, "Carnicería", new List<Tipo_gasto> { tg1 }, u4));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2023, 6, 14), 1017, 1050, "Remise", new List<Tipo_gasto> { tg2 }, u1));
            altaPago(new PagoUnico(Pago.metodo_pago.EFECTIVO, new DateTime(2023, 7, 16), 1018, 1150, "Internet", new List<Tipo_gasto> { tg3 }, u2));
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2023, 8, 18), 1019, 1750, "Museo", new List<Tipo_gasto> { tg4 }, u3));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2023, 9, 20), 1020, 1350, "Supermercado", new List<Tipo_gasto> { tg1 }, u4));

            // Pagos recurrentes
            altaPago(new PagoRecurrente(500, "Netflix", new List<Tipo_gasto> { tg4 }, u1, new DateTime(2023, 1, 1), new DateTime(2023, 12, 1), 12, 12));
            altaPago(new PagoRecurrente(300, "Gimnasio", new List<Tipo_gasto> { tg4 }, u4, new DateTime(2023, 2, 15), new DateTime(2023, 7, 15), 6, 6));
            altaPago(new PagoRecurrente(400, "Spotify", new List<Tipo_gasto> { tg4 }, u2, new DateTime(2023, 3, 1), new DateTime(2023, 9, 1), 7, 7));
            altaPago(new PagoRecurrente(600, "Alquiler", new List<Tipo_gasto> { tg3 }, u3, new DateTime(2023, 4, 1), new DateTime(2023, 10, 1), 7, 7));
            altaPago(new PagoRecurrente(350, "Revista", new List<Tipo_gasto> { tg4 }, u1, new DateTime(2023, 5, 1), new DateTime(2023, 11, 1), 7, 7));
            altaPago(new PagoRecurrente(700, "Colegio", new List<Tipo_gasto> { tg3 }, u2, new DateTime(2023, 6, 1), new DateTime(2023, 12, 1), 7, 7));
            altaPago(new PagoRecurrente(800, "Seguro", new List<Tipo_gasto> { tg3 }, u3, new DateTime(2023, 7, 1), new DateTime(2024, 1, 1), 7, 7));
            altaPago(new PagoRecurrente(450, "Club", new List<Tipo_gasto> { tg4 }, u4, new DateTime(2023, 8, 1), new DateTime(2024, 2, 1), 7, 7));
            altaPago(new PagoRecurrente(550, "Netflix", new List<Tipo_gasto> { tg4 }, u1, new DateTime(2023, 9, 1), new DateTime(2024, 3, 1), 7, 7));
            altaPago(new PagoRecurrente(350, "Gimnasio", new List<Tipo_gasto> { tg4 }, u2, new DateTime(2023, 10, 1), new DateTime(2024, 4, 1), 7, 7));
            altaPago(new PagoRecurrente(400, "Spotify", new List<Tipo_gasto> { tg4 }, u3, new DateTime(2023, 11, 1), new DateTime(2024, 5, 1), 7, 7));
            altaPago(new PagoRecurrente(600, "Alquiler", new List<Tipo_gasto> { tg3 }, u4, new DateTime(2023, 12, 1), new DateTime(2024, 6, 1), 7, 7));
            altaPago(new PagoRecurrente(350, "Revista", new List<Tipo_gasto> { tg4 }, u1, new DateTime(2024, 1, 1), new DateTime(2024, 7, 1), 7, 7));
            altaPago(new PagoRecurrente(700, "Colegio", new List<Tipo_gasto> { tg3 }, u2, new DateTime(2024, 2, 1), new DateTime(2024, 8, 1), 7, 7));
            altaPago(new PagoRecurrente(800, "Seguro", new List<Tipo_gasto> { tg3 }, u3, new DateTime(2024, 3, 1), new DateTime(2024, 9, 1), 7, 7));
            altaPago(new PagoRecurrente(450, "Club", new List<Tipo_gasto> { tg4 }, u4, new DateTime(2024, 4, 1), new DateTime(2024, 10, 1), 7, 7));
            altaPago(new PagoRecurrente(550, "Netflix", new List<Tipo_gasto> { tg4 }, u1, new DateTime(2024, 5, 1), new DateTime(2024, 11, 1), 7, 7));
            altaPago(new PagoRecurrente(350, "Gimnasio", new List<Tipo_gasto> { tg4 }, u2, new DateTime(2024, 6, 1), new DateTime(2024, 12, 1), 7, 7));
            altaPago(new PagoRecurrente(400, "Spotify", new List<Tipo_gasto> { tg4 }, u3, new DateTime(2024, 7, 1), new DateTime(2025, 1, 1), 7, 7));
            altaPago(new PagoRecurrente(600, "Alquiler", new List<Tipo_gasto> { tg3 }, u4, new DateTime(2024, 8, 1), new DateTime(2025, 2, 1),7, 7));
        }
        public void precargaEquipo() 
        { 
            Equipo e1 = new Equipo("Los Pica Teclas");
            Equipo e2 = new Equipo("404 Not Found"); 
            Equipo e3 = new Equipo("Los Debuggers");
            Equipo e4 = new Equipo("Los Exception");

            AltaEquipo(e1);
            AltaEquipo(e2);
            AltaEquipo(e3);
            AltaEquipo(e4);
        }
        public void precargaUsuarios()
        {
            if (_equipo.Count < 4)
                precargaEquipo();

            Equipo equipo1 = _equipo[0];
            Equipo equipo2 = _equipo[1];
            Equipo equipo3 = _equipo[2];
            Equipo equipo4 = _equipo[3];

            Usuario u1 = new Usuario("Ana", "García", "pass1223", crearMail("Ana", "García"), equipo1, new DateTime(2023, 1, 15));
            Usuario u2 = new Usuario("Luis", "Pérez", "pass4562", crearMail("Luis", "Pérez"), equipo2, new DateTime(2022, 6, 10));
            Usuario u3 = new Usuario("María", "López", "pass7892", crearMail("María", "López"), equipo1, new DateTime(2023, 3, 5));
            Usuario u4 = new Usuario("Carlos", "Fernández", "pass3212", crearMail("Carlos", "Fernández"), equipo3, new DateTime(2021, 11, 20));
            Usuario u5 = new Usuario("Sofía", "Martínez", "pass6542", crearMail("Sofía", "Martínez"), equipo2, new DateTime(2022, 9, 30));
            Usuario u6 = new Usuario("Pedro", "Suárez", "pass1121", crearMail("Pedro", "Suárez"), equipo4, new DateTime(2022, 2, 14));
            Usuario u7 = new Usuario("Lucía", "Alonso", "pass2222", crearMail("Lucía", "Alonso"), equipo1, new DateTime(2021, 7, 19));
            Usuario u8 = new Usuario("Javier", "Méndez", "pass3332", crearMail("Javier", "Méndez"), equipo2, new DateTime(2023, 4, 2));
            Usuario u9 = new Usuario("Valentina", "Silva", "pass4442", crearMail("Valentina", "Silva"), equipo3, new DateTime(2022, 8, 8));
            Usuario u10 = new Usuario("Martín", "Ramos", "pass5552", crearMail("Martín", "Ramos"), equipo4, new DateTime(2021, 12, 25));
            Usuario u11 = new Usuario("Camila", "Torres", "pass6626", crearMail("Camila", "Torres"), equipo1, new DateTime(2022, 5, 17));
            Usuario u12 = new Usuario("Diego", "Sosa", "pass7727", crearMail("Diego", "Sosa"), equipo2, new DateTime(2023, 2, 11));
            Usuario u13 = new Usuario("Florencia", "Vega", "pass8288", crearMail("Florencia", "Vega"), equipo3, new DateTime(2022, 10, 3));
            Usuario u14 = new Usuario("Matías", "Cabrera", "pass9299", crearMail("Matías", "Cabrera"), equipo4, new DateTime(2021, 9, 27));
            Usuario u15 = new Usuario("Paula", "Ruiz", "pass0020", crearMail("Paula", "Ruiz"), equipo1, new DateTime(2022, 3, 21));
            Usuario u16 = new Usuario("Federico", "Gómez", "passabc2", crearMail("Federico", "Gómez"), equipo2, new DateTime(2023, 6, 6));
            Usuario u17 = new Usuario("Agustina", "Díaz", "passdef2", crearMail("Agustina", "Díaz"), equipo3, new DateTime(2022, 1, 13));
            Usuario u18 = new Usuario("Nicolás", "Pintos", "passghi2", crearMail("Nicolás", "Pintos"), equipo4, new DateTime(2021, 8, 5));
            Usuario u19 = new Usuario("Micaela", "Sánchez", "passjkl2", crearMail("Micaela", "Sánchez"), equipo1, new DateTime(2022, 11, 29));
            Usuario u20 = new Usuario("Rodrigo", "Castro", "passmno2", crearMail("Rodrigo", "Castro"), equipo2, new DateTime(2023, 5, 18));
            Usuario u21 = new Usuario("Julieta", "Morales", "passpqr2", crearMail("Julieta", "Morales"), equipo3, new DateTime(2022, 7, 23));
            Usuario u22 = new Usuario("Emiliano", "Bermúdez", "passstu2", crearMail("Emiliano", "Bermúdez"), equipo4, new DateTime(2021, 10, 12));

            altaUsuario(u1);
            altaUsuario(u2);
            altaUsuario(u3);
            altaUsuario(u4);
            altaUsuario(u5);
            altaUsuario(u6);
            altaUsuario(u7);
            altaUsuario(u8);
            altaUsuario(u9);
            altaUsuario(u10);
            altaUsuario(u11);
            altaUsuario(u12);
            altaUsuario(u13);
            altaUsuario(u14);
            altaUsuario(u15);
            altaUsuario(u16);
            altaUsuario(u17);
            altaUsuario(u18);
            altaUsuario(u19);
            altaUsuario(u20);
            altaUsuario(u21);
            altaUsuario(u22);
        }

        // b . Dado un correo de usuario listar todos los pagos que realizó ese usuario (monto, descripción, tipo de gasto, método de pago) y si es recurrente mostrar cuants pagos quedan pendientes

        /*
           para poder hacer esto primero tuve que crear un metodo que de el alta de los pagos
        */

        public void altaPago(Pago p) 
        {
            p.validaciones();
            if (_pago.Contains(p)) 
            {
                throw new Exception("El pago ya fue ingresado previamente"); 
            }
            _pago.Add(p);
        }


        public List<Pago> listarPagosPorMail(string email)
        {
            List<Pago> pagosUsuario = new List<Pago>();
            string emailBuscado = email.Trim().ToLower();
            foreach (Pago p in _pago)
            {
                if (p.Usuario != null && p.Usuario.Email.Trim().ToLower( ) == emailBuscado)
                {
                   pagosUsuario.Add(p);
                }

            }
            return pagosUsuario;
        }
        



        // c . alta de usuario (nombre, apellido, contraseña, equipo) - 
        /*
            para poder hacer el altaUsuario ademas tuve que agregar un metodo llamado " crearMail " que crea el Mail automaticamente
         */
        public void altaUsuario(Usuario u)
        {
            u.validar();
            if (_usuarios.Contains(u))
            {
                throw new Exception("El usuario ya existe");
            }
            
            _usuarios.Add(u); 
            
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


            if (apellidomin.Length <= 3)
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

        /*
            tambien ademas del altaEquipo tuve que crear el metodo exiteEquipo para que cuando se registrara el usuario se fije si el equipo existe
         */

        public void AltaEquipo(Equipo e)
        {

            e.validar();
            if (_equipo.Contains(e)) 
            {
                throw new Exception("El equipo ya existe");
            }
            else 
            { 
                _equipo.Add(e);
            }

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

        public List<Usuario> listarUsuariosPorEquipo(string nombre)
        {
            List<Usuario> Usuarios = new List<Usuario>();
            if (existeEquipo(nombre))
            {
                foreach (Usuario u in _usuarios)
                {
                    if (u.Equipo != null && u.Equipo.Nombre == nombre)
                    {
                        Usuarios.Add(u);
                    }
                }
            }


            return Usuarios; 
        }

    }
}
