namespace Musica.Core
{
    public class Album
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Cancion> Canciones { get; set; }

        public Album(int id, string nombre)
        {
            Id = id;
            Nombre= nombre;
        }
        public void AgregarCancion(Cancion cancion)
        {

        }
    }
}
