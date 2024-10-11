namespace Musica.Core
{
    public class Cancion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Duracion { get; set; }

        public Cancion(int id, string nombre, float duracion)
        {
            Id = id;
            Nombre = nombre;
            Duracion = duracion;
        }
    }
}
