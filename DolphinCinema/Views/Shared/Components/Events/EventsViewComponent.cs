using DolphinCinema.Domain;
using DolphinCinema.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DolphinCinema.Views.Shared.Components.Events
{
	public class EventsViewComponent : ViewComponent
	{
		private readonly DolphinCinemaDbContext _context;

		public EventsViewComponent(DolphinCinemaDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke(bool isShowAll = true, bool isShowAllTitle = true)
		{
			IQueryable<Event> query = _context.Events.OrderByDescending(e => e.Date);

			if (!isShowAll)
			{
				query = query.Take(3);
			}

			ViewBag.ShowAllTitle = isShowAllTitle;

			return View(new EventsViewModel(query.ToList()));
		}
	}
}
