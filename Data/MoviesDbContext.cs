using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.Data
{
    public class MoviesDbContext: DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<ArtistaPelicula> ArtistaPeliculas { get; set; }

    }
}
