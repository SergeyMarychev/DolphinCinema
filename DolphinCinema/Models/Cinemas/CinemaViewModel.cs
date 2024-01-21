using AutoMapper;
using DolphinCinema.Domain.Entities;

namespace DolphinCinema.Models.Cinemas
{
    [AutoMap(typeof(Cinema), ReverseMap = true)]
    public class CinemaViewModel
    {
        public string AboutCinema { get; set; }
        public string BankData { get; set; }
        public string Address { get; set; }
        public string Contacts { get; set; }
        public string ImportantInformation { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
