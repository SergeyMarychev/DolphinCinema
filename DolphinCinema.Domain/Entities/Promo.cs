namespace DolphinCinema.Domain.Entities
{
    public class Promo : Entity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string PathToImage { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool IsActive { get; set; }
    }
}
