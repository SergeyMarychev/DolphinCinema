using System.ComponentModel.DataAnnotations.Schema;

namespace DolphinCinema.Domain.Entities
{
    public class Movie : Entity
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<Seance> Seances { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public int Duration { get; set; }
        public int AgeLable { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PathToImage { get; set; }
        public string Country { get; set; }
    }
}
