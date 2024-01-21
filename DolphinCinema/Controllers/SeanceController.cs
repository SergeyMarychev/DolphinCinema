using AutoMapper;
using DolphinCinema.Domain;
using DolphinCinema.Models.Home;
using DolphinCinema.Models.Seances;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DolphinCinema.Controllers
{
	[Route("seance")]
	public class SeanceController : BaseMvcController
	{
		public SeanceController(DolphinCinemaDbContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> SeanceModal(int seanceId)
		{
			var seance = await Context.Seances.FindAsync(seanceId);
			if (seance == null)
			{
				return BadRequest();
			}

			var movie = await Context.Movies
				.Include(m => m.Seances)
				.ThenInclude(m => m.Hall)
				.FirstAsync(m => m.Id == seance.MovieId);

			var tickets = await Context.Tickets
				.Include(t => t.Seat)
				.Where(t => t.SeanceId == seanceId)
				.ToListAsync();

			var model = new SeanceModalViewModel
			{
				Seances = movie.Seances.Select(s => new PosterItemSeanceViewModel
				{
					Format = s.Format,
					Price = s.Price,
					Hall = s.Hall.Name,
					Time = TimeOnly.FromDateTime(s.Date),
					Id = s.Id
				}).OrderBy(s => s.Time),
				Title = movie.Title,
				Date = seance.Date.ToString("dd MMMM"),
				Seats = tickets.Select(t => new SeatOnSeanceViewModel
				{
					Id = t.SeatId,
					Number = t.Seat.Number,
					Row = t.Seat.Row,
					OffsetLeft = t.Seat.OffsetLeft,
					OffsetTop = t.Seat.OffsetTop,
					IsSold = t.IsSold,
					Price = t.Price
				})
			};

			return PartialView("_SeanceModal", model);
		}
	}
}
