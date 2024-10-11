namespace Musica.Core
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Album> Albums { get; set; }
        public List<Cancion> Canciones { get; set; }

        public Artista(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public void AgregarAlbum(Album album)
        {

        }
        public void AgregarCancion(Cancion cancion)
        {

        }
    }
}
