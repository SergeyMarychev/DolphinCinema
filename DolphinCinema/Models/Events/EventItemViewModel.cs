using AutoMapper;
using DolphinCinema.Domain.Entities;

namespace DolphinCinema.Models.Events
{
	[AutoMap(typeof(Event), ReverseMap = true)]
	public class EventItemViewModel
	{
		public string DisplayName { get; set; }
		public string Description { get; set; }
		public string PathToImage { get; set; }
		public DateTime? Date { get; set; }
	}
}
