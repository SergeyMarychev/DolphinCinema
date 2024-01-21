using System.ComponentModel.DataAnnotations.Schema;

namespace DolphinCinema.Domain.Entities
{
    public class Ticket : Entity
    {
        public int SeanceId { get; set; }

        [ForeignKey("SeanceId")]
        public Seance Seance { get; set; }

        public int SeatId { get; set; }

        [ForeignKey("SeatId")]
        public Seat Seat { get; set; }
        public bool IsSold { get; set; }
        public int Price { get; set; }
    }
}
