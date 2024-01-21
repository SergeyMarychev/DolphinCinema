namespace DolphinCinema.Domain.Entities
{
    public class Cinema : Entity
    {
        public string AboutCinema { get; set; }
        public string BankData { get; set; }
        public string Address { get; set; }
        public string Contacts { get; set; }
        public string ImportantInformation { get; set; }
        public List<string> Images { get; set; }
    }
}
