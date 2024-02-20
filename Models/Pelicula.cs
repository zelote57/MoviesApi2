namespace MoviesApi.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

    }
}
