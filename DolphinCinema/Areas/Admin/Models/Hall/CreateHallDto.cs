using DolphinCinema.Domain.Entities;

namespace DolphinCinema.Areas.Admin.Models.Hall
{
    public class CreateHallDto
    {
        public string Name { get; set; }
        public IEnumerable<Seat> Seats { get; set; }
    }
}
