using System.ComponentModel.DataAnnotations.Schema;

namespace DolphinCinema.Domain.Entities
{
    public class Seance : Entity
    {
        public int HallId { get; set; }

        [ForeignKey("HallId")]
        public Hall Hall { get; set; }

        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public int AdvertisingDuration { get; set; }
        public string Format { get; set; }
    }
}
