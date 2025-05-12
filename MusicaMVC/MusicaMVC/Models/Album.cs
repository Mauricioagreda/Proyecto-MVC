namespace MusicaMVC.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string Nombre { get; set; }
        public int IdArtista { get; set; }
        public virtual Artista ArtistaReferencia { get; set; }
        public virtual ICollection<Cancion> CancionesReferenia { get; set;}
    }
}
