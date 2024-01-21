using AutoMapper;
using DolphinCinema.Domain;
using DolphinCinema.Models.Events;
using Microsoft.AspNetCore.Mvc;

namespace DolphinCinema.Controllers
{
    [Route("event")]
    public class EventController : BaseMvcController
	{
		public EventController(DolphinCinemaDbContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("{name}")]
		public IActionResult EventItem(string name)
		{
			var events = Context.Events.FirstOrDefault(e => e.Name == name);
			if (events == null)
			{
				return NotFound(); // TODO Обработать ошибку 404
			}

			var model = Mapper.Map<EventItemViewModel>(events);
			return View(model);
		}
	}
}
