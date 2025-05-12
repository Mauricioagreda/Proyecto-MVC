namespace MusicaMVC.Models
{
    public class Artista
    {
        public int IdArtista { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Album> AlbumReferencia { get; set; }
    }
}
