using AutoMapper;
using DolphinCinema.Domain;
using DolphinCinema.Models.Promos;
using Microsoft.AspNetCore.Mvc;

namespace DolphinCinema.Controllers
{
	[Route("promo")]
	public class PromoController : BaseMvcController
	{
		public PromoController(DolphinCinemaDbContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("{name}")]
		public IActionResult PromoItem(string name)
		{
			var promo = Context.Promos.FirstOrDefault(p => p.Name == name);
			if (promo == null)
			{
				return NotFound(); // TODO Обработать ошибку 404
			}

			var model = Mapper.Map<PromoItemViewModel>(promo);
			return View(model);
		}
	}
}
