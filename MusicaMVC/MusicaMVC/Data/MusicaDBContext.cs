using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicaMVC.Models;
namespace MusicaMVC.Data
{
    public class MusicaDBContext : DbContext
    {
        public MusicaDBContext(DbContextOptions<MusicaDBContext> options) : base(options)
        {

        }

        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<Album> Albumes { get; set; }
        public DbSet<Artista> Artistas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cancion>(tb =>
            {
                tb.HasKey(col => col.IdCancion);
                tb.Property(col => col.IdCancion)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre)
                .HasMaxLength(50);

                tb.HasOne(col => col.AlbumReferencia).WithMany(col => col.CancionesReferenia)
                .HasForeignKey(col => col.IdAlbum);
            });

            modelBuilder.Entity<Album>(tb =>
            {
                tb.HasKey(col => col.IdAlbum);
                tb.Property(col => col.IdAlbum)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre)
                .HasMaxLength(50);

                tb.HasOne(col => col.ArtistaReferencia).WithMany(col => col.AlbumReferencia)
                .HasForeignKey(col => col.IdArtista);
            });

            modelBuilder.Entity<Artista>(tb =>
            {
                tb.HasKey(col => col.IdArtista);

                tb.Property(col => col.IdArtista)
                .UseIdentityColumn();

                tb.Property(col => col.Nombre)
                .HasMaxLength(50);
            });
            modelBuilder.Entity<Artista>().ToTable("Artista");
            modelBuilder.Entity<Cancion>().ToTable("Cancion");
            modelBuilder.Entity<Album>().ToTable("Album");
        }
    }
}
