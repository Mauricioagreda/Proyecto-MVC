using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
            });

            modelBuilder.Entity<Album>(tb =>
            {
                tb.HasKey(col => col.IdAlbum);

                tb.Property(col => col.IdAlbum)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre)
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Cancion>().ToTable("Cancion");
            modelBuilder.Entity<Album>().ToTable("Album");
        }
    }
}
