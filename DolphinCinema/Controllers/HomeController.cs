using AutoMapper;
using DolphinCinema.Domain;
using DolphinCinema.Models;
using DolphinCinema.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DolphinCinema.Controllers
{
	public class HomeController : BaseMvcController
	{
		public HomeController(DolphinCinemaDbContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public async Task<IActionResult> Index()
		{
			var viewModel = new PosterViewModel();
			var items = new List<PosterItemViewModel>();

			var movies = await Context.Movies
				.Include(m => m.MovieGenres)
				.ThenInclude(m => m.Genre)
				.Include(m => m.Seances)
				.ThenInclude(m => m.Hall)
				.ToArrayAsync();

			foreach (var movie in movies)
			{
				items.Add(new PosterItemViewModel
				{
					AgeLable = movie.AgeLable,
					PathToImage = movie.PathToImage,
					Title = movie.Title,
					Genres = movie.MovieGenres.Select(g => g.Genre.Name),
					Seances = movie.Seances.Select(s => new PosterItemSeanceViewModel
					{
						Format = s.Format,
						Price = s.Price,
						Hall = s.Hall.Name,
						Time = TimeOnly.FromDateTime(s.Date),
						Id = s.Id
					}).OrderBy(s => s.Time)
				});
			}

			viewModel.Items = items;

			return View(viewModel);
		}

		[HttpGet]
		public async Task<PartialViewResult> GetPosterItems(DateTime date)
		{
            var items = new List<PosterItemViewModel>();

            var movies = await Context.Movies
                .Include(m => m.MovieGenres)
                .ThenInclude(m => m.Genre)
                .Include(m => m.Seances)
                .ThenInclude(m => m.Hall)
                .ToArrayAsync();

            foreach (var movie in movies)
            {
                items.Add(new PosterItemViewModel
                {
                    AgeLable = movie.AgeLable,
                    PathToImage = movie.PathToImage,
                    Title = movie.Title,
                    Genres = movie.MovieGenres.Select(g => g.Genre.Name),
                    Seances = movie.Seances.Select(s => new PosterItemSeanceViewModel
                    {
                        Format = s.Format,
                        Price = s.Price,
                        Hall = s.Hall.Name,
						Time = TimeOnly.FromDateTime(s.Date),
						Id = s.Id
                    }).OrderBy(s => s.Time)
				});
            }

            return PartialView("_PosterItems", items);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}