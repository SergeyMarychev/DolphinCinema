using System.ComponentModel.DataAnnotations.Schema;

namespace DolphinCinema.Domain.Entities
{
    public class MovieGenre
    {
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
