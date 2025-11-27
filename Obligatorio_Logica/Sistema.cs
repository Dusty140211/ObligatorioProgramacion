using Obligatorio_Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
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
        private List<Tipo_gasto> _tiposGasto = new List<Tipo_gasto>();


        public List<Usuario> Usuarios { get { return new List<Usuario>(_usuarios); } }
        public List<Equipo> Equipos { get { return new List<Equipo>(_equipo); } }
        public List<Pago> Pagos { get { return new List<Pago>(_pago); } }

        public List<Tipo_gasto> tipo_Gastos { get { return new List<Tipo_gasto>(_tiposGasto); } }
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

        public void AltaTipoGasto(Tipo_gasto tg)
        {
            _tiposGasto.Add(tg);
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
            if (tipo_Gastos.Count == 0)
            {
                _tiposGasto.Add(new Tipo_gasto("Comida", "Gastos de alimentación"));
                _tiposGasto.Add(new Tipo_gasto("Transporte", "Gastos de transporte"));
                _tiposGasto.Add(new Tipo_gasto("Servicios", "Gastos de servicios"));
                _tiposGasto.Add(new Tipo_gasto("Entretenimiento", "Gastos de ocio"));
            }
            Tipo_gasto tg1 = tipo_Gastos[0];
            Tipo_gasto tg2 = tipo_Gastos[1];
            Tipo_gasto tg3 = tipo_Gastos[2];
            Tipo_gasto tg4 = tipo_Gastos[3];



            Usuario u1 = _usuarios[0];
            Usuario u2 = _usuarios[1];
            Usuario u3 = _usuarios[2];
            Usuario u4 = _usuarios[3];
            Usuario u5 = _usuarios[4];
            Usuario u6 = _usuarios[5];
            Usuario u7 = _usuarios[6];
            Usuario u8 = _usuarios[7];
            Usuario u9 = _usuarios[8];
            Usuario u10 = _usuarios[9];
            Usuario u11 = _usuarios[10];
            Usuario u12 = _usuarios[11];
            Usuario u13 = _usuarios[12];
            Usuario u14 = _usuarios[13];
            Usuario u15 = _usuarios[14];
            Usuario u16 = _usuarios[15];
            Usuario u17 = _usuarios[16];
            Usuario u18 = _usuarios[17];
            Usuario u19 = _usuarios[18];
            Usuario u20 = _usuarios[19];
            Usuario u21 = _usuarios[20];
            Usuario u22 = _usuarios[21];


            // Pagos únicos
            altaPago(new PagoUnico(metodoPago.DEBITO, new DateTime(2025, 11, 2), 1102, 950, "Taxi", tg2, u2));
            altaPago(new PagoUnico(metodoPago.EFECTIVO, new DateTime(2025, 11, 3), 1103, 1300, "Gas", tg3, u5));
            altaPago(new PagoUnico(metodoPago.CREDITO, new DateTime(2025, 11, 4), 1104, 2100, "Cine", tg4, u8));
            altaPago(new PagoUnico(metodoPago.DEBITO, new DateTime(2025, 11, 5), 1105, 1200, "Panadería", tg1, u11));
            altaPago(new PagoUnico(metodoPago.EFECTIVO, new DateTime(2025, 11, 6), 1106, 1000, "Ómnibus", tg2, u14));
            altaPago(new PagoUnico(metodoPago.CREDITO, new DateTime(2025, 11, 7), 1107, 1600, "Luz", tg3, u17));
            altaPago(new PagoUnico(metodoPago.DEBITO, new DateTime(2025, 11, 8), 1108, 1900, "Teatro", tg4, u20));
            altaPago(new PagoUnico(metodoPago.EFECTIVO, new DateTime(2025, 11, 9), 1109, 1400, "Verdulería", tg1, u22));
            altaPago(new PagoUnico(metodoPago.CREDITO, new DateTime(2025, 11, 10), 1110, 950, "Remise", tg2, u3));
            altaPago(new PagoUnico(metodoPago.DEBITO, new DateTime(2025, 11, 11), 1111, 1100, "Internet", tg3, u6));
            altaPago(new PagoUnico(metodoPago.EFECTIVO, new DateTime(2025, 11, 12), 1112, 1700, "Museo", tg4, u9));
            altaPago(new PagoUnico(metodoPago.CREDITO, new DateTime(2025, 11, 13), 1113, 1350, "Carnicería", tg1, u12));
            altaPago(new PagoUnico(metodoPago.DEBITO, new DateTime(2025, 11, 14), 1114, 1050, "Subte", tg2, u15));
            altaPago(new PagoUnico(metodoPago.EFECTIVO, new DateTime(2025, 11, 15), 1115, 1150, "Agua", tg3, u18));
            altaPago(new PagoUnico(metodoPago.CREDITO, new DateTime(2025, 11, 16), 1116, 1750, "Concierto", tg4, u21));
            altaPago(new PagoUnico(metodoPago.DEBITO, new DateTime(2025, 11, 17), 1117, 1550, "Supermercado", tg1, u4));
            altaPago(new PagoUnico(metodoPago.EFECTIVO, new DateTime(2025, 11, 18), 1118, 1000, "Taxi", tg2, u7));
            altaPago(new PagoUnico(metodoPago.CREDITO, new DateTime(2025, 11, 19), 1119, 1250, "Gas", tg3, u10));
            altaPago(new PagoUnico(metodoPago.DEBITO, new DateTime(2025, 11, 20), 1120, 1800, "Cine", tg4, u13));

            // Pagos recurrentes
            altaPago(new PagoRecurrente(metodoPago.CREDITO, new DateTime(2025, 11, 1), new DateTime(2026, 5, 1), "Netflix", 7, 7, 550, tg4, u1));
            altaPago(new PagoRecurrente(metodoPago.DEBITO, new DateTime(2025, 11, 2), new DateTime(2026, 5, 2), "Gimnasio", 6, 6, 300, tg4, u5));
            altaPago(new PagoRecurrente(metodoPago.EFECTIVO, new DateTime(2025, 11, 3), new DateTime(2026, 5, 3), "Spotify", 5, 5, 400, tg4, u9));
            altaPago(new PagoRecurrente(metodoPago.CREDITO, new DateTime(2025, 11, 4), new DateTime(2026, 5, 4), "Alquiler", 8, 8, 600, tg3, u13));
            altaPago(new PagoRecurrente(metodoPago.DEBITO, new DateTime(2025, 11, 5), new DateTime(2026, 5, 5), "Revista", 4, 4, 350, tg4, u17));
            altaPago(new PagoRecurrente(metodoPago.EFECTIVO, new DateTime(2025, 11, 6), new DateTime(2026, 5, 6), "Colegio", 10, 10, 700, tg3, u21));
            altaPago(new PagoRecurrente(metodoPago.CREDITO, new DateTime(2025, 11, 7), new DateTime(2026, 5, 7), "Seguro", 12, 12, 800, tg3, u2));
            altaPago(new PagoRecurrente(metodoPago.DEBITO, new DateTime(2025, 11, 8), new DateTime(2026, 5, 8), "Club", 9, 9, 450, tg4, u6));
            altaPago(new PagoRecurrente(metodoPago.EFECTIVO, new DateTime(2025, 11, 9), new DateTime(2026, 5, 9), "Netflix", 7, 7, 550, tg4, u10));
            altaPago(new PagoRecurrente(metodoPago.CREDITO, new DateTime(2025, 11, 10), new DateTime(2026, 5, 10), "Gimnasio", 6, 6, 350, tg4, u14));
            altaPago(new PagoRecurrente(metodoPago.DEBITO, new DateTime(2025, 11, 11), new DateTime(2026, 5, 11), "Spotify", 5, 5, 400, tg4, u18));
            altaPago(new PagoRecurrente(metodoPago.EFECTIVO, new DateTime(2025, 11, 12), new DateTime(2026, 5, 12), "Alquiler", 8, 8, 600, tg3, u22));
            altaPago(new PagoRecurrente(metodoPago.CREDITO, new DateTime(2025, 11, 13), new DateTime(2026, 5, 13), "Revista", 4, 4, 350, tg4, u3));
            altaPago(new PagoRecurrente(metodoPago.DEBITO, new DateTime(2025, 11, 14), new DateTime(2026, 5, 14), "Colegio", 10, 10, 700, tg3, u7));

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

            Usuario u1 = new Usuario("Ana", "García", "pass1223", crearMail("Ana", "García"), equipo1, new DateTime(2023, 1, 15), Cargo.GERENTE);
            Usuario u2 = new Usuario("Luis", "Pérez", "pass4562", crearMail("Luis", "Pérez"), equipo2, new DateTime(2022, 6, 10), Cargo.EMPLEADO);
            Usuario u3 = new Usuario("María", "López", "pass7892", crearMail("María", "López"), equipo1, new DateTime(2023, 3, 5), Cargo.EMPLEADO);
            Usuario u4 = new Usuario("Carlos", "Fernández", "pass3212", crearMail("Carlos", "Fernández"), equipo3, new DateTime(2021, 11, 20), Cargo.GERENTE);
            Usuario u5 = new Usuario("Sofía", "Martínez", "pass6542", crearMail("Sofía", "Martínez"), equipo2, new DateTime(2022, 9, 30), Cargo.EMPLEADO);
            Usuario u6 = new Usuario("Pedro", "Suárez", "pass1121", crearMail("Pedro", "Suárez"), equipo4, new DateTime(2022, 2, 14), Cargo.EMPLEADO);
            Usuario u7 = new Usuario("Lucía", "Alonso", "pass2222", crearMail("Lucía", "Alonso"), equipo1, new DateTime(2021, 7, 19), Cargo.EMPLEADO);
            Usuario u8 = new Usuario("Javier", "Méndez", "pass3332", crearMail("Javier", "Méndez"), equipo2, new DateTime(2023, 4, 2), Cargo.EMPLEADO);
            Usuario u9 = new Usuario("Valentina", "Silva", "pass4442", crearMail("Valentina", "Silva"), equipo3, new DateTime(2022, 8, 8), Cargo.EMPLEADO);
            Usuario u10 = new Usuario("Martín", "Ramos", "pass5552", crearMail("Martín", "Ramos"), equipo4, new DateTime(2021, 12, 25), Cargo.EMPLEADO);
            Usuario u11 = new Usuario("Camila", "Torres", "pass6626", crearMail("Camila", "Torres"), equipo1, new DateTime(2022, 5, 17), Cargo.EMPLEADO);
            Usuario u12 = new Usuario("Diego", "Sosa", "pass7727", crearMail("Diego", "Sosa"), equipo2, new DateTime(2023, 2, 11), Cargo.EMPLEADO);
            Usuario u13 = new Usuario("Florencia", "Vega", "pass8288", crearMail("Florencia", "Vega"), equipo3, new DateTime(2022, 10, 3), Cargo.GERENTE);
            Usuario u14 = new Usuario("Matías", "Cabrera", "pass9299", crearMail("Matías", "Cabrera"), equipo4, new DateTime(2021, 9, 27), Cargo.EMPLEADO);
            Usuario u15 = new Usuario("Paula", "Ruiz", "pass0020", crearMail("Paula", "Ruiz"), equipo1, new DateTime(2022, 3, 21), Cargo.EMPLEADO);
            Usuario u16 = new Usuario("Federico", "Gómez", "passabc2", crearMail("Federico", "Gómez"), equipo2, new DateTime(2023, 6, 6), Cargo.EMPLEADO);
            Usuario u17 = new Usuario("Agustina", "Díaz", "passdef2", crearMail("Agustina", "Díaz"), equipo3, new DateTime(2022, 1, 13), Cargo.EMPLEADO);
            Usuario u18 = new Usuario("Nicolás", "Pintos", "passghi2", crearMail("Nicolás", "Pintos"), equipo4, new DateTime(2021, 8, 5), Cargo.EMPLEADO);
            Usuario u19 = new Usuario("Micaela", "Sánchez", "passjkl2", crearMail("Micaela", "Sánchez"), equipo1, new DateTime(2022, 11, 29), Cargo.EMPLEADO);
            Usuario u20 = new Usuario("Rodrigo", "Castro", "passmno2", crearMail("Rodrigo", "Castro"), equipo2, new DateTime(2023, 5, 18), Cargo.GERENTE);
            Usuario u21 = new Usuario("Julieta", "Morales", "passpqr2", crearMail("Julieta", "Morales"), equipo3, new DateTime(2022, 7, 23), Cargo.EMPLEADO);
            Usuario u22 = new Usuario("Emiliano", "Bermúdez", "passstu2", crearMail("Emiliano", "Bermúdez"), equipo4, new DateTime(2021, 10, 12), Cargo.EMPLEADO);



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

        public void altaGasto(Tipo_gasto t)
        {
            t.Validar();
            if (_tiposGasto.Contains(t))
            {
                throw new Exception("El gasto fue ingresado previamente"); 
            }
            _tiposGasto.Add(t);
        }


        public List<Pago> listarPagosPorMail(string email)
        {
            List<Pago> pagosUsuario = new List<Pago>();
            string emailBuscado = email.Trim().ToLower();
            foreach (Pago p in _pago)
            {
                if (p.Usuario.Email.Trim().ToLower() == emailBuscado)
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
            foreach (Equipo e in _equipo)
            {
                if (e.Nombre == nombre)
                {
                    existe = true;
                }

            }
            return existe;
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

        public int CompararPorEmail(Usuario a, Usuario b)
        {
            return a.Email.CompareTo(b.Email);
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

        // Arreglar metodo public LIst<Pago> MontoTotalPagosPorUsuario(int mes, int año, Usuarios u)


        public List<Pago> pagosDelMes(DateTime fecha, Usuario u)
        {
            List<Pago> ret = new List<Pago>();
            foreach (Pago p in _pago)
            {
                if (p is PagoRecurrente pr)
                {
                    if ((pr.FechaInicio.Month == fecha.Month && pr.FechaInicio.Year == fecha.Year) || (pr.FechaFin.Month == fecha.Month && pr.FechaFin.Year == fecha.Year))
                    {
                        if (pr.Usuario.Email.Trim().ToLower() == u.Email.Trim().ToLower())
                        {
                            ret.Add(p);
                        }
                    }
                }
                if (p is PagoUnico pu)
                {
                    if (pu.Fecha.Month == fecha.Month && pu.Fecha.Year == fecha.Year)
                    {
                        if (pu.Usuario.Email.Trim().ToLower() == u.Email.Trim().ToLower())
                        {
                            ret.Add(p);
                        }
                    }
                }
            }
            ret.Sort(new ComparadorPagosPorMonto());

            return ret;
        }

        public List<Pago> pagosDeEquipo(DateTime fecha, Usuario u1)
        {
            List<Pago> ret = new List<Pago>();
            List<Usuario> usuarios = new List<Usuario>();

            foreach (Usuario u in _usuarios)
            {
                if (u.Equipo == u1.Equipo)
                {
                    usuarios.Add(u);
                }
            }
            foreach (Usuario u in usuarios)
            {
                ret.AddRange(pagosDelMes(fecha, u));
            }
            ret.Sort(new ComparadorPagosPorMonto());

            return ret;

        }



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

        // Calcular pagos pendientes 
        public void CalcularPagoPendientesPorMail(string email)
        {
            string emailBuscado = email.ToLower().Trim();

            foreach (Pago p in _pago)
            {
                if (p.Usuario.Email.ToLower().Trim() == emailBuscado)
                {
                    if (p is PagoRecurrente pr)
                    {
                        pr.calcularPagosPendientes();
                    }
                }
            }
        }


      


    }

}

// mails de las precargas
/*
anagar0@Empresa.com:pass1223
luipér0@Empresa.com:pass4562
marlóp0@Empresa.com:pass7892
carfer0@Empresa.com:pass3212
sofmar0@Empresa.com:pass6542
pedsuá0@Empresa.com:pass1121
lucalo0@Empresa.com:pass2222
javmén0@Empresa.com:pass3332
valsil0@Empresa.com:pass4442
marram0@Empresa.com:pass5552
camtor0@Empresa.com:pass6626
diesos0@Empresa.com:pass7727
flóveg0@Empresa.com:pass8288
matcab0@Empresa.com:pass9299
paurui0@Empresa.com:pass0020
fedgóm0@Empresa.com:passabc2
agudía0@Empresa.com:passdef2
nicpin0@Empresa.com:passghi2
micsán0@Empresa.com:passjkl2
rodcas0@Empresa.com:passmno2
julmor0@Empresa.com:passpqr2
emibér0@Empresa.com:passstu2
 

 */