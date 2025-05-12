namespace MusicaMVC.Models
{
    public class Cancion
    {
        public int IdCancion { get; set; }
        public string Nombre { get; set; }
        public float Duracion { get; set; }
        public int IdAlbum { get; set; }
        public virtual Album AlbumReferencia { get; set; }
    }
}
