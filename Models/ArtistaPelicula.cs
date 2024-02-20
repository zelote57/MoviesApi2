namespace MoviesApi.Models
{
    public class ArtistaPelicula
    {
        public int Id { get; set; }
        public int ArtistaId { get; set; }
        public Artista Artista { get; set; }
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }

    }
}
