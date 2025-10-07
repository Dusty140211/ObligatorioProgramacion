namespace Obligatorio.Logica
{
    public class Equipo
    {
        private int id;
        private string nombre;

        public static int contador = 0; 

        public int Id 
        {
            get { return id; }
        }

        public string Nombre
        { 
            get{ return nombre; }
            set { nombre = value; }
        }

        public Equipo(string nombre) 
        {
            contador++; 
            this.id = contador;
            this.nombre = nombre;
        }
        public static bool validarNombre(string nombre) 
        {
            if (string.IsNullOrWhiteSpace(nombre)) return false;
            return true; 
        }
    }
}
