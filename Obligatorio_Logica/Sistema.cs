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
        public static Sistema s_instancia; 

        public List<Usuario> Usuarios { get { return new List<Usuario>(_usuarios);  } }
        public List<Equipo> Equipos { get { return new List<Equipo>(_equipo);  } }
        public List<Pago> Pagos { get { return new List<Pago>(_pago); } }
        // a . listado de usuarios (nombre, mail, grupo) - 
        // b . Dado un correo de usuario listar todos los pagos que realizó ese usuario (monto, descripción, tipo de gasto, método de pago) y si es recurrente mostrar cuants pagos quedan pendientes 
        // c . alta de usuario (nombre, apellido, contraseña, equipo) - 
        // d . dado un nombre de equipo, listar los usuarios que lo integran (nombre) 

        // instanciamos sistema para poder acceder desde los controllers
        public static Sistema Instancia
        {
            get
            {
                if (s_instancia == null)
                {
                    s_instancia = new Sistema();
                }
                return s_instancia;
            }
        }

        public Sistema()
        {
            _usuarios = new List<Usuario>();
            _equipo = new List<Equipo>();
            _pago = new List<Pago>();
            precargaEquipo();
            precargaUsuarios();
            precargaPagos();

            

        }


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
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2025, 11, 1), 1101, 1800, "Supermercado", new List<Tipo_gasto> { tg1 }, u1));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2025, 11, 2), 1102, 950, "Taxi", new List<Tipo_gasto> { tg2 }, u2));
            altaPago(new PagoUnico(Pago.metodo_pago.EFECTIVO, new DateTime(2025, 11, 3), 1103, 1300, "Gas", new List<Tipo_gasto> { tg3 }, u3));
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2025, 11, 4), 1104, 2100, "Cine", new List<Tipo_gasto> { tg4 }, u4));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2025, 11, 5), 1105, 1200, "Panadería", new List<Tipo_gasto> { tg1 }, u1));
            altaPago(new PagoUnico(Pago.metodo_pago.EFECTIVO, new DateTime(2025, 11, 6), 1106, 1000, "Ómnibus", new List<Tipo_gasto> { tg2 }, u2));
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2025, 11, 7), 1107, 1600, "Luz", new List<Tipo_gasto> { tg3 }, u3));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2025, 11, 8), 1108, 1900, "Teatro", new List<Tipo_gasto> { tg4 }, u4));
            altaPago(new PagoUnico(Pago.metodo_pago.EFECTIVO, new DateTime(2025, 11, 9), 1109, 1400, "Verdulería", new List<Tipo_gasto> { tg1 }, u1));
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2025, 11, 10), 1110, 950, "Remise", new List<Tipo_gasto> { tg2 }, u2));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2025, 11, 11), 1111, 1100, "Internet", new List<Tipo_gasto> { tg3 }, u3));
            altaPago(new PagoUnico(Pago.metodo_pago.EFECTIVO, new DateTime(2025, 11, 12), 1112, 1700, "Museo", new List<Tipo_gasto> { tg4 }, u4));
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2025, 11, 13), 1113, 1350, "Carnicería", new List<Tipo_gasto> { tg1 }, u1));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2025, 11, 14), 1114, 1050, "Subte", new List<Tipo_gasto> { tg2 }, u2));
            altaPago(new PagoUnico(Pago.metodo_pago.EFECTIVO, new DateTime(2025, 11, 15), 1115, 1150, "Agua", new List<Tipo_gasto> { tg3 }, u3));
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2025, 11, 16), 1116, 1750, "Concierto", new List<Tipo_gasto> { tg4 }, u4));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2025, 11, 17), 1117, 1550, "Supermercado", new List<Tipo_gasto> { tg1 }, u1));
            altaPago(new PagoUnico(Pago.metodo_pago.EFECTIVO, new DateTime(2025, 11, 18), 1118, 1000, "Taxi", new List<Tipo_gasto> { tg2 }, u2));
            altaPago(new PagoUnico(Pago.metodo_pago.CREDITO, new DateTime(2025, 11, 19), 1119, 1250, "Gas", new List<Tipo_gasto> { tg3 }, u3));
            altaPago(new PagoUnico(Pago.metodo_pago.DEBITO, new DateTime(2025, 11, 20), 1120, 1800, "Cine", new List<Tipo_gasto> { tg4 }, u4));

            // Pagos recurrentes
            altaPago(new PagoRecurrente(550, "Netflix", new List<Tipo_gasto> { tg4 }, u1, new DateTime(2025, 11, 1), new DateTime(2026, 5, 1), 7, 7));
            altaPago(new PagoRecurrente(300, "Gimnasio", new List<Tipo_gasto> { tg4 }, u2, new DateTime(2025, 11, 2), new DateTime(2026, 5, 2), 7, 7));
            altaPago(new PagoRecurrente(400, "Spotify", new List<Tipo_gasto> { tg4 }, u3, new DateTime(2025, 11, 3), new DateTime(2026, 5, 3), 7, 7));
            altaPago(new PagoRecurrente(600, "Alquiler", new List<Tipo_gasto> { tg3 }, u4, new DateTime(2025, 11, 4), new DateTime(2026, 5, 4), 7, 7));
            altaPago(new PagoRecurrente(350, "Revista", new List<Tipo_gasto> { tg4 }, u1, new DateTime(2025, 11, 5), new DateTime(2026, 5, 5), 7, 7));
            altaPago(new PagoRecurrente(700, "Colegio", new List<Tipo_gasto> { tg3 }, u2, new DateTime(2025, 11, 6), new DateTime(2026, 5, 6), 7, 7));
            altaPago(new PagoRecurrente(800, "Seguro", new List<Tipo_gasto> { tg3 }, u3, new DateTime(2025, 11, 7), new DateTime(2026, 5, 7), 7, 7));
            altaPago(new PagoRecurrente(450, "Club", new List<Tipo_gasto> { tg4 }, u4, new DateTime(2025, 11, 8), new DateTime(2026, 5, 8), 7, 7));
            altaPago(new PagoRecurrente(550, "Netflix", new List<Tipo_gasto> { tg4 }, u1, new DateTime(2025, 11, 9), new DateTime(2026, 5, 9), 7, 7));
            altaPago(new PagoRecurrente(350, "Gimnasio", new List<Tipo_gasto> { tg4 }, u2, new DateTime(2025, 11, 10), new DateTime(2026, 5, 10), 7, 7));
            altaPago(new PagoRecurrente(400, "Spotify", new List<Tipo_gasto> { tg4 }, u3, new DateTime(2025, 11, 11), new DateTime(2026, 5, 11), 7, 7));
            altaPago(new PagoRecurrente(600, "Alquiler", new List<Tipo_gasto> { tg3 }, u4, new DateTime(2025, 11, 12), new DateTime(2026, 5, 12), 7, 7));
            altaPago(new PagoRecurrente(350, "Revista", new List<Tipo_gasto> { tg4 }, u1, new DateTime(2025, 11, 13), new DateTime(2026, 5, 13), 7, 7));
            altaPago(new PagoRecurrente(700, "Colegio", new List<Tipo_gasto> { tg3 }, u2, new DateTime(2025, 11, 14), new DateTime(2026, 5, 14), 7, 7));
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

            // Cambiamos a el usuario 1 a gerente
            u1.cambiarRol(Usuario.Cargo.Gerente);

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
                if (p.Usuario.Email.Trim().ToLower( ) == emailBuscado)
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
                    if ( u.Equipo.Nombre == nombre)
                    {
                        Usuarios.Add(u);
                    }
                }
            }


            return Usuarios; 
        }

        // Login de la aplicacion

        //para el login necesito un metodo que busque el usuario con el mail
        public Usuario BuscarporMail(string email)
        {
            string emailBuscado = email.Trim().ToLower();
            foreach (Usuario u in _usuarios)
            {
                if (u.Email.Trim().ToLower().Equals(emailBuscado))
                {
                    return u;
                }
            }
            return null;
        }


        public Usuario Login(string email, string pass)
        {
            Usuario u = BuscarporMail(email);
            if (u == null)
            {
                throw new Exception("El email es null");
            }
            else
            {
                // Comparación insensible a mayúsculas/minúsculas y eliminando espacios adicionales
                if (u.Contrasenia.Trim().Equals(pass.Trim()))
                {
                    return u;
                }
                else
                {
                    throw new Exception("la contraseña es incorrectos");
                }
               
               
            }
           
        }

        // Metodo para Empleados, monto total de pagos realizados por el usuario logueado
        public double MontoGastadoEsteMes(string email)
        {
            if (string.IsNullOrEmpty(email))
                return 0; 

            string emailBuscado = email.Trim().ToLower();
            double total = 0;
            DateTime ahora = DateTime.Now;
            int mesActual = ahora.Month;
            int anioActual = ahora.Year;
           
            
            foreach (Pago p in _pago) 
            {
                if (!p.Usuario.Email.Trim().ToLower().Equals(emailBuscado))
                    continue;

                
                if (p is PagoUnico pu)
                {
                    if (pu.Fecha.Month == mesActual && pu.Fecha.Year == anioActual)
                    {
                        total += p.Monto;  
                    }
                    

                }
                else if (p is PagoRecurrente pr) 
                {
                    if (pr.FechaInicio.Month == mesActual && pr.FechaInicio.Year == anioActual) 
                    { 
                        total += p.Monto;
                    }
                   
                }
            }
            return total; 
        }
    }
}

