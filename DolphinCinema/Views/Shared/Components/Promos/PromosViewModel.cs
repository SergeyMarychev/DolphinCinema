using DolphinCinema.Domain.Entities;

namespace DolphinCinema.Views.Shared.Components.Promos
{
	public class PromosViewModel
	{
		public IEnumerable<Promo> Items { get; set; }

		public PromosViewModel(IEnumerable<Promo> items)
		{
			Items = items;
		}
	}
}
