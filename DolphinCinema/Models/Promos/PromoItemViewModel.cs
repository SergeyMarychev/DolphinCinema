using AutoMapper;
using DolphinCinema.Domain.Entities;

namespace DolphinCinema.Models.Promos
{
	[AutoMap(typeof(Promo), ReverseMap = true)]
	public class PromoItemViewModel
	{
		public string DisplayName { get; set; }
		public string Description { get; set; }
		public string PathToImage { get; set; }
		public DateTime? DateStart { get; set; }
		public DateTime? DateEnd { get; set; }
	}
}