// mails de las precargas
/*
Ana García  
mail: angar0@Empresa.com  
pass: pass1223  

Luis Pérez  
mail: luipér0@Empresa.com  
pass: pass4562  

María López  
mail: marlóp0@Empresa.com  
pass: pass7892  

Carlos Fernández  
mail: carfer0@Empresa.com  
pass: pass3212  

Sofía Martínez  
mail: sofmar0@Empresa.com  
pass: pass6542  

Pedro Suárez  
mail: pedsuá0@Empresa.com  
pass: pass1121  

Lucía Alonso  
mail: lucalo0@Empresa.com  
pass: pass2222  

Javier Méndez  
mail: javmén0@Empresa.com  
pass: pass3332  

Valentina Silva  
mail: valsil0@Empresa.com  
pass: pass4442  

Martín Ramos  
mail: marram0@Empresa.com  
pass: pass5552  

Camila Torres  
mail: camtor0@Empresa.com  
pass: pass6626  

Diego Sosa  
mail: diesos0@Empresa.com  
pass: pass7727  

Florencia Vega  
mail: flóveg0@Empresa.com  
pass: pass8288  

Matías Cabrera  
mail: matcab0@Empresa.com  
pass: pass9299  

Paula Ruiz  
mail: paurui0@Empresa.com  
pass: pass0020  

Federico Gómez  
mail: fedgóm0@Empresa.com  
pass: passabc2  

Agustina Díaz  
mail: agudía0@Empresa.com  
pass: passdef2  

Nicolás Pintos  
mail: nicpin0@Empresa.com  
pass: passghi2  

Micaela Sánchez  
mail: micsán0@Empresa.com  
pass: passjkl2  

Rodrigo Castro  
mail: rodcas0@Empresa.com  
pass: passmno2  

Julieta Morales  
mail: julmor0@Empresa.com  
pass: passpqr2  

Emiliano Bermúdez  
mail: emibér0@Empresa.com  
pass: passstu2  

 */