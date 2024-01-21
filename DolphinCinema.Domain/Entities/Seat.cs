using System.ComponentModel.DataAnnotations.Schema;

namespace DolphinCinema.Domain.Entities
{
    public class Seat : Entity
    {
        public int HallId { get; set; }

        [ForeignKey("HallId")]
        public Hall Hall { get; set; }

        public int Row { get; set; }
        public int Number { get; set; }
        public int OffsetTop { get; set; }
        public int OffsetLeft { get; set; }
    }
}
