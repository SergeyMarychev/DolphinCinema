namespace DolphinCinema.Domain.Entities
{
    public class Hall : Entity
    {
        public string Name { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public string? PathToImage { get; set; }
    }
}
