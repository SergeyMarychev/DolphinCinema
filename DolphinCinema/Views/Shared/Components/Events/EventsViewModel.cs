using DolphinCinema.Domain.Entities;

namespace DolphinCinema.Views.Shared.Components.Events
{
	public class EventsViewModel
	{
		public IEnumerable<Event> Items { get; set; }

		public EventsViewModel(IEnumerable<Event> items)
		{
			Items = items;
		}
	}
}
